import React, { useState, useEffect, useRef } from 'react';
import { View, Text, StyleSheet, ScrollView, TouchableOpacity, FlatList, Modal, TextInput, Image, Dimensions, ActivityIndicator, Alert } from 'react-native';
import { useTheme } from '../context/ThemeContext';
import { useCart } from '../context/CartContext';
import { useAppSelector } from '../store/hooks';
import Toast from 'react-native-toast-message';
import ThemedLayout from '../components/ThemedLayout';
import SearchLineIcon from '../components/SearchLineIcon';
import HeartIcon from '../components/HeartIcon';
import BackArrowIcon from '../components/BackArrowIcon';
import productService, { Product } from '../services/productService';

const ProductDetailScreen: React.FC<{ route: any, navigation: any }> = ({ route, navigation }) => {
  const { productId } = route.params;
  const { colors, theme } = useTheme();
  const { addToCart, getTotalItems, items: cartItems } = useCart();
  const { user } = useAppSelector((state) => state.auth);
  const [product, setProduct] = useState<Product | null>(null);
  const [relatedProducts, setRelatedProducts] = useState<Product[]>([]);
  const [loading, setLoading] = useState(true);
  const [loadingRelated, setLoadingRelated] = useState(false);
  const [currentImageIndex, setCurrentImageIndex] = useState(0);
  const [quantity, setQuantity] = useState(1);
  const [isFavorite, setIsFavorite] = useState(false);
  const [showProductDetails, setShowProductDetails] = useState(false);
  const [likedProducts, setLikedProducts] = useState<Set<string>>(new Set());
  const scrollViewRef = useRef<ScrollView>(null);
  const screenWidth = Dimensions.get('window').width;
  // Image carousel width calculation - accounts for horizontal margins (20px each side)
  const imageCarouselWidth = screenWidth - 40;
  
  // Fetch product details from backend
  useEffect(() => {
    loadProduct();
  }, [productId]);
  
  // Load related products when product loads
  useEffect(() => {
    if (product) {
      loadRelatedProducts();
      setCurrentImageIndex(0);
      scrollViewRef.current?.scrollTo({ x: 0, animated: false });
    }
  }, [product]);

  // Group related products by category
  const groupProductsByCategory = React.useMemo(() => {
    return relatedProducts.reduce((acc, prod) => {
      const category = prod.category || 'Other';
      if (!acc[category]) {
        acc[category] = [];
      }
      acc[category].push(prod);
      return acc;
    }, {} as Record<string, Product[]>);
  }, [relatedProducts]);
  
  const loadProduct = async () => {
    try {
      setLoading(true);
      const response = await productService.getProductById(productId);
     
      
      // API interceptor returns response.data directly
      // Backend returns: { success, statusCode, message, data: { product: {...} } }
      // So response structure is: { success, statusCode, message, data: { product: {...} } }
      const productData = response?.data?.product;
      
      if (productData && productData._id) {
        setProduct(productData);
      } else {
        console.error('Invalid product data structure. Response:', response);
        throw new Error('Product not found in response');
      }
    } catch (error: any) {
      console.error('Failed to load product:', error);
      const errorMessage = error?.message || error?.response?.message || 'Failed to load product details';
      Toast.show({
        type: 'error',
        text1: 'Error',
        text2: errorMessage,
        visibilityTime: 2000,
      });
    } finally {
      setLoading(false);
    }
  };


  const loadRelatedProducts = async () => {
    if (!product) return;
    
    try {
      setLoadingRelated(true);
      
      // Load all products to show category-wise (like HomeScreen)
      const response = await productService.getAllProducts({ limit: 'all' });
      
      // Extract products from response
      let products = [];
      
      if (response?.data?.data?.products) {
        products = response.data.data.products;
      } else if (response?.data?.products) {
        products = response.data.products;
      } else if ((response as any)?.products) {
        products = (response as any).products;
      }
      
      // Filter out the current product
      const related = products.filter((p: Product) => {
        const isNotCurrent = p._id !== product._id;
        return isNotCurrent;
      });
      
      setRelatedProducts(related);
    } catch (error: any) {
      console.error('Failed to load related products:', error);
      console.error('Error details:', error.message, error.response);
      // Don't show error toast for related products, just log it
      setRelatedProducts([]); // Set empty array on error
    } finally {
      setLoadingRelated(false);
    }
  };
  
  if (loading) {
    return (
      <ThemedLayout edges={['top']}>
        <View style={[styles.container, { backgroundColor: colors.background }]}>
          <View style={[styles.header, { backgroundColor: colors.surface, borderBottomColor: '#C4C4C4' }]}>        
            <TouchableOpacity 
              style={styles.backButton}
              onPress={() => navigation.goBack() || navigation.navigate('HomeTabs')}
            >
              <BackArrowIcon size={40} />
            </TouchableOpacity>
            <View style={styles.headerSpacer} />
            <TouchableOpacity 
              onPress={() => navigation.navigate('AllProducts')}
              style={styles.searchButton}
              activeOpacity={0.7}
            >
              <SearchLineIcon size={28} color={colors.text} />
            </TouchableOpacity>
          </View>
          <View style={styles.loadingContainer}>
            <ActivityIndicator size="large" color={colors.primary} />
            <Text style={[styles.loadingText, { color: colors.textSecondary }]}>Loading product...</Text>
          </View>
        </View>
      </ThemedLayout>
    );
  }
  
  if (!product) {
    return (
      <View style={[styles.container, { backgroundColor: colors.background }]}>  
        <View style={[styles.header, { backgroundColor: colors.surface, borderBottomColor: '#C4C4C4' }]}>  
          <TouchableOpacity 
            style={styles.backButton}
            onPress={() => navigation.goBack()}
          >
            <BackArrowIcon size={40} />
          </TouchableOpacity>
          <View style={styles.headerSpacer} />
          <TouchableOpacity 
            onPress={() => navigation.navigate('AllProducts')}
            style={styles.searchButton}
            activeOpacity={0.7}
          >
            <SearchLineIcon size={28} color={colors.text} />
          </TouchableOpacity>
        </View>
        <Text style={{ color: colors.text, textAlign: 'center', marginTop: 50 }}>Loading product...</Text>
      </View>
    );
  }

  // Helper function to check if string is a valid URL
  const isValidImageUrl = (url: string | undefined): boolean => {
    if (!url) return false;
    return url.startsWith('http://') || url.startsWith('https://');
  };

  const HorizontalProductCard = React.memo(({ item }: { item: Product }) => {
    const isValidImageUrl = item.image && (
      item.image.startsWith('http://') || item.image.startsWith('https://')
    );
    const itemColors = colors; // Use colors from parent component instead of calling useTheme()
    const isLiked = likedProducts.has(item._id);
    const imageUrl = isValidImageUrl ? item.image : null;
    const ratingStars = '⭐'.repeat(Math.floor(item.rating || 0));

    const handleProductPress = () => {
      if (navigation && item._id) {
        navigation.replace('ProductDetail', { productId: item._id });
      }
    };

    const handleAddToCart = (e: any) => {
      e.stopPropagation();
      if (item.inStock === false || (item.stock !== undefined && item.stock <= 0)) {
        Toast.show({
          type: 'info',
          text1: 'Out of Stock',
          text2: `${item.name} is currently out of stock`,
          visibilityTime: 2000,
        });
        return;
      }
      
      const isAlreadyInCart = cartItems.some(cartItem => cartItem.id === item._id);
      if (isAlreadyInCart) {
        Toast.show({
          type: 'info',
          text1: 'Already Added',
          text2: `${item.name} is already in your cart`,
          visibilityTime: 2000,
        });
        return;
      }
      
      addToCart({
        id: item._id,
        name: item.name,
        price: item.price,
        image: item.image,
      }, 1);
      
      Toast.show({
        type: 'success',
        text1: 'Added to Cart',
        text2: `${item.name} added to your cart`,
        visibilityTime: 2000,
      });
    };

    const handleLike = (e: any) => {
      e.stopPropagation();
      setLikedProducts(prev => {
        const newSet = new Set(prev);
        if (newSet.has(item._id)) {
          newSet.delete(item._id);
        } else {
          newSet.add(item._id);
        }
        return newSet;
      });
    };

    return (
      <TouchableOpacity
        style={[styles.horizontalProductCard, { backgroundColor: itemColors.surface }]}
        onPress={handleProductPress}
        activeOpacity={0.7}
      >
        <View style={styles.horizontalProductImageContainer}>
          {imageUrl ? (
            <Image 
              source={{ uri: imageUrl }} 
              style={styles.horizontalProductImage}
              resizeMode="contain"
            />
          ) : (
            <Text style={styles.horizontalProductImageEmoji}>{item.image || '🍫'}</Text>
          )}
        </View>
        <View style={styles.horizontalProductInfo}>
          <View style={styles.horizontalProductNameRow}>
            <Text style={[styles.horizontalProductName, { color: itemColors.text }]} numberOfLines={1}>
              {item.name}
            </Text>
            <TouchableOpacity 
              style={[styles.horizontalAddButton, { backgroundColor: '#381230' }]}
              onPress={handleAddToCart}
              activeOpacity={0.7}
            >
              <Text style={[styles.horizontalAddButtonText, { color: '#FFFFFF' }]}>+</Text>
            </TouchableOpacity>
          </View>
          <Text style={[styles.horizontalProductCategory, { color: itemColors.textSecondary }]}>
            {item.category || 'Products'}
          </Text>
          <View style={styles.horizontalProductRating}>
            <Text style={styles.ratingStars}>{ratingStars}</Text>
          </View>
          <View style={styles.horizontalProductPriceRow}>
            <Text style={[styles.horizontalProductPrice, { color: itemColors.primary }]}>
              MRP ₹ {item.price}
            </Text>
            <TouchableOpacity 
              style={styles.horizontalLikeButton}
              onPress={handleLike}
              activeOpacity={0.7}
            >
              <HeartIcon size={16} color="#381230" filled={isLiked} />
            </TouchableOpacity>
          </View>
        </View>
      </TouchableOpacity>
    );
  }, (prevProps, nextProps) => {
    // More efficient comparison - only check essential fields
    if (prevProps.item._id !== nextProps.item._id) return false;
    if (prevProps.item.name !== nextProps.item.name) return false;
    if (prevProps.item.price !== nextProps.item.price) return false;
    if (prevProps.item.image !== nextProps.item.image) return false;
    if (prevProps.item.category !== nextProps.item.category) return false;
    if (prevProps.item.rating !== nextProps.item.rating) return false;
    return true;
  });

  // Get product images - use product.image and product.images array
  const getProductImages = (): string[] => {
    const images: string[] = [];
    if (product.image && isValidImageUrl(product.image)) {
      images.push(product.image);
    }
    if (product.images && Array.isArray(product.images)) {
      product.images.forEach(img => {
        if (img && isValidImageUrl(img)) {
          images.push(img);
        }
      });
    }
    // Fallback to emoji if no valid images
    return images.length > 0 ? images : ['🍫'];
  };

  const productImages = getProductImages();

  const handlePageChange = (index: number) => {
    setCurrentImageIndex(index);
    // Scroll to the selected image
    scrollViewRef.current?.scrollTo({
      x: index * imageCarouselWidth,
      animated: true,
    });
  };

  const handleScroll = (event: any) => {
    const scrollPosition = event.nativeEvent.contentOffset.x;
    const index = Math.round(scrollPosition / imageCarouselWidth);
    if (index !== currentImageIndex && index >= 0 && index < productImages.length) {
      setCurrentImageIndex(index);
    }
  };

  const incrementQuantity = () => {
    setQuantity(prev => prev + 1);
  };

  const decrementQuantity = () => {
    if (quantity > 1) {
      setQuantity(prev => prev - 1);
    }
  };

  return (
    <ThemedLayout edges={['top']}>
      <View style={[styles.container, { backgroundColor: colors.background }]}>  
        {/* Header with back button and search */}
        <View style={[styles.header, { backgroundColor: colors.surface, borderBottomColor: '#C4C4C4' }]}>  
          <TouchableOpacity 
            style={styles.backButton}
            onPress={() => navigation.goBack()}
          >
            <BackArrowIcon size={40} />
          </TouchableOpacity>
          <View style={styles.headerSpacer} />
          <TouchableOpacity 
            onPress={() => navigation.navigate('AllProducts')}
            style={styles.searchButton}
            activeOpacity={0.7}
          >
            <SearchLineIcon size={28} color={colors.text} />
          </TouchableOpacity>
        </View>
        <ScrollView
          showsVerticalScrollIndicator={true}
          contentContainerStyle={styles.scrollContent}
        >
          {/* Product Images Carousel with Swipe */}
          <View style={styles.carouselContainer}>
            <ScrollView
              ref={scrollViewRef}
              horizontal
              pagingEnabled
              showsHorizontalScrollIndicator={false}
              onScroll={handleScroll}
              scrollEventThrottle={16}
              style={styles.imageScrollView}
              contentContainerStyle={styles.imageScrollContent}
              nestedScrollEnabled={true}
            >
              {productImages.map((imageUrl, index) => (
                <View key={index} style={[styles.imageContainer, { width: imageCarouselWidth }]}>
                  {isValidImageUrl(imageUrl) ? (
                    <Image 
                      source={{ uri: imageUrl }} 
                      style={styles.productImage}
                      resizeMode="contain"
                      onError={() => {
                        console.log('Image load error');
                      }}
                    />
                  ) : (
                    <Text style={styles.productImageEmoji}>{imageUrl || '🍫'}</Text>
                  )}
                </View>
              ))}
            </ScrollView>
            
            {/* Image indicators */}
            {productImages.length > 1 && (
              <View style={styles.indicatorContainer}>
                {productImages.map((_, index) => (
                  <TouchableOpacity
                    key={index}
                    style={[
                      styles.indicator,
                      { backgroundColor: index === currentImageIndex ? colors.primary : colors.textSecondary }
                    ]}
                    onPress={() => handlePageChange(index)}
                    activeOpacity={0.7}
                  />
                ))}
              </View>
            )}
          </View>

          {/* Product Info */}
          <View style={styles.infoContainer}>
            <View style={styles.productNameRow}>
              <Text style={[styles.productName, { color: colors.text }]} numberOfLines={2}>
                {product.name}
              </Text>
              <TouchableOpacity 
                style={styles.heartButton}
                onPress={() => setIsFavorite(!isFavorite)}
                activeOpacity={0.7}
              >
                <HeartIcon size={24} color={colors.primary} filled={isFavorite} />
              </TouchableOpacity>
            </View>
            <Text style={[styles.productCategoryLabel, { color: colors.textSecondary }]}>
              Category: {product.category}
            </Text>
            <View style={styles.priceRatingRow}>
              <Text style={[styles.productPrice, { color: colors.text }]}>
                ₹ {product.price} MRP
              </Text>
              <View style={styles.ratingRow}>
                <Text style={{ color: '#FFD700', fontSize: 12 }}>
                  {'★'.repeat(Math.floor(product.rating || 0))}{'☆'.repeat(5 - Math.floor(product.rating || 0))}
                </Text>
                <Text style={[styles.ratingCount, { color: colors.text }]}>
                  ({product.numReviews ? (product.numReviews >= 10000 ? '10k+' : product.numReviews) : 0})
                </Text>
              </View>
            </View>
            
            {/* View Product Details - Expandable */}
            <TouchableOpacity 
              style={styles.viewDetailsButton}
              onPress={() => setShowProductDetails(!showProductDetails)}
              activeOpacity={0.7}
            >
              <Text style={[styles.viewDetailsText, { color: colors.text }]}>
                View Product Details {showProductDetails ? '▴' : '▾'}
              </Text>
            </TouchableOpacity>
            
            {/* Expanded Product Details */}
            {showProductDetails && (
              <View style={styles.expandedDetails}>
                <Text style={[styles.productDescription, { color: colors.text }]}>
                  {product.description}
                </Text>
                
                {/* Quantity Selector */}
                <View style={styles.quantityContainer}>
                  <Text style={[styles.quantityLabel, { color: colors.text }]}>Quantity:</Text>
                  <View style={styles.quantityControls}>
                    <TouchableOpacity 
                      style={[styles.quantityButton, { backgroundColor: colors.primary }]} 
                      onPress={decrementQuantity}
                    >
                      <Text style={[styles.quantityButtonText, { color: colors.onPrimary }]}>-</Text>
                    </TouchableOpacity>
                    <Text style={[styles.quantityText, { color: colors.text }]}>{quantity}</Text>
                    <TouchableOpacity 
                      style={[styles.quantityButton, { backgroundColor: colors.primary }]} 
                      onPress={incrementQuantity}
                    >
                      <Text style={[styles.quantityButtonText, { color: colors.onPrimary }]}>+</Text>
                    </TouchableOpacity>
                  </View>
                </View>

                {/* Add to Cart Section */}
                <View style={styles.addToCartSection}>
                  {/* Stock Status */}
                  {product && (product.inStock === false || (product.stock !== undefined && product.stock <= 0)) && (
                    <View style={[styles.stockStatusContainer, { backgroundColor: colors.error + '20' }]}>
                      <Text style={[styles.stockStatusText, { color: colors.error }]}>
                        ⚠️ This product is currently out of stock
                      </Text>
                    </View>
                  )}
                  
                  <View style={styles.buttonContainer}>
                    <TouchableOpacity 
                      style={[
                        styles.addToCartButton, 
                        { 
                          backgroundColor: (product && (product.inStock === false || (product.stock !== undefined && product.stock <= 0)))
                            ? colors.textSecondary 
                            : colors.primary 
                        }
                      ]}
                      onPress={() => {
                        if (product) {
                          // Check if product is out of stock
                          if (product.inStock === false || (product.stock !== undefined && product.stock <= 0)) {
                            Toast.show({
                              type: 'info',
                              text1: 'Out of Stock',
                              text2: `${product.name} is currently out of stock`,
                              visibilityTime: 2000,
                            });
                            return;
                          }
                          
                          // Check if requested quantity exceeds available stock
                          if (product.stock !== undefined && quantity > product.stock) {
                            Toast.show({
                              type: 'info',
                              text1: 'Insufficient Stock',
                              text2: `Only ${product.stock} item(s) available`,
                              visibilityTime: 2000,
                            });
                            return;
                          }
                          
                          // Check if product is already in cart
                          const isAlreadyInCart = cartItems.some(cartItem => cartItem.id === product._id);
                          
                          if (isAlreadyInCart) {
                            Toast.show({
                              type: 'info',
                              text1: 'Already Added',
                              text2: `${product.name} is already in your cart`,
                              visibilityTime: 2000,
                            });
                            return;
                          }
                          
                          // Add item to cart with specified quantity
                          addToCart({
                            id: product._id,
                            name: product.name,
                            price: product.price,
                            image: product.image,
                          }, quantity);
                          
                          Toast.show({
                            type: 'success',
                            text1: 'Added to Cart',
                            text2: `${quantity} ${product.name}(s) added to your cart`,
                            visibilityTime: 2000,
                          });
                        }
                      }}
                      disabled={product ? (product.inStock === false || (product.stock !== undefined && product.stock <= 0)) : false}
                    >
                      <Text style={[styles.addToCartText, { color: colors.onPrimary }]}>
                        {product && (product.inStock === false || (product.stock !== undefined && product.stock <= 0))
                          ? 'Out of Stock'
                          : 'Add to Cart'}
                      </Text>
                    </TouchableOpacity>
                      
                    <TouchableOpacity 
                      style={[
                        styles.buyNowButton, 
                        { 
                          borderColor: (product && (product.inStock === false || (product.stock !== undefined && product.stock <= 0)))
                            ? colors.textSecondary 
                            : colors.primary, 
                          borderWidth: 1 
                        }
                      ]}
                      onPress={() => {
                        if (product) {
                          // Check if product is out of stock
                          if (product.inStock === false || (product.stock !== undefined && product.stock <= 0)) {
                            Toast.show({
                              type: 'info',
                              text1: 'Out of Stock',
                              text2: `${product.name} is currently out of stock`,
                              visibilityTime: 2000,
                            });
                            return;
                          }
                          
                          // Check if requested quantity exceeds available stock
                          if (product.stock !== undefined && quantity > product.stock) {
                            Toast.show({
                              type: 'info',
                              text1: 'Insufficient Stock',
                              text2: `Only ${product.stock} item(s) available`,
                              visibilityTime: 2000,
                            });
                            return;
                          }
                          
                            // Add item to cart and navigate to cart screen
                            const isAlreadyInCart = cartItems.some(cartItem => cartItem.id === product._id);
                            
                            if (!isAlreadyInCart) {
                              addToCart({
                                id: product._id,
                                name: product.name,
                                price: product.price,
                                image: product.image,
                              }, quantity);
                            }
                            
                            // Navigate to cart screen
                            navigation.navigate('Cart');
                        }
                      }}
                      disabled={product ? (product.inStock === false || (product.stock !== undefined && product.stock <= 0)) : false}
                    >
                      <Text style={[
                        styles.buyNowText, 
                        { 
                          color: (product && (product.inStock === false || (product.stock !== undefined && product.stock <= 0)))
                            ? colors.textSecondary 
                            : colors.primary 
                        }
                      ]}>
                        Buy Now
                      </Text>
                    </TouchableOpacity>
                  </View>
                </View>
              </View>
            )}
          </View>


          {/* Similar Products Section - Category-wise with View More */}
          {product && (
            <>
              {loadingRelated ? (
                <View style={styles.relatedProductsSection}>
                  <ActivityIndicator size="small" color={colors.primary} style={{ marginVertical: 20 }} />
                </View>
              ) : Object.keys(groupProductsByCategory).length === 0 ? (
                <View style={styles.relatedProductsSection}>
                  <View style={styles.noRelatedProducts}>
                    <Text style={[styles.noRelatedProductsText, { color: colors.textSecondary }]}>
                      No similar products found
                    </Text>
                  </View>
                </View>
              ) : (
                Object.entries(groupProductsByCategory).map(([categoryName, categoryProducts]) => {
                  // Show only first 3 products in horizontal scroll
                  const displayProducts = categoryProducts.slice(0, 3);
                  const hasMoreProducts = categoryProducts.length > 3;
                  
                  // Prepare data for FlatList including the "View More" button
                  const listData = [...displayProducts];
                  if (hasMoreProducts) {
                    listData.push({ _id: 'view-more', isViewMore: true, categoryName } as any);
                  }

                  return (
                    <View key={categoryName} style={styles.categorySection}>
                      <View style={styles.categorySectionHeader}>
                        <Text style={[styles.categorySectionTitle, { color: colors.text }]}>
                          {categoryName}
                        </Text>
                      </View>
                      <FlatList
                        data={listData}
                        horizontal
                        showsHorizontalScrollIndicator={false}
                        contentContainerStyle={styles.categoryProductsContainer}
                        nestedScrollEnabled={true}
                        keyExtractor={(item, index) => (item as any)._id || `item-${index}`}
                        removeClippedSubviews={true}
                        initialNumToRender={3}
                        maxToRenderPerBatch={2}
                        updateCellsBatchingPeriod={50}
                        windowSize={2}
                        getItemLayout={(data, index) => ({
                          length: 150 + 12, // card width + margin
                          offset: (150 + 12) * index,
                          index,
                        })}
                        scrollEventThrottle={16}
                        renderItem={({ item }) => {
                          if ((item as any).isViewMore) {
                            return (
                              <TouchableOpacity
                                style={[styles.viewMoreButton, { borderColor: colors.primary }]}
                                onPress={() => navigation.navigate('CategoryProducts', { category: (item as any).categoryName })}
                                activeOpacity={0.7}
                              >
                                <Text style={[styles.viewMoreText, { color: colors.primary }]}>
                                  View More{'\n'}Products
                                </Text>
                                <Text style={[styles.viewMoreArrow, { color: colors.primary }]}>
                                  {'>>'}
                                </Text>
                              </TouchableOpacity>
                            );
                          }
                          return <HorizontalProductCard item={item as Product} />;
                        }}
                      />
                    </View>
                  );
                })
              )}
            </>
          )}
        </ScrollView>
      </View>
    </ThemedLayout>
  );
};

const styles = StyleSheet.create({
  container: {
    flex: 1,
  },
  scrollContent: {
    flexGrow: 1,
    paddingBottom: 20,
  },
  loadingContainer: {
    flex: 1,
    justifyContent: 'center',
    alignItems: 'center',
    paddingVertical: 50,
  },
  loadingText: {
    marginTop: 16,
    fontSize: 16,
    fontFamily: 'Alexandria-Regular',
  },
  carouselContainer: {
    marginTop: 5,
    marginBottom: 8,
    marginHorizontal: 20,
  },
  imageScrollView: {
    flexGrow: 0,
  },
  imageScrollContent: {
    alignItems: 'center',
  },
  imageContainer: {
    height: 240,
    backgroundColor: '#E91E63',
    justifyContent: 'center',
    alignItems: 'center',
    overflow: 'hidden',
    borderRadius: 20,
    marginHorizontal: 0,
  },
  productImage: {
    width: '100%',
    height: '100%',
    resizeMode: 'contain',
  },
  productImageEmoji: {
    fontSize: 100,
    fontFamily: 'Alexandria-Regular',
  },
  indicatorContainer: {
    flexDirection: 'row',
    justifyContent: 'center',
    paddingVertical: 6,
  },
  indicator: {
    width: 6,
    height: 6,
    borderRadius: 3,
    marginHorizontal: 4,
  },
  infoContainer: {
    marginHorizontal: 20,
    marginTop: 5,
    marginBottom: 15,
    padding: 14,
    borderRadius: 16,
    backgroundColor: '#F5F5F5',
    elevation: 2,
    shadowColor: '#000',
    shadowOffset: { width: 0, height: 1 },
    shadowOpacity: 0.1,
    shadowRadius: 2,
  },
  productNameRow: {
    flexDirection: 'row',
    alignItems: 'flex-start',
    justifyContent: 'space-between',
    marginBottom: 4,
  },
  productName: {
    fontSize: 16,
    fontWeight: 'bold',
    flex: 1,
    marginRight: 8,
    fontFamily: 'Alexandria-Bold',
    lineHeight: 20,
  },
  heartButton: {
    padding: 5,
    marginTop: 2,
  },
  productCategoryLabel: {
    fontSize: 11,
    marginBottom: 6,
    fontFamily: 'Alexandria-Regular',
  },
  priceRatingRow: {
    flexDirection: 'row',
    alignItems: 'center',
    justifyContent: 'space-between',
    marginBottom: 6,
  },
  productPrice: {
    fontSize: 13,
    fontWeight: '500',
    fontFamily: 'Alexandria-Medium',
  },
  ratingRow: {
    flexDirection: 'row',
    alignItems: 'center',
  },
  ratingCount: {
    fontSize: 11,
    marginLeft: 3,
    fontFamily: 'Alexandria-Regular',
  },
  viewDetailsButton: {
    marginTop: 4,
    paddingVertical: 2,
  },
  viewDetailsText: {
    fontSize: 11,
    fontFamily: 'Alexandria-Regular',
  },
  expandedDetails: {
    marginTop: 10,
  },
  productDescription: {
    fontSize: 16,
    lineHeight: 24,
    marginBottom: 20,
    fontFamily: 'Alexandria-Regular',
  },
  quantityContainer: {
    flexDirection: 'row',
    alignItems: 'center',
    justifyContent: 'space-between',
    padding: 20,
  },
  quantityLabel: {
    fontSize: 16,
    fontFamily: 'Alexandria-Regular',
  },
  quantityControls: {
    flexDirection: 'row',
    alignItems: 'center',
  },
  quantityButton: {
    width: 40,
    height: 40,
    borderRadius: 20,
    justifyContent: 'center',
    alignItems: 'center',
  },
  quantityButtonText: {
    fontSize: 24,
    fontWeight: 'bold',
    fontFamily: 'Alexandria-Bold',
  },
  quantityText: {
    fontSize: 16,
    marginHorizontal: 10,
    fontFamily: 'Alexandria-Regular',
  },
  addToCartSection: {
    padding: 20,
    paddingRight: 25,
    paddingBottom: 10,
  },
  buyNowSection: {
    paddingHorizontal: 20,
    paddingBottom: 20,
  },
  stockStatusContainer: {
    padding: 12,
    borderRadius: 8,
    marginBottom: 10,
    alignItems: 'center',
  },
  stockStatusText: {
    fontSize: 14,
    fontWeight: '600',
    fontFamily: 'Alexandria-SemiBold',
  },
  buttonContainer: {
    flexDirection: 'row',
    justifyContent: 'space-between',
    gap: 12,
  },
  addToCartButton: {
    flex: 1,
    padding: 15,
    borderRadius: 8,
    alignItems: 'center',
  },
  addToCartText: {
    fontSize: 16,
    fontWeight: 'bold',
    fontFamily: 'Alexandria-Bold',
  },
  buyNowButton: {
    flex: 1,
    padding: 15,
    borderRadius: 8,
    alignItems: 'center',
    backgroundColor: 'transparent',
  },
  buyNowText: {
    fontSize: 16,
    fontWeight: 'bold',
    fontFamily: 'Alexandria-Bold',
  },
  commentsSection: {
    padding: 20,
    paddingTop: 0,
  },
  sectionTitle: {
    fontSize: 20,
    fontWeight: 'bold',
    marginBottom: 15,
    fontFamily: 'Alexandria-Bold',
  },
  commentContainer: {
    padding: 15,
    borderRadius: 8,
    marginBottom: 10,
  },
  commentHeader: {
    flexDirection: 'row',
    justifyContent: 'space-between',
    alignItems: 'center',
    marginBottom: 5,
  },
  commentUser: {
    fontSize: 16,
    fontWeight: 'bold',
    fontFamily: 'Alexandria-Bold',
  },
  commentDate: {
    fontSize: 12,
    marginLeft: 10,
    fontFamily: 'Alexandria-Regular',
  },
  ratingContainer: {
    flexDirection: 'row',
    alignItems: 'center',
  },
  commentText: {
    fontSize: 14,
    lineHeight: 20,
    fontFamily: 'Alexandria-Regular',
  },
  reviewActions: {
    flexDirection: 'row',
    justifyContent: 'flex-end',
    marginTop: 10,
    gap: 10,
  },
  editReviewButton: {
    paddingHorizontal: 12,
    paddingVertical: 6,
    borderRadius: 6,
    borderWidth: 1,
  },
  editReviewButtonText: {
    fontSize: 12,
    fontWeight: '600',
    fontFamily: 'Alexandria-SemiBold',
  },
  deleteReviewButton: {
    paddingHorizontal: 12,
    paddingVertical: 6,
    borderRadius: 6,
    borderWidth: 1,
  },
  deleteReviewButtonText: {
    fontSize: 12,
    fontWeight: '600',
    fontFamily: 'Alexandria-SemiBold',
  },
  showMoreButton: {
    alignItems: 'center',
    padding: 10,
  },
  showMoreText: {
    fontSize: 16,
    fontWeight: 'bold',
    fontFamily: 'Alexandria-Bold',
  },
  addReviewButton: {
    padding: 10,
    borderRadius: 8,
    alignItems: 'center',
    marginTop: 10,
  },
  addReviewText: {
    fontSize: 16,
    fontWeight: 'bold',
    fontFamily: 'Alexandria-Bold',
  },
  modalOverlay: {
    flex: 1,
    backgroundColor: 'rgba(0, 0, 0, 0.5)',
    justifyContent: 'center',
    alignItems: 'center',
  },
  modalContainer: {
    width: '85%',
    maxWidth: 400,
    borderRadius: 20,
    padding: 25,
    alignItems: 'center',
    elevation: 10,
    shadowColor: '#000',
    shadowOffset: { width: 0, height: 4 },
    shadowOpacity: 0.3,
    shadowRadius: 8,
  },
  modalIconContainer: {
    width: 80,
    height: 80,
    borderRadius: 40,
    backgroundColor: 'rgba(255, 215, 0, 0.1)',
    justifyContent: 'center',
    alignItems: 'center',
    marginBottom: 20,
  },
  modalIcon: {
    fontSize: 40,
  },
  modalTitle: {
    fontSize: 24,
    fontWeight: 'bold',
    marginBottom: 20,
    textAlign: 'center',
    fontFamily: 'Alexandria-Bold',
  },
  starRatingContainer: {
    flexDirection: 'row',
    justifyContent: 'center',
    marginBottom: 15,
  },
  star: {
    fontSize: 30,
  },
  ratingText: {
    fontSize: 14,
    fontFamily: 'Alexandria-Regular',
  },
  reviewInput: {
    borderWidth: 1,
    borderRadius: 8,
    padding: 10,
    marginBottom: 15,
  },
  modalButtonContainer: {
    flexDirection: 'row',
    width: '100%',
    justifyContent: 'space-between',
    gap: 10,
    marginTop: 10,
  },
  modalCancelButton: {
    flex: 1,
    paddingVertical: 14,
    paddingHorizontal: 20,
    borderRadius: 12,
    alignItems: 'center',
    borderWidth: 1,
  },
  modalCancelButtonText: {
    fontSize: 16,
    fontWeight: '600',
    fontFamily: 'Alexandria-SemiBold',
  },
  modalConfirmButton: {
    flex: 1,
    paddingVertical: 14,
    paddingHorizontal: 20,
    borderRadius: 12,
    alignItems: 'center',
  },
  modalConfirmButtonText: {
    fontSize: 16,
    fontWeight: 'bold',
    fontFamily: 'Alexandria-Bold',
  },
  header: {
    flexDirection: 'row',
    alignItems: 'center',
    justifyContent: 'space-between',
    paddingVertical: 15,
    paddingHorizontal: 10,
    marginBottom: 10,
    borderBottomWidth: 1,
  },
  backButton: {
    padding: 5,
    minWidth: 40,
    alignItems: 'center',
    justifyContent: 'center',
  },
  headerSpacer: {
    flex: 1,
  },
  searchButton: {
    padding: 10,
    minWidth: 40,
    alignItems: 'center',
    justifyContent: 'center',
  },
  relatedProductsSection: {
    marginBottom: 20,
  },
  // Horizontal Product Card Styles (matching HomeScreen)
  horizontalProductCard: {
    width: 150,
    marginRight: 12,
    marginVertical: 4,
    borderRadius: 16,
    padding: 10,
    backgroundColor: '#FFFFFF',
    elevation: 3,
    shadowColor: '#000',
    shadowOffset: { width: 0, height: 2 },
    shadowOpacity: 0.12,
    shadowRadius: 4,
    overflow: 'visible',
  },
  horizontalProductImageContainer: {
    width: '100%',
    height: 110,
    borderRadius: 12,
    backgroundColor: 'rgba(107, 70, 193, 0.05)',
    justifyContent: 'center',
    alignItems: 'center',
    marginBottom: 10,
    overflow: 'hidden',
  },
  horizontalProductImage: {
    width: '100%',
    height: '100%',
    borderRadius: 12,
  },
  horizontalProductImageEmoji: {
    fontSize: 40,
    fontFamily: 'Alexandria-Regular',
  },
  horizontalProductInfo: {
    flex: 1,
  },
  horizontalProductNameRow: {
    flexDirection: 'row',
    justifyContent: 'space-between',
    alignItems: 'flex-start',
    marginBottom: 3,
  },
  horizontalProductName: {
    fontSize: 13,
    fontWeight: 'bold',
    flex: 1,
    marginRight: 6,
    fontFamily: 'Alexandria-Bold',
  },
  horizontalProductCategory: {
    fontSize: 11,
    marginBottom: 5,
    fontFamily: 'Alexandria-Regular',
  },
  horizontalProductRating: {
    flexDirection: 'row',
    marginBottom: 6,
  },
  ratingStars: {
    fontSize: 11,
  },
  horizontalProductPriceRow: {
    flexDirection: 'row',
    justifyContent: 'space-between',
    alignItems: 'center',
  },
  horizontalProductPrice: {
    fontSize: 13,
    fontWeight: 'bold',
    fontFamily: 'Alexandria-Bold',
  },
  horizontalAddButton: {
    width: 26,
    height: 26,
    borderRadius: 13,
    justifyContent: 'center',
    alignItems: 'center',
    elevation: 2,
    shadowColor: '#000',
    shadowOffset: { width: 0, height: 1 },
    shadowOpacity: 0.2,
    shadowRadius: 2,
  },
  horizontalAddButtonText: {
    fontSize: 16,
    fontWeight: 'bold',
    fontFamily: 'Alexandria-Bold',
    lineHeight: 16,
  },
  horizontalLikeButton: {
    padding: 2,
  },
  categoryProductsContainer: {
    paddingHorizontal: 20,
    paddingRight: 5,
    paddingVertical: 4,
    alignItems: 'center',
  },
  reviewsHeader: {
    flexDirection: 'row',
    justifyContent: 'space-between',
    alignItems: 'center',
    marginBottom: 15,
  },
  noReviewsContainer: {
    padding: 20,
    alignItems: 'center',
  },
  noReviewsText: {
    fontSize: 14,
    textAlign: 'center',
    fontFamily: 'Alexandria-Regular',
  },
  charCount: {
    fontSize: 12,
    textAlign: 'right',
    marginTop: 5,
    fontFamily: 'Alexandria-Regular',
  },
  loginPrompt: {
    padding: 15,
    borderRadius: 8,
    alignItems: 'center',
    marginTop: 10,
  },
  loginPromptText: {
    fontSize: 14,
    textAlign: 'center',
    fontFamily: 'Alexandria-Regular',
  },
  noRelatedProducts: {
    padding: 20,
    alignItems: 'center',
  },
  noRelatedProductsText: {
    fontSize: 14,
    fontStyle: 'italic',
    fontFamily: 'Alexandria-Regular',
  },
  // Category Section Styles
  categorySection: {
    marginBottom: 20,
  },
  categorySectionHeader: {
    marginHorizontal: 20,
    marginBottom: 12,
  },
  categorySectionTitle: {
    fontSize: 18,
    fontWeight: 'bold',
    fontFamily: 'Alexandria-Bold',
  },
  viewMoreButton: {
    width: 150,
    height: 150,
    borderRadius: 75,
    borderWidth: 2,
    justifyContent: 'center',
    alignItems: 'center',
    marginRight: 12,
    padding: 12,
    backgroundColor: '#FFFFFF',
  },
  viewMoreText: {
    fontSize: 13,
    fontWeight: 'bold',
    textAlign: 'center',
    marginBottom: 4,
    fontFamily: 'Alexandria-Bold',
    lineHeight: 16,
  },
  viewMoreArrow: {
    fontSize: 14,
    fontWeight: 'bold',
    fontFamily: 'Alexandria-Bold',
  },
});

export default ProductDetailScreen;