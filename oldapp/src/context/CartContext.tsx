import React, { createContext, useContext, ReactNode, useEffect } from 'react';
import AsyncStorage from '@react-native-async-storage/async-storage';
import { useAppSelector } from '../store/hooks';
import cartService from '../services/cartService';

interface CartItem {
  id: string;
  name: string;
  price: number;
  quantity: number;
  image: string;
  stock?: number;
  inStock?: boolean;
}

interface CartContextType {
  items: CartItem[];
  addToCart: (item: Omit<CartItem, 'quantity'>, quantityToAdd?: number) => void;
  removeFromCart: (id: string) => void;
  updateQuantity: (id: string, quantity: number) => void;
  clearCart: () => void;
  getTotalItems: () => number;
  getTotalPrice: () => number;
}

const CartContext = createContext<CartContextType | undefined>(undefined);

interface CartProviderProps {
  children: ReactNode;
}

const CART_STORAGE_KEY = '@cart_items';

export const CartProvider: React.FC<CartProviderProps> = ({ children }) => {
  const [items, setItems] = React.useState<CartItem[]>([]);
  const [isInitialized, setIsInitialized] = React.useState(false);
  const { user } = useAppSelector((state) => state.auth);
  const userId = user?._id;

  // Load cart from storage on mount
  React.useEffect(() => {
    const loadCart = async () => {
      try {
        const storedCart = await AsyncStorage.getItem(CART_STORAGE_KEY);
        if (storedCart) {
          setItems(JSON.parse(storedCart));
        }
      } catch (error) {
        console.error('Failed to load cart from storage:', error);
      } finally {
        setIsInitialized(true);
      }
    };
    
    loadCart();
  }, []);

  // Sync cart with backend when user logs in or out
  useEffect(() => {
    if (userId && isInitialized) {
      // Merge local cart with backend cart when user logs in
      mergeCartWithBackend();
    }
  }, [userId, isInitialized, mergeCartWithBackend]);

  // Merge local cart with backend cart
  const mergeCartWithBackend = React.useCallback(async () => {
    try {
      // Get current local cart items before loading from backend
      const currentLocalItems = [...items];
      
      // Load user's cart from backend
      const response = await cartService.getCart();
      let backendCartItems: CartItem[] = [];
      
      if (response.data && response.data.cart) {
        // Convert backend cart items to local cart format
        // Filter out items with null products (deleted products)
        backendCartItems = response.data.cart
          .filter((item: any) => item.product && item.product._id) // Filter out null products
          .map((item: any) => ({
            id: item.product._id,
            name: item.product.name,
            price: item.product.price,
            quantity: item.quantity,
            image: item.product.image,
            stock: item.product.stock,
            inStock: item.product.inStock,
          }));
      }
      
      // Merge local and backend carts
      const mergedCart: CartItem[] = [];
      const itemMap = new Map<string, CartItem>();
      
      // First, add all backend items
      backendCartItems.forEach(item => {
        itemMap.set(item.id, { ...item });
      });
      
      // Then, merge local items (add quantities if same product, or add new items)
      currentLocalItems.forEach(localItem => {
        const existingItem = itemMap.get(localItem.id);
        if (existingItem) {
          // Product exists in both - use the higher quantity or sum them
          existingItem.quantity = Math.max(existingItem.quantity, localItem.quantity);
        } else {
          // Product only in local cart - add it
          itemMap.set(localItem.id, { ...localItem });
        }
      });
      
      // Convert map back to array
      itemMap.forEach(item => {
        mergedCart.push(item);
      });
      
      // Update local state with merged cart
      setItems(mergedCart);
      
      // Save merged cart to local storage
      await AsyncStorage.setItem(CART_STORAGE_KEY, JSON.stringify(mergedCart));
      
      // Sync merged cart to backend (add any new items from local cart)
      if (mergedCart.length > 0) {
        for (const item of mergedCart) {
          const backendItem = backendCartItems.find(bi => bi.id === item.id);
          if (!backendItem || backendItem.quantity !== item.quantity) {
            // Item is new or quantity changed - sync to backend
            try {
              // If item exists in backend but quantity is different, update it
              if (backendItem && backendItem.quantity !== item.quantity) {
                await cartService.updateCartItemQuantity(item.id, item.quantity);
              } else {
                // New item - add to backend
                await cartService.addToCart(item.id, item.quantity);
              }
            } catch (error) {
              console.error(`Failed to sync item ${item.id} to backend:`, error);
            }
          }
        }
      }
    } catch (error) {
      console.error('Failed to merge cart with backend:', error);
      // If backend merge fails, keep local cart items
    }
  }, [items]);

  // Save cart to storage whenever items change
  React.useEffect(() => {
    if (isInitialized) {
      const saveCart = async () => {
        try {
          await AsyncStorage.setItem(CART_STORAGE_KEY, JSON.stringify(items));
        } catch (error) {
          console.error('Failed to save cart to storage:', error);
        }
      };
      
      saveCart();
    }
  }, [items, isInitialized]);

  const addToCart = React.useCallback(async (item: Omit<CartItem, 'quantity'>, quantityToAdd: number = 1) => {
    setItems(prevItems => {
      const existingItem = prevItems.find(i => i.id === item.id);
      if (existingItem) {
        return prevItems.map(i =>
          i.id === item.id ? { ...i, quantity: i.quantity + quantityToAdd } : i
        );
      } else {
        return [...prevItems, { ...item, quantity: quantityToAdd }];
      }
    });
    
    // If user is logged in, sync with backend
    if (userId) {
      try {
        await cartService.addToCart(item.id, quantityToAdd);
      } catch (error) {
        console.error('Failed to add item to backend cart:', error);
        // Revert the local cart change if backend sync fails
        setItems(prevItems => {
          const existingItem = prevItems.find(i => i.id === item.id);
          if (existingItem && existingItem.quantity === quantityToAdd) {
            // Remove item if quantity matches what we tried to add
            return prevItems.filter(i => i.id !== item.id);
          } else {
            // Decrease quantity by the amount we tried to add
            return prevItems.map(i =>
              i.id === item.id ? { ...i, quantity: i.quantity - quantityToAdd } : i
            );
          }
        });
      }
    }
  }, [userId]);

  const removeFromCart = React.useCallback(async (id: string) => {
    setItems(prevItems => prevItems.filter(item => item.id !== id));
    
    // If user is logged in, sync with backend
    if (userId) {
      try {
        await cartService.removeFromCart(id);
      } catch (error) {
        console.error('Failed to remove item from backend cart:', error);
        // We could revert the local change here, but it might be confusing to users
      }
    }
  }, [userId]);

  const updateQuantity = React.useCallback(async (id: string, quantity: number) => {
    // Don't allow quantity to go below 1
    if (quantity < 1) {
      return;
    }
    
    setItems(prevItems =>
      prevItems.map(item => (item.id === id ? { ...item, quantity } : item))
    );
    
    // If user is logged in, sync with backend
    if (userId) {
      try {
        await cartService.updateCartItemQuantity(id, quantity);
      } catch (error) {
        console.error('Failed to update item quantity in backend cart:', error);
        // Revert the local change if backend sync fails
        setItems(prevItems =>
          prevItems.map(item => (item.id === id ? { ...item, quantity: item.quantity } : item))
        );
      }
    }
  }, [userId]);

  const clearCart = React.useCallback(async () => {
    setItems([]);
    
    // If user is logged in, sync with backend
    if (userId) {
      try {
        await cartService.clearCart();
      } catch (error: any) {
        // Silently handle errors - don't log to console during normal operations
        // This prevents error messages during logout when token might be invalid
        // Only log in development mode for debugging
        if (__DEV__) {
          console.log('Note: Backend cart clearing failed (this may be expected during logout):', error?.message || 'Unknown error');
        }
        // We won't revert as clearing is usually intentional
      }
    }
  }, [userId]);

  const getTotalItems = React.useCallback(() => {
    return items.reduce((total, item) => total + item.quantity, 0);
  }, [items]);

  const getTotalPrice = React.useCallback(() => {
    return items.reduce((total, item) => total + item.price * item.quantity, 0);
  }, [items]);

  const contextValue: CartContextType = {
    items,
    addToCart,
    removeFromCart,
    updateQuantity,
    clearCart,
    getTotalItems,
    getTotalPrice,
  };

  return (
    <CartContext.Provider value={contextValue}>
      {children}
    </CartContext.Provider>
  );
};

export const useCart = (): CartContextType => {
  const context = useContext(CartContext);
  if (!context) {
    throw new Error('useCart must be used within a CartProvider');
  }
  return context;
};