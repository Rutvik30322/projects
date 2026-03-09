import React, { useState, useEffect, useCallback, useMemo } from 'react';
import {
  View,
  Text,
  StyleSheet,
  FlatList,
  TouchableOpacity,
  Image,
  ScrollView,
  Dimensions,
  ActivityIndicator,
  Modal,
} from 'react-native';
import { useTheme } from '../context/ThemeContext';
import { useCart } from '../context/CartContext';
import ThemedLayout from '../components/ThemedLayout';
import ProductHeader from '../components/ProductHeader';
import HeartIcon from '../components/HeartIcon';
import FilterButtonIcon from '../components/FilterButtonIcon';
import SortByButtonIcon from '../components/SortByButtonIcon';
import RatingButtonIcon from '../components/RatingButtonIcon';
import StockButtonIcon from '../components/StockButtonIcon';
import PriceRangeButtonIcon from '../components/PriceRangeButtonIcon';
import BrandSelectionIndicator from '../components/BrandSelectionIndicator';
import Toast from 'react-native-toast-message';
import productService, { Product } from '../services/productService';

const screenWidth = Dimensions.get('window').width;
const brandSidebarWidth = 80;
const gridPadding = 20; // 10px on each side
const cardMargins = 15; // 5px left + 5px between cards + 5px right
const productCardWidth = (screenWidth - brandSidebarWidth - gridPadding - cardMargins) / 2;

interface Brand {
  name: string;
  logo?: string;
}

const CategoryProductsScreen: React.FC<{ route: any; navigation: any }> = ({
  route,
  navigation,
}) => {
  const { category } = route.params || {};
  const { colors, theme } = useTheme();
  const { addToCart } = useCart();
  const [loading, setLoading] = useState(true);
  const [products, setProducts] = useState<Product[]>([]);
  const [allProducts, setAllProducts] = useState<Product[]>([]);
  const [brands, setBrands] = useState<Brand[]>([]);
  const [selectedBrand, setSelectedBrand] = useState<string | null>(null);
  const [likedProducts, setLikedProducts] = useState<Set<string>>(new Set());

  // Filter states
  const [sortBy, setSortBy] = useState<string>('None');
  const [ratingFilter, setRatingFilter] = useState<string>('All');
  const [stockFilter, setStockFilter] = useState<string>('All');
  const [priceRangeFilter, setPriceRangeFilter] = useState<string>('All');
  const [showFilterModal, setShowFilterModal] = useState(false);
  const [showSortModal, setShowSortModal] = useState(false);
  const [showRatingModal, setShowRatingModal] = useState(false);
  const [showStockModal, setShowStockModal] = useState(false);
  const [showPriceModal, setShowPriceModal] = useState(false);

  useEffect(() => {
    loadProducts();
  }, [category]);

  useEffect(() => {
    if (allProducts.length > 0) {
      applyFilters();
      extractBrands();
    }
  }, [allProducts, selectedBrand, sortBy, ratingFilter, stockFilter, priceRangeFilter]);

  const loadProducts = async () => {
    try {
      setLoading(true);
      const response = await productService.getAllProducts({ limit: 'all' });
      let productsList: Product[] = [];

      if (response?.data?.data?.products) {
        productsList = response.data.data.products;
      } else if (response?.data?.products) {
        productsList = response.data.products;
      }

      // Filter by category if provided
      if (category) {
        productsList = productsList.filter((p) => p.category === category);
      }

      setAllProducts(productsList);
    } catch (error) {
      console.error('Failed to load products:', error);
      Toast.show({
        type: 'error',
        text1: 'Error',
        text2: 'Failed to load products',
        visibilityTime: 2000,
      });
    } finally {
      setLoading(false);
    }
  };

  const extractBrands = () => {
    const brandSet = new Set<string>();
    allProducts.forEach((product) => {
      const brandName = product.name.split(' ')[0] || 'Other';
      brandSet.add(brandName);
    });
    const brandList: Brand[] = Array.from(brandSet).map((name) => ({ name }));
    setBrands(brandList);
    // Select first brand by default
    if (brandList.length > 0 && selectedBrand === null) {
      setSelectedBrand(brandList[0].name);
    }
  };

  const applyFilters = () => {
    let filtered = [...allProducts];

    // Brand filter
    if (selectedBrand) {
      filtered = filtered.filter((product) => product.name.startsWith(selectedBrand));
    }

    // Rating filter
    if (ratingFilter !== 'All') {
      const minRating = parseFloat(ratingFilter);
      filtered = filtered.filter((product) => (product.rating || 0) >= minRating);
    }

    // Stock filter
    if (stockFilter !== 'All') {
      if (stockFilter === 'In Stock') {
        filtered = filtered.filter(
          (product) => product.inStock === true && (product.stock === undefined || product.stock > 0)
        );
      } else if (stockFilter === 'Out of Stock') {
        filtered = filtered.filter(
          (product) => product.inStock === false || (product.stock !== undefined && product.stock <= 0)
        );
      }
    }

    // Price range filter
    if (priceRangeFilter !== 'All') {
      const [min, max] = priceRangeFilter.split('-').map(Number);
      filtered = filtered.filter((product) => {
        if (max) {
          return product.price >= min && product.price <= max;
        }
        return product.price >= min;
      });
    }

    // Sort
    if (sortBy === 'Price Low to High') {
      filtered.sort((a, b) => a.price - b.price);
    } else if (sortBy === 'Price High to Low') {
      filtered.sort((a, b) => b.price - a.price);
    } else if (sortBy === 'Rating') {
      filtered.sort((a, b) => (b.rating || 0) - (a.rating || 0));
    } else if (sortBy === 'Name') {
      filtered.sort((a, b) => a.name.localeCompare(b.name));
    }

    setProducts(filtered);
  };

  const isValidImageUrl = (url: string | undefined): boolean => {
    if (!url) return false;
    return url.startsWith('http://') || url.startsWith('https://');
  };

  const toggleFavorite = (productId: string) => {
    setLikedProducts((prev) => {
      const newSet = new Set(prev);
      if (newSet.has(productId)) {
        newSet.delete(productId);
      } else {
        newSet.add(productId);
      }
      return newSet;
    });
  };

  const handleAddToCart = (item: Product) => {
    if (item.inStock === false || (item.stock !== undefined && item.stock <= 0)) {
      Toast.show({
        type: 'info',
        text1: 'Out of Stock',
        text2: `${item.name} is currently out of stock`,
        visibilityTime: 2000,
      });
      return;
    }

    addToCart({
      id: item._id,
      name: item.name,
      price: item.price,
      image: item.image,
    });

    Toast.show({
      type: 'success',
      text1: 'Added to Cart',
      text2: `${item.name} added to your cart`,
      visibilityTime: 2000,
    });
  };

  const handleProductPress = (productId: string) => {
    navigation.navigate('ProductDetailNew', { productId });
  };

  const renderProduct = ({ item }: { item: Product }) => {
    const isLiked = likedProducts.has(item._id);
    const imageUrl = isValidImageUrl(item.image) ? item.image : null;
    const ratingStars = '⭐'.repeat(Math.floor(item.rating || 0));

    const handleAddToCartPress = (e: any) => {
      e.stopPropagation();
      handleAddToCart(item);
    };

    const handleLikePress = (e: any) => {
      e.stopPropagation();
      toggleFavorite(item._id);
    };

    return (
      <TouchableOpacity
        style={[styles.productCard, { backgroundColor: colors.surface }]}
        onPress={() => handleProductPress(item._id)}
        activeOpacity={0.7}
      >
        <View style={styles.productImageContainer}>
          {imageUrl ? (
            <Image source={{ uri: imageUrl }} style={styles.productImage} resizeMode="contain" />
          ) : (
            <Text style={styles.productImageEmoji}>{item.image || '🍫'}</Text>
          )}
        </View>
        <View style={styles.productInfo}>
          <View style={styles.productNameRow}>
            <Text style={[styles.productName, { color: colors.text }]} numberOfLines={1}>
              {item.name}
            </Text>
            <TouchableOpacity
              style={[styles.addButton, { backgroundColor: '#381230' }]}
              onPress={handleAddToCartPress}
              activeOpacity={0.7}
            >
              <Text style={styles.addButtonText}>+</Text>
            </TouchableOpacity>
          </View>
          <Text style={[styles.productCategory, { color: colors.textSecondary }]}>
            {item.category || 'Products'}
          </Text>
          <View style={styles.ratingContainer}>
            <Text style={styles.ratingStars}>{ratingStars}</Text>
          </View>
          <View style={styles.productPriceRow}>
            <Text style={[styles.productPrice, { color: colors.primary }]}>
              MRP ₹ {item.price}
            </Text>
            <TouchableOpacity
              style={styles.heartButton}
              onPress={handleLikePress}
              activeOpacity={0.7}
            >
              <HeartIcon size={16} color="#381230" filled={isLiked} />
            </TouchableOpacity>
          </View>
        </View>
      </TouchableOpacity>
    );
  };

  return (
    <ThemedLayout edges={['top']}>
      <View style={[styles.container, { backgroundColor: colors.background }]}>
        {/* Header */}
        <ProductHeader
          title={category || 'Chocolates'}
          onBackPress={() => navigation.goBack()}
          onSearchPress={() => {}}
        />

        {/* Main Content Area */}
        <View style={styles.mainContent}>
          {/* Left Sidebar - Brand Filters */}
          <View style={styles.brandSidebarContainer} pointerEvents="box-none">
            <ScrollView
              style={styles.brandSidebar}
              showsVerticalScrollIndicator={true}
              contentContainerStyle={styles.brandSidebarContent}
              nestedScrollEnabled={true}
              bounces={false}
              scrollEnabled={true}
              directionalLockEnabled={true}
              keyboardShouldPersistTaps="handled"
              scrollEventThrottle={16}
              overScrollMode="never"
              alwaysBounceVertical={false}
              scrollsToTop={false}
            >
            {brands.map((brand, index) => (
              <TouchableOpacity
                key={index}
                style={styles.brandItem}
                onPress={() => setSelectedBrand(brand.name)}
                activeOpacity={0.7}
              >
                <View style={styles.brandLogo}>
                  <Text style={styles.brandLogoText}>{brand.name.charAt(0)}</Text>
                </View>
                <Text style={styles.brandName} numberOfLines={1}>
                  {brand.name}
                </Text>
                {selectedBrand === brand.name && (
                  <View style={styles.brandSelectionIndicator}>
                    <BrandSelectionIndicator width={5} height={44} color="#381230" />
                  </View>
                )}
              </TouchableOpacity>
            ))}
            </ScrollView>
          </View>

          {/* Right Section - Filters and Products */}
          <View style={styles.rightSection}>
            {/* Filter/Sort Bar */}
            <View style={styles.filterBarContainer}>
              <ScrollView
                horizontal
                showsHorizontalScrollIndicator={true}
                style={styles.filterBar}
                contentContainerStyle={styles.filterBarContent}
                bounces={false}
                directionalLockEnabled={true}
                scrollEnabled={true}
                nestedScrollEnabled={true}
              >
                <TouchableOpacity
                  style={styles.filterButton}
                  onPress={() => setShowFilterModal(true)}
                  activeOpacity={0.7}
                >
                  <FilterButtonIcon size={60} color={colors.text} />
                </TouchableOpacity>
                <TouchableOpacity
                  style={styles.filterButton}
                  onPress={() => setShowSortModal(true)}
                  activeOpacity={0.7}
                >
                  <SortByButtonIcon size={60} color={colors.text} />
                </TouchableOpacity>
                <TouchableOpacity
                  style={styles.filterButton}
                  onPress={() => setShowRatingModal(true)}
                  activeOpacity={0.7}
                >
                  <RatingButtonIcon size={60} color={colors.text} />
                </TouchableOpacity>
                <TouchableOpacity
                  style={styles.filterButton}
                  onPress={() => setShowStockModal(true)}
                  activeOpacity={0.7}
                >
                  <StockButtonIcon size={60} color={colors.text} />
                </TouchableOpacity>
                <TouchableOpacity
                  style={styles.filterButton}
                  onPress={() => setShowPriceModal(true)}
                  activeOpacity={0.7}
                >
                  <PriceRangeButtonIcon size={60} color={colors.text} />
                </TouchableOpacity>
              </ScrollView>
            </View>

            {/* Product Grid */}
            {loading ? (
            <View style={styles.loadingContainer}>
              <ActivityIndicator size="large" color={colors.primary} />
              <Text style={[styles.loadingText, { color: colors.textSecondary }]}>
                Loading products...
              </Text>
            </View>
          ) : (
            <FlatList
              data={products}
              renderItem={renderProduct}
              keyExtractor={(item) => item._id}
              numColumns={2}
              contentContainerStyle={styles.productGrid}
              showsVerticalScrollIndicator={false}
              nestedScrollEnabled={true}
              scrollEnabled={true}
              bounces={false}
              ListEmptyComponent={
                <View style={styles.emptyContainer}>
                  <Text style={[styles.emptyText, { color: colors.text }]}>
                    No products found
                  </Text>
                </View>
              }
            />
          )}
          </View>
        </View>

        {/* Filter Modals */}
        {/* Filter Modal */}
        <Modal
          visible={showFilterModal}
          transparent={true}
          animationType="slide"
          onRequestClose={() => setShowFilterModal(false)}
        >
          <TouchableOpacity
            style={styles.modalOverlay}
            activeOpacity={1}
            onPress={() => setShowFilterModal(false)}
          >
            <View style={[styles.modalContent, { backgroundColor: colors.surface }]}>
              <ScrollView
                showsVerticalScrollIndicator={true}
                contentContainerStyle={styles.modalScrollContent}
              >
                <Text style={[styles.modalTitle, { color: colors.text }]}>Filter</Text>
                
                {/* Sort By Section */}
                <Text style={[styles.modalSectionTitle, { color: colors.text }]}>Sort By</Text>
                {['None', 'Price Low to High', 'Price High to Low', 'Rating', 'Name'].map((sort) => (
                  <TouchableOpacity
                    key={sort}
                    style={[
                      styles.modalOption,
                      sortBy === sort && { backgroundColor: colors.primary + '20' },
                    ]}
                    onPress={() => {
                      setSortBy(sort);
                    }}
                  >
                    <Text style={[styles.modalOptionText, { color: colors.text }]}>{sort}</Text>
                  </TouchableOpacity>
                ))}

                {/* Rating Section */}
                <Text style={[styles.modalSectionTitle, { color: colors.text, marginTop: 15 }]}>Rating</Text>
                {['All', '4', '3', '2', '1'].map((rating) => (
                  <TouchableOpacity
                    key={rating}
                    style={[
                      styles.modalOption,
                      ratingFilter === rating && { backgroundColor: colors.primary + '20' },
                    ]}
                    onPress={() => {
                      setRatingFilter(rating);
                    }}
                  >
                    <Text style={[styles.modalOptionText, { color: colors.text }]}>
                      {rating === 'All' ? 'All Ratings' : `⭐ ${rating}+ Stars`}
                    </Text>
                  </TouchableOpacity>
                ))}

                {/* Stock Section */}
                <Text style={[styles.modalSectionTitle, { color: colors.text, marginTop: 15 }]}>Stock</Text>
                {['All', 'In Stock', 'Out of Stock'].map((stock) => (
                  <TouchableOpacity
                    key={stock}
                    style={[
                      styles.modalOption,
                      stockFilter === stock && { backgroundColor: colors.primary + '20' },
                    ]}
                    onPress={() => {
                      setStockFilter(stock);
                    }}
                  >
                    <Text style={[styles.modalOptionText, { color: colors.text }]}>{stock}</Text>
                  </TouchableOpacity>
                ))}

                {/* Price Range Section */}
                <Text style={[styles.modalSectionTitle, { color: colors.text, marginTop: 15 }]}>Price Range</Text>
                {['All', '0-100', '100-500', '500-1000', '1000-'].map((range) => (
                  <TouchableOpacity
                    key={range}
                    style={[
                      styles.modalOption,
                      priceRangeFilter === range && { backgroundColor: colors.primary + '20' },
                    ]}
                    onPress={() => {
                      setPriceRangeFilter(range);
                    }}
                  >
                    <Text style={[styles.modalOptionText, { color: colors.text }]}>
                      {range === 'All' ? 'All Prices' : `₹ ${range}`}
                    </Text>
                  </TouchableOpacity>
                ))}

                {/* Apply Button */}
                <TouchableOpacity
                  style={[styles.applyButton, { backgroundColor: colors.primary }]}
                  onPress={() => setShowFilterModal(false)}
                  activeOpacity={0.7}
                >
                  <Text style={[styles.applyButtonText, { color: '#FFFFFF' }]}>Apply Filters</Text>
                </TouchableOpacity>
              </ScrollView>
            </View>
          </TouchableOpacity>
        </Modal>

        {/* Sort By Modal */}
        <Modal
          visible={showSortModal}
          transparent={true}
          animationType="slide"
          onRequestClose={() => setShowSortModal(false)}
        >
          <TouchableOpacity
            style={styles.modalOverlay}
            activeOpacity={1}
            onPress={() => setShowSortModal(false)}
          >
            <View style={[styles.modalContent, { backgroundColor: colors.surface }]}>
              <Text style={[styles.modalTitle, { color: colors.text }]}>Sort By</Text>
              {['None', 'Price Low to High', 'Price High to Low', 'Rating', 'Name'].map((sort) => (
                <TouchableOpacity
                  key={sort}
                  style={[
                    styles.modalOption,
                    sortBy === sort && { backgroundColor: colors.primary + '20' },
                  ]}
                  onPress={() => {
                    setSortBy(sort);
                    setShowSortModal(false);
                  }}
                >
                  <Text style={[styles.modalOptionText, { color: colors.text }]}>{sort}</Text>
                </TouchableOpacity>
              ))}
            </View>
          </TouchableOpacity>
        </Modal>

        {/* Rating Modal */}
        <Modal
          visible={showRatingModal}
          transparent={true}
          animationType="slide"
          onRequestClose={() => setShowRatingModal(false)}
        >
          <TouchableOpacity
            style={styles.modalOverlay}
            activeOpacity={1}
            onPress={() => setShowRatingModal(false)}
          >
            <View style={[styles.modalContent, { backgroundColor: colors.surface }]}>
              <Text style={[styles.modalTitle, { color: colors.text }]}>Rating</Text>
              {['All', '4', '3', '2', '1'].map((rating) => (
                <TouchableOpacity
                  key={rating}
                  style={[
                    styles.modalOption,
                    ratingFilter === rating && { backgroundColor: colors.primary + '20' },
                  ]}
                  onPress={() => {
                    setRatingFilter(rating);
                    setShowRatingModal(false);
                  }}
                >
                  <Text style={[styles.modalOptionText, { color: colors.text }]}>
                    {rating === 'All' ? 'All Ratings' : `⭐ ${rating}+ Stars`}
                  </Text>
                </TouchableOpacity>
              ))}
            </View>
          </TouchableOpacity>
        </Modal>

        {/* Stock Modal */}
        <Modal
          visible={showStockModal}
          transparent={true}
          animationType="slide"
          onRequestClose={() => setShowStockModal(false)}
        >
          <TouchableOpacity
            style={styles.modalOverlay}
            activeOpacity={1}
            onPress={() => setShowStockModal(false)}
          >
            <View style={[styles.modalContent, { backgroundColor: colors.surface }]}>
              <Text style={[styles.modalTitle, { color: colors.text }]}>Stock</Text>
              {['All', 'In Stock', 'Out of Stock'].map((stock) => (
                <TouchableOpacity
                  key={stock}
                  style={[
                    styles.modalOption,
                    stockFilter === stock && { backgroundColor: colors.primary + '20' },
                  ]}
                  onPress={() => {
                    setStockFilter(stock);
                    setShowStockModal(false);
                  }}
                >
                  <Text style={[styles.modalOptionText, { color: colors.text }]}>{stock}</Text>
                </TouchableOpacity>
              ))}
            </View>
          </TouchableOpacity>
        </Modal>

        {/* Price Range Modal */}
        <Modal
          visible={showPriceModal}
          transparent={true}
          animationType="slide"
          onRequestClose={() => setShowPriceModal(false)}
        >
          <TouchableOpacity
            style={styles.modalOverlay}
            activeOpacity={1}
            onPress={() => setShowPriceModal(false)}
          >
            <View style={[styles.modalContent, { backgroundColor: colors.surface }]}>
              <Text style={[styles.modalTitle, { color: colors.text }]}>Price Range</Text>
              {['All', '0-100', '100-500', '500-1000', '1000-'].map((range) => (
                <TouchableOpacity
                  key={range}
                  style={[
                    styles.modalOption,
                    priceRangeFilter === range && { backgroundColor: colors.primary + '20' },
                  ]}
                  onPress={() => {
                    setPriceRangeFilter(range);
                    setShowPriceModal(false);
                  }}
                >
                  <Text style={[styles.modalOptionText, { color: colors.text }]}>
                    {range === 'All' ? 'All Prices' : `₹ ${range}`}
                  </Text>
                </TouchableOpacity>
              ))}
            </View>
          </TouchableOpacity>
        </Modal>
      </View>
    </ThemedLayout>
  );
};

const styles = StyleSheet.create({
  container: {
    flex: 1,
  },
  filterBarContainer: {
    borderBottomWidth: 1,
    borderBottomColor: 'transparent',
  },
  filterBar: {
    maxHeight: 80,
  },
  filterBarContent: {
    paddingHorizontal: 15,
    paddingVertical: 10,
    alignItems: 'center',
    flexGrow: 1,
  },
  filterButton: {
    marginRight: 10,
  },
  mainContent: {
    flex: 1,
    flexDirection: 'row',
  },
  brandSidebarContainer: {
    width: 80,
    flexShrink: 0,
    overflow: 'hidden',
    borderRightWidth: 1,
    borderRightColor: '#D9D9D9',
    backgroundColor: '#D9D9D9',
  },
  rightSection: {
    flex: 1,
    flexDirection: 'column',
  },
  brandSidebar: {
    flex: 1,
    backgroundColor: '#D9D9D9',
  },
  brandSidebarContent: {
    paddingTop: 0,
    paddingBottom: 10,
    paddingHorizontal: 5,
    backgroundColor: '#D9D9D9',
  },
  brandItem: {
    alignItems: 'center',
    marginBottom: 15,
    paddingVertical: 8,
    paddingHorizontal: 8,
    borderRadius: 8,
    position: 'relative',
  },
  brandLogo: {
    width: 55,
    height: 55,
    borderRadius: 27.5,
    justifyContent: 'center',
    alignItems: 'center',
    marginBottom: 6,
    backgroundColor: '#FFFFFF',
    elevation: 1,
    shadowColor: '#000',
    shadowOffset: { width: 0, height: 1 },
    shadowOpacity: 0.1,
    shadowRadius: 2,
  },
  brandSelectionIndicator: {
    position: 'absolute',
    right: -5,
    top: '50%',
    marginTop: -22,
    alignItems: 'center',
    justifyContent: 'center',
  },
  brandLogoText: {
    fontSize: 20,
    fontWeight: 'bold',
    color: '#381230',
    fontFamily: 'Alexandria-Bold',
  },
  brandName: {
    fontSize: 11,
    textAlign: 'center',
    color: '#381230',
    fontFamily: 'Alexandria-Regular',
    marginTop: 2,
  },
  productGrid: {
    padding: 10,
    paddingBottom: 20,
  },
  productCard: {
    width: productCardWidth,
    marginHorizontal: 5,
    marginVertical: 5,
    borderRadius: 16,
    padding: 10,
    elevation: 3,
    shadowColor: '#000',
    shadowOffset: { width: 0, height: 2 },
    shadowOpacity: 0.12,
    shadowRadius: 4,
    position: 'relative',
  },
  productImageContainer: {
    width: '100%',
    height: 110,
    borderRadius: 12,
    backgroundColor: 'rgba(107, 70, 193, 0.05)',
    justifyContent: 'center',
    alignItems: 'center',
    marginBottom: 10,
    overflow: 'hidden',
  },
  productImage: {
    width: '100%',
    height: '100%',
    borderRadius: 12,
  },
  productImageEmoji: {
    fontSize: 40,
    fontFamily: 'Alexandria-Regular',
  },
  productInfo: {
    flex: 1,
  },
  productNameRow: {
    flexDirection: 'row',
    justifyContent: 'space-between',
    alignItems: 'flex-start',
    marginBottom: 3,
  },
  productName: {
    fontSize: 13,
    fontWeight: 'bold',
    flex: 1,
    marginRight: 6,
    fontFamily: 'Alexandria-Bold',
  },
  productCategory: {
    fontSize: 11,
    marginBottom: 5,
    fontFamily: 'Alexandria-Regular',
  },
  ratingContainer: {
    marginBottom: 6,
  },
  ratingStars: {
    fontSize: 11,
  },
  productPriceRow: {
    flexDirection: 'row',
    justifyContent: 'space-between',
    alignItems: 'center',
  },
  productPrice: {
    fontSize: 13,
    fontWeight: 'bold',
    fontFamily: 'Alexandria-Bold',
  },
  heartButton: {
    padding: 2,
  },
  addButton: {
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
  addButtonText: {
    fontSize: 16,
    fontWeight: 'bold',
    color: '#FFFFFF',
    fontFamily: 'Alexandria-Bold',
    lineHeight: 16,
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
  emptyContainer: {
    flex: 1,
    justifyContent: 'center',
    alignItems: 'center',
    paddingVertical: 50,
  },
  emptyText: {
    fontSize: 16,
    fontFamily: 'Alexandria-Regular',
  },
  modalOverlay: {
    flex: 1,
    backgroundColor: 'rgba(0, 0, 0, 0.5)',
    justifyContent: 'flex-end',
  },
  modalContent: {
    borderTopLeftRadius: 20,
    borderTopRightRadius: 20,
    padding: 20,
    paddingBottom: 40,
    maxHeight: Dimensions.get('window').height * 0.7,
  },
  modalScrollContent: {
    paddingBottom: 20,
  },
  modalTitle: {
    fontSize: 18,
    fontWeight: 'bold',
    marginBottom: 15,
    fontFamily: 'Alexandria-Bold',
  },
  modalSectionTitle: {
    fontSize: 16,
    fontWeight: '600',
    marginTop: 10,
    marginBottom: 10,
    fontFamily: 'Alexandria-Bold',
  },
  modalOption: {
    padding: 15,
    borderRadius: 8,
    marginBottom: 10,
  },
  modalOptionText: {
    fontSize: 16,
    fontFamily: 'Alexandria-Regular',
  },
  applyButton: {
    padding: 15,
    borderRadius: 8,
    marginTop: 20,
    alignItems: 'center',
    justifyContent: 'center',
  },
  applyButtonText: {
    fontSize: 16,
    fontWeight: 'bold',
    fontFamily: 'Alexandria-Bold',
  },
});

export default CategoryProductsScreen;
