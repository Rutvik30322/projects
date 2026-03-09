import React, { useState, useEffect, useRef, useCallback, useMemo } from 'react';
import { View, Text, StyleSheet, ScrollView, TouchableOpacity, Image, RefreshControl, Dimensions, Modal, TextInput, FlatList, ActivityIndicator } from 'react-native';
import { useTheme } from '../context/ThemeContext';
import { useCart } from '../context/CartContext';
import Toast from 'react-native-toast-message';
import ThemedLayout from '../components/ThemedLayout';
import Logo from '../components/Logo';
import MoonIcon from '../components/MoonIcon';
import SunIcon from '../components/SunIcon';
import FilterIcon from '../components/FilterIcon';
import { useAppSelector } from '../store/hooks';
import productService, { Product } from '../services/productService';
import bannerService, { Banner } from '../services/bannerService';
import { useTranslation } from 'react-i18next';

interface Category {
  _id: string;
  name: string;
  icon: string;
  description?: string;
  isActive: boolean;
}

const HomeScreen: React.FC<{ navigation: any }> = ({ navigation }) => {
  const { t, i18n } = useTranslation();
  const { colors, theme, toggleTheme } = useTheme();
  const { addToCart, getTotalItems, items: cartItems } = useCart();
  const { user } = useAppSelector((state) => state.auth);
  const [loading, setLoading] = useState(true);
  const [refreshing, setRefreshing] = useState(false);
  const [selectedCategory, setSelectedCategory] = useState<string | null>(null);
  const [products, setProducts] = useState<Product[]>([]);
  const [allProducts, setAllProducts] = useState<Product[]>([]);
  const [categories, setCategories] = useState<Category[]>([]);
  const [banners, setBanners] = useState<Banner[]>([]);
  const [currentBannerIndex, setCurrentBannerIndex] = useState(0);
  const [likedBanners, setLikedBanners] = useState<Set<string>>(new Set());
  const bannerScrollRef = useRef<ScrollView>(null);
  const mainScrollRef = useRef<FlatList<Product>>(null);
  const screenWidth = Dimensions.get('window').width;
  const bannerWidth = screenWidth - 40; // Account for marginHorizontal (20 on each side)

  // Filter states
  const [priceSort, setPriceSort] = useState<string>('None');
  const [ratingFilter, setRatingFilter] = useState<string>('All');
  const [stockFilter, setStockFilter] = useState<string>('All');
  const [showFilters, setShowFilters] = useState(false);
  const [minPrice, setMinPrice] = useState<string>('');
  const [maxPrice, setMaxPrice] = useState<string>('');

  // Fetch products, categories, and banners from backend
  useEffect(() => {
    loadProducts();
    loadCategories();
    loadBanners();
  }, []);

  // Auto-slide banner functionality
  useEffect(() => {
    if (banners.length === 0) return;

    const interval = setInterval(() => {
      setCurrentBannerIndex((prevIndex) => {
        const nextIndex = (prevIndex + 1) % banners.length;
        bannerScrollRef.current?.scrollTo({
          x: nextIndex * bannerWidth,
          animated: true,
        });
        return nextIndex;
      });
    }, 3000); // Change slide every 3 seconds

    return () => clearInterval(interval);
  }, [banners.length, bannerWidth]);

  // Handle banner scroll
  const handleBannerScroll = (event: any) => {
    const scrollPosition = event.nativeEvent.contentOffset.x;
    const index = Math.round(scrollPosition / bannerWidth);
    setCurrentBannerIndex(index);
  };

  // Toggle like on banner
  const toggleBannerLike = (bannerId: string) => {
    setLikedBanners((prev) => {
      const newSet = new Set(prev);
      if (newSet.has(bannerId)) {
        newSet.delete(bannerId);
      } else {
        newSet.add(bannerId);
      }
      return newSet;
    });
  };

  const loadBanners = async () => {
    try {
      const response = await bannerService.getAllBanners();
      if (response.data && response.data.data && response.data.data.banners) {
        // Sort by order field
        const sortedBanners = response.data.data.banners.sort((a: Banner, b: Banner) =>
          (a.order || 0) - (b.order || 0)
        );
        setBanners(sortedBanners);
      } else if (response.data && response.data.banners) {
        const sortedBanners = response.data.banners.sort((a: Banner, b: Banner) =>
          (a.order || 0) - (b.order || 0)
        );
        setBanners(sortedBanners);
      }
    } catch (error) {
      console.error('Failed to load banners:', error);
      // Don't show error toast for banners, just log it
    }
  };

  const loadProducts = async () => {
    try {
      setLoading(true);
      // Fetch all products by using 'all' limit or a very high limit
      const response = await productService.getAllProducts({ limit: 'all' });
      if (response.data && response.data.data && response.data.data.products) {
        setAllProducts(response.data.data.products);
        applyFilters(response.data.data.products);
      } else if (response.data && response.data.products) {
        setAllProducts(response.data.products);
        applyFilters(response.data.products);
      }
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

  const loadCategories = async () => {
    try {
      const response = await productService.getCategories();
      if (response.data && response.data.data && response.data.data.categories) {
        setCategories(response.data.data.categories);
      } else if (response.data && response.data.categories) {
        setCategories(response.data.categories);
      }
    } catch (error) {
      console.error('Failed to load categories:', error);
      // Don't show error toast for categories, just log it
    }
  };

  // Apply filters to products
  const applyFilters = (productsToFilter: Product[] = allProducts) => {
    let filtered = [...productsToFilter];

    // Category filter
    if (selectedCategory) {
      filtered = filtered.filter(product => product.category === selectedCategory);
    }

    // Rating filter
    if (ratingFilter !== 'All') {
      const minRating = parseFloat(ratingFilter);
      filtered = filtered.filter(product => product.rating >= minRating);
    }

    // Stock filter
    if (stockFilter !== 'All') {
      if (stockFilter === 'In Stock') {
        filtered = filtered.filter(product => product.inStock === true && (product.stock === undefined || product.stock > 0));
      } else if (stockFilter === 'Out of Stock') {
        filtered = filtered.filter(product => product.inStock === false || (product.stock !== undefined && product.stock <= 0));
      }
    }

    // Price range filter
    if (minPrice && minPrice.trim() !== '') {
      const min = parseFloat(minPrice);
      if (!isNaN(min)) {
        filtered = filtered.filter(product => product.price >= min);
      }
    }
    if (maxPrice && maxPrice.trim() !== '') {
      const max = parseFloat(maxPrice);
      if (!isNaN(max)) {
        filtered = filtered.filter(product => product.price <= max);
      }
    }

    // Sort by price
    if (priceSort === 'Low to High') {
      filtered.sort((a, b) => a.price - b.price);
    } else if (priceSort === 'High to Low') {
      filtered.sort((a, b) => b.price - a.price);
    } else if (priceSort === 'Rating') {
      filtered.sort((a, b) => b.rating - a.rating);
    } else if (priceSort === 'Name') {
      filtered.sort((a, b) => a.name.localeCompare(b.name));
    }

    setProducts(filtered);
  };

  // Update filters when filter states change
  useEffect(() => {
    if (allProducts.length > 0) {
      applyFilters();
      // Scroll to top when category changes
      if (selectedCategory !== null && mainScrollRef.current) {
        setTimeout(() => {
          mainScrollRef.current?.scrollToOffset({ offset: 0, animated: true });
        }, 100);
      }
    }
  }, [selectedCategory, priceSort, ratingFilter, stockFilter, minPrice, maxPrice, allProducts]);

  // Reset filters
  const resetFilters = () => {
    setSelectedCategory(null);
    setPriceSort('None');
    setRatingFilter('All');
    setStockFilter('All');
    setMinPrice('');
    setMaxPrice('');
  };

  // Check if any filter is active
  const hasActiveFilters = selectedCategory !== null || priceSort !== 'None' || ratingFilter !== 'All' || stockFilter !== 'All' || (minPrice && minPrice.trim() !== '') || (maxPrice && maxPrice.trim() !== '');

  const onRefresh = async () => {
    setRefreshing(true);
    await Promise.all([loadProducts(), loadCategories(), loadBanners()]);
    setRefreshing(false);
  };

  // Helper function to check if string is a valid URL
  const isValidImageUrl = (url: string | undefined): boolean => {
    if (!url) return false;
    return url.startsWith('http://') || url.startsWith('https://');
  };

  // Helper function to truncate description text
  const truncateText = (text: string | undefined, maxLength: number = 50): string => {
    if (!text) return '';
    if (text.length <= maxLength) return text;
    return text.substring(0, maxLength).trim() + '...';
  };

  // Memoized product item component for better performance
  const ProductItem = React.memo(({ item }: { item: Product }) => {
    const itemColors = useTheme().colors;
    const { addToCart, items: cartItems } = useCart();

    const handleProductPress = useCallback(() => {
      navigation.navigate('ProductDetail', { productId: item._id });
    }, [item._id]);

    const handleAddToCart = useCallback((e: any) => {
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
      });

      Toast.show({
        type: 'success',
        text1: 'Added to Cart',
        text2: `${item.name} added to your cart`,
        visibilityTime: 2000,
      });
    }, [item, cartItems, addToCart]);

    const isOutOfStock = item.inStock === false || (item.stock !== undefined && item.stock <= 0);
    const buttonBgColor = isOutOfStock ? itemColors.textSecondary : itemColors.primary;
    const imageUrl = isValidImageUrl(item.image) ? item.image : null;

    return (
      <TouchableOpacity
        style={[styles.productCard, { backgroundColor: itemColors.surface }]}
        onPress={handleProductPress}
        activeOpacity={0.7}
      >
        <View style={styles.productImageContainer}>
          {imageUrl ? (
            <Image
              source={{ uri: imageUrl }}
              style={styles.productImage}
              resizeMode="cover"
            />
          ) : (
            <Text style={styles.productImageEmoji}>{item.image || '🍫'}</Text>
          )}
        </View>
        <View style={styles.productInfo}>
          <Text style={[styles.productName, { color: itemColors.text }]}>{item.name}</Text>
          <Text
            style={[styles.productDescription, { color: itemColors.textSecondary }]}
            numberOfLines={2}
            ellipsizeMode="tail"
          >
            {truncateText(item.description, 60)}
          </Text>
          <View style={styles.productFooter}>
            <Text style={[styles.productPrice, { color: itemColors.primary }]}>
              ₹{item.price}
            </Text>
            <Text style={[styles.productRating, { color: itemColors.textSecondary }]}>
              ⭐ {item.rating}
            </Text>
          </View>
        </View>
        <TouchableOpacity
          style={[styles.addButton, { backgroundColor: buttonBgColor }]}
          onPress={handleAddToCart}
          disabled={isOutOfStock}
          activeOpacity={0.7}
        >
          <Text style={[styles.addButtonText, { color: itemColors.onPrimary }]}>
            {isOutOfStock ? t('out_of_stock_item') : t('add')}
          </Text>
        </TouchableOpacity>
      </TouchableOpacity>
    );
  }, (prevProps, nextProps) => {
    // Custom comparison function for memo
    return (
      prevProps.item._id === nextProps.item._id &&
      prevProps.item.name === nextProps.item.name &&
      prevProps.item.price === nextProps.item.price &&
      prevProps.item.inStock === nextProps.item.inStock &&
      prevProps.item.stock === nextProps.item.stock
    );
  });

  const renderProduct = useCallback(({ item }: { item: Product }) => {
    return <ProductItem item={item} />;
  }, []);

  const getItemLayout = useCallback((data: any, index: number) => {
    return {
      length: 120, // Approximate height of product card
      offset: 120 * index,
      index,
    };
  }, []);

  const keyExtractor = useCallback((item: Product) => item._id, []);

  return (
    <ThemedLayout edges={['top'] /* Exclude bottom edge to avoid conflict with tab navigator */}>
      <View style={[styles.container, { backgroundColor: colors.background }]}>
        {/* Header */}
        <View style={[styles.header, { backgroundColor: colors.surface, borderBottomColor: colors.textSecondary + '20' }]}>
          <View style={styles.headerLeft}>
            <Logo size={60} style={styles.headerLogo} />
            <View>
              <Text style={[styles.greeting, { color: colors.text }]}>{t('greeting', { name: user?.name || 'User' })}</Text>
              <Text style={[styles.subGreeting, { color: colors.textSecondary }]}>
                {t('subGreeting')}
              </Text>
            </View>
          </View>
          <View style={styles.headerIcons}>
            {/* <TouchableOpacity 
            onPress={() => navigation.navigate('Cart')}
            style={styles.cartButton}
          >
            <Text style={{ color: colors.primary }}>🛒</Text>
            {getTotalItems() > 0 && (
              <View style={styles.badge}>
                <Text style={styles.badgeText}>{getTotalItems()}</Text>
              </View>
            )}
          </TouchableOpacity> */}
            <TouchableOpacity onPress={() => i18n.changeLanguage(i18n.language === 'en' ? 'hi' : 'en')} style={styles.themeToggle}>
              <Text style={{ color: colors.primary, fontWeight: 'bold', fontSize: 16 }}>
                {i18n.language === 'en' ? 'HI' : 'EN'}
              </Text>
            </TouchableOpacity>
            <TouchableOpacity onPress={toggleTheme} style={styles.themeToggle}>
              {theme === 'light' ? (
                <MoonIcon size={24} color={colors.primary} />
              ) : (
                <SunIcon size={24} color={colors.primary} />
              )}
            </TouchableOpacity>
          </View>
        </View>

        {/* Main FlatList for better performance - replaces ScrollView */}
        <FlatList
          ref={mainScrollRef}
          data={products}
          renderItem={renderProduct}
          keyExtractor={keyExtractor}
          getItemLayout={getItemLayout}
          showsVerticalScrollIndicator={true}
          contentContainerStyle={{ paddingBottom: 20 }}
          refreshControl={
            <RefreshControl refreshing={refreshing} onRefresh={onRefresh} colors={[colors.primary]} />
          }
          initialNumToRender={5}
          maxToRenderPerBatch={3}
          updateCellsBatchingPeriod={100}
          windowSize={3}
          removeClippedSubviews={true}
          ListHeaderComponent={
            <>
              {/* Banner Slider */}
              <View style={styles.bannerContainer}>
                <ScrollView
                  ref={bannerScrollRef}
                  horizontal
                  pagingEnabled
                  showsHorizontalScrollIndicator={false}
                  onScroll={handleBannerScroll}
                  scrollEventThrottle={16}
                  style={styles.bannerScrollView}
                  nestedScrollEnabled={true}
                >
                  {banners.length > 0 ? banners.map((banner, index) => (
                    <View key={banner._id} style={[styles.bannerSlide, { width: bannerWidth }]}>
                      <View style={styles.bannerImageContainer}>
                        <Image
                          source={{ uri: banner.image }}
                          style={styles.bannerImage}
                          resizeMode="cover"
                        />
                        <View style={styles.bannerOverlay}>
                          <View style={styles.bannerContent}>
                            {banner.offer && (
                              <View style={styles.bannerOfferBadge}>
                                <Text style={styles.bannerOfferText}>{banner.offer}</Text>
                              </View>
                            )}
                            <Text style={[styles.bannerTitle, { color: colors.onPrimary }]}>{banner.title}</Text>
                            {banner.description && (
                              <Text style={[styles.bannerDescription, { color: colors.onPrimary }]}>{banner.description}</Text>
                            )}
                          </View>
                          <TouchableOpacity
                            style={styles.likeButton}
                            onPress={() => toggleBannerLike(banner._id)}
                          >
                            <Text style={styles.likeIcon}>
                              {likedBanners.has(banner._id) ? '❤️' : '🤍'}
                            </Text>
                          </TouchableOpacity>
                        </View>
                      </View>
                    </View>
                  )) : null}
                </ScrollView>
              </View>

              {/* Categories */}
              <View style={[styles.section, styles.categoriesSection]}>
                <Text style={[styles.sectionTitle, { color: colors.text }]}>{t('categories')}</Text>
                <ScrollView
                  horizontal
                  showsHorizontalScrollIndicator={false}
                  style={styles.categoriesContainer}
                  nestedScrollEnabled={true}
                >
                  <TouchableOpacity
                    style={[
                      styles.categoryItem,
                      selectedCategory === null && { backgroundColor: colors.primary }
                    ]}
                    onPress={() => setSelectedCategory(null)}
                  >
                    <Text
                      style={[
                        styles.categoryText,
                        { color: selectedCategory === null ? colors.onPrimary : colors.text }
                      ]}
                    >
                      {t('allCategories')}
                    </Text>
                  </TouchableOpacity>

                  {categories.map(category => (
                    <TouchableOpacity
                      key={category._id}
                      style={[
                        styles.categoryItem,
                        selectedCategory === category.name && { backgroundColor: colors.primary }
                      ]}
                      onPress={() => setSelectedCategory(category.name)}
                    >
                      <Text
                        style={[
                          styles.categoryText,
                          { color: selectedCategory === category.name ? colors.onPrimary : colors.text }
                        ]}
                      >
                        {category.icon || '🍫'} {category.name}
                      </Text>
                    </TouchableOpacity>
                  ))}
                </ScrollView>
              </View>

              {/* Products Header */}
              <View style={[styles.section, styles.productsSection]}>
                <View style={styles.sectionHeader}>
                  <Text style={[styles.sectionTitle, { color: colors.text }]}>
                    {selectedCategory ? selectedCategory : t('allProducts')}
                  </Text>
                  <View style={styles.sectionHeaderRight}>
                    <TouchableOpacity
                      style={[styles.filterButtonSmall, { backgroundColor: hasActiveFilters ? colors.primary : colors.surface }]}
                      onPress={() => setShowFilters(!showFilters)}
                    >
                      <View style={styles.filterButtonContentSmall}>
                        <FilterIcon size={14} color={hasActiveFilters ? colors.onPrimary : colors.text} />
                        {hasActiveFilters && (
                          <Text style={[styles.filterButtonTextSmall, { color: hasActiveFilters ? colors.onPrimary : colors.text }]}>
                            ({products.length})
                          </Text>
                        )}
                      </View>
                    </TouchableOpacity>
                    <TouchableOpacity onPress={() => navigation.navigate('AllProducts')}>
                      <Text style={[styles.seeAll, { color: colors.primary }]}>{t('seeAll')}</Text>
                    </TouchableOpacity>
                  </View>
                </View>
                {hasActiveFilters && products.length > 0 && (
                  <Text style={[styles.filterResultText, { color: colors.textSecondary }]}>
                    {t('showing_products', { count: products.length, total: allProducts.length })}
                  </Text>
                )}
              </View>
            </>
          }
          ListEmptyComponent={
            loading ? (
              <View style={styles.loadingContainer}>
                <ActivityIndicator size="large" color={colors.primary} />
                <Text style={[styles.loadingText, { color: colors.textSecondary }]}>{t('loading')}</Text>
              </View>
            ) : (
              <View style={styles.emptyContainer}>
                <Text style={[styles.emptyIcon, { fontSize: 64, marginBottom: 16 }]}>
                  {selectedCategory ? '🔍' : '📦'}
                </Text>
                <Text style={[styles.emptyText, { color: colors.text }]}>
                  {selectedCategory
                    ? t('no_products_category', { category: selectedCategory })
                    : t('no_products')}
                </Text>
                <Text style={[styles.emptySubtext, { color: colors.textSecondary }]}>
                  {selectedCategory
                    ? t('try_different')
                    : t('check_back')}
                </Text>
                {selectedCategory && (
                  <TouchableOpacity
                    style={[styles.resetButton, { backgroundColor: colors.primary, marginTop: 16 }]}
                    onPress={() => setSelectedCategory(null)}
                  >
                    <Text style={[styles.resetButtonText, { color: colors.onPrimary }]}>
                      {t('show_all_products')}
                    </Text>
                  </TouchableOpacity>
                )}
              </View>
            )
          }
          ListFooterComponent={<View style={{ height: 20 }} />}
        />

        {/* Filter Modal - Outside FlatList */}
        <Modal
          visible={showFilters}
          transparent={true}
          animationType="slide"
          onRequestClose={() => setShowFilters(false)}
        >
          <TouchableOpacity
            style={styles.modalOverlay}
            activeOpacity={1}
            onPress={() => setShowFilters(false)}
          >
            <TouchableOpacity
              activeOpacity={1}
              onPress={(e) => e.stopPropagation()}
              style={[styles.modalContainer, { backgroundColor: colors.surface }]}
            >
              {/* Modal Header */}
              <View style={[styles.modalHeader, { borderBottomColor: colors.textSecondary + '20' }]}>
                <Text style={[styles.modalTitle, { color: colors.text }]}>{t('filters')}</Text>
                <TouchableOpacity
                  onPress={() => setShowFilters(false)}
                  style={styles.modalCloseButton}
                >
                  <Text style={[styles.modalCloseText, { color: colors.text }]}>✕</Text>
                </TouchableOpacity>
              </View>

              {/* Modal Content */}
              <ScrollView style={styles.modalContent} showsVerticalScrollIndicator={false}>
                {/* Price Range Filter */}
                <View style={styles.filterSection}>
                  <Text style={[styles.filterLabel, { color: colors.text }]}>{t('price_range')}</Text>
                  <View style={styles.priceRangeContainer}>
                    <View style={styles.priceInputContainer}>
                      <Text style={[styles.priceLabel, { color: colors.textSecondary }]}>{t('min_price')}</Text>
                      <TextInput
                        style={[styles.priceInput, {
                          backgroundColor: colors.background,
                          color: colors.text,
                          borderColor: colors.textSecondary + '40'
                        }]}
                        value={minPrice}
                        onChangeText={setMinPrice}
                        placeholder="0"
                        placeholderTextColor={colors.textSecondary}
                        keyboardType="numeric"
                      />
                    </View>
                    <View style={styles.priceInputContainer}>
                      <Text style={[styles.priceLabel, { color: colors.textSecondary }]}>{t('max_price')}</Text>
                      <TextInput
                        style={[styles.priceInput, {
                          backgroundColor: colors.background,
                          color: colors.text,
                          borderColor: colors.textSecondary + '40'
                        }]}
                        value={maxPrice}
                        onChangeText={setMaxPrice}
                        placeholder="10000"
                        placeholderTextColor={colors.textSecondary}
                        keyboardType="numeric"
                      />
                    </View>
                  </View>
                </View>

                {/* Sort By */}
                <View style={styles.filterSection}>
                  <Text style={[styles.filterLabel, { color: colors.text }]}>{t('sort_by')}</Text>
                  <ScrollView horizontal showsHorizontalScrollIndicator={false} style={styles.filterChips}>
                    {['None', 'Low to High', 'High to Low', 'Rating', 'Name'].map((sort) => (
                      <TouchableOpacity
                        key={sort}
                        style={[
                          styles.filterChip,
                          {
                            backgroundColor: priceSort === sort ? colors.primary : colors.background,
                            borderColor: priceSort === sort ? colors.primary : colors.textSecondary + '40',
                          }
                        ]}
                        onPress={() => setPriceSort(sort)}
                      >
                        <Text style={[
                          styles.filterChipText,
                          { color: priceSort === sort ? colors.onPrimary : colors.text }
                        ]}>
                          {sort}
                        </Text>
                      </TouchableOpacity>
                    ))}
                  </ScrollView>
                </View>

                {/* Rating Filter */}
                <View style={styles.filterSection}>
                  <Text style={[styles.filterLabel, { color: colors.text }]}>{t('rating')}</Text>
                  <ScrollView horizontal showsHorizontalScrollIndicator={false} style={styles.filterChips}>
                    {['All', '4', '3', '2', '1'].map((rating) => (
                      <TouchableOpacity
                        key={rating}
                        style={[
                          styles.filterChip,
                          {
                            backgroundColor: ratingFilter === rating ? colors.primary : colors.background,
                            borderColor: ratingFilter === rating ? colors.primary : colors.textSecondary + '40',
                          }
                        ]}
                        onPress={() => setRatingFilter(rating)}
                      >
                        <Text style={[
                          styles.filterChipText,
                          { color: ratingFilter === rating ? colors.onPrimary : colors.text }
                        ]}>
                          {rating === 'All' ? 'All' : `⭐ ${rating}+`}
                        </Text>
                      </TouchableOpacity>
                    ))}
                  </ScrollView>
                </View>

                {/* Stock Status Filter */}
                <View style={styles.filterSection}>
                  <Text style={[styles.filterLabel, { color: colors.text }]}>{t('stock_status')}</Text>
                  <ScrollView horizontal showsHorizontalScrollIndicator={false} style={styles.filterChips}>
                    {['All', 'In Stock', 'Out of Stock'].map((stock) => (
                      <TouchableOpacity
                        key={stock}
                        style={[
                          styles.filterChip,
                          {
                            backgroundColor: stockFilter === stock ? colors.primary : colors.background,
                            borderColor: stockFilter === stock ? colors.primary : colors.textSecondary + '40',
                          }
                        ]}
                        onPress={() => setStockFilter(stock)}
                      >
                        <Text style={[
                          styles.filterChipText,
                          { color: stockFilter === stock ? colors.onPrimary : colors.text }
                        ]}>
                          {stock}
                        </Text>
                      </TouchableOpacity>
                    ))}
                  </ScrollView>
                </View>
              </ScrollView>

              {/* Modal Footer */}
              <View style={[styles.modalFooter, { borderTopColor: colors.textSecondary + '20' }]}>
                {hasActiveFilters && (
                  <TouchableOpacity
                    style={[styles.resetButton, { backgroundColor: colors.error + '20', marginRight: 10 }]}
                    onPress={resetFilters}
                  >
                    <Text style={[styles.resetButtonText, { color: colors.error }]}>
                      {t('reset')}
                    </Text>
                  </TouchableOpacity>
                )}
                <TouchableOpacity
                  style={[styles.applyButton, { backgroundColor: colors.primary, flex: 1 }]}
                  onPress={() => setShowFilters(false)}
                >
                  <Text style={[styles.applyButtonText, { color: colors.onPrimary }]}>
                    {t('apply_filters')}
                  </Text>
                </TouchableOpacity>
              </View>
            </TouchableOpacity>
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
  mainScrollView: {
    flex: 1,
  },
  header: {
    flexDirection: 'row',
    justifyContent: 'space-between',
    alignItems: 'center',
    padding: 20,
    elevation: 2,
    shadowColor: '#000',
    shadowOffset: { width: 0, height: 1 },
    shadowOpacity: 0.1,
    shadowRadius: 2,
    borderBottomWidth: 1,
  },
  headerLeft: {
    flexDirection: 'row',
    alignItems: 'center',
    flex: 1,
  },
  headerLogo: {
    marginRight: 12,
  },
  greeting: {
    fontSize: 20,
    fontWeight: 'bold',
    fontFamily: 'Alexandria-Bold',
  },
  subGreeting: {
    fontSize: 14,
    fontFamily: 'Alexandria-Regular',
  },
  headerIcons: {
    flexDirection: 'row',
    alignItems: 'center',
  },
  cartButton: {
    marginRight: 15,
    position: 'relative',
  },
  badge: {
    position: 'absolute',
    top: -5,
    right: -5,
    backgroundColor: 'red',
    borderRadius: 10,
    minWidth: 20,
    height: 20,
    justifyContent: 'center',
    alignItems: 'center',
    padding: 3,
  },
  badgeText: {
    color: 'white',
    fontSize: 12,
    fontWeight: 'bold',
    fontFamily: 'Alexandria-Bold',
  },
  themeToggle: {
    padding: 10,
  },
  bannerContainer: {
    marginHorizontal: 20,
    marginTop: 10,
    marginBottom: 0,
    borderRadius: 12,
    overflow: 'hidden',
  },
  bannerScrollView: {
    borderRadius: 12,
  },
  bannerSlide: {
    marginHorizontal: 0,
  },
  bannerImageContainer: {
    height: 140,
    position: 'relative',
    borderRadius: 12,
    overflow: 'hidden',
  },
  bannerImage: {
    width: '100%',
    height: '100%',
  },
  bannerOverlay: {
    position: 'absolute',
    top: 0,
    left: 0,
    right: 0,
    bottom: 0,
    backgroundColor: 'rgba(0, 0, 0, 0.4)',
    justifyContent: 'space-between',
    padding: 15,
  },
  bannerContent: {
    flex: 1,
    justifyContent: 'flex-start',
  },
  bannerOfferBadge: {
    alignSelf: 'flex-start',
    backgroundColor: '#FF6B6B',
    paddingHorizontal: 12,
    paddingVertical: 6,
    borderRadius: 20,
    marginBottom: 10,
  },
  bannerOfferText: {
    color: '#FFFFFF',
    fontSize: 12,
    fontWeight: 'bold',
    fontFamily: 'Alexandria-Bold',
  },
  bannerTitle: {
    fontSize: 22,
    fontWeight: 'bold',
    marginBottom: 5,
    fontFamily: 'Alexandria-Bold',
  },
  bannerDescription: {
    fontSize: 14,
    opacity: 0.9,
    fontFamily: 'Alexandria-Regular',
  },
  likeButton: {
    alignSelf: 'flex-end',
    padding: 8,
  },
  likeIcon: {
    fontSize: 24,
    fontFamily: 'Alexandria-Regular',
  },
  section: {
    marginHorizontal: 20,
    marginBottom: 22,
  },
  categoriesSection: {
    marginTop: 2,
  },
  productsSection: {
    marginBottom: 20,
  },
  productsListContainer: {
    marginTop: 10,
  },
  sectionHeader: {
    flexDirection: 'row',
    justifyContent: 'space-between',
    alignItems: 'center',
    marginBottom: 10,
  },
  sectionHeaderRight: {
    flexDirection: 'row',
    alignItems: 'center',
    gap: 10,
  },
  filterButtonSmall: {
    paddingHorizontal: 12,
    paddingVertical: 6,
    borderRadius: 16,
    elevation: 1,
    shadowColor: '#000',
    shadowOffset: { width: 0, height: 1 },
    shadowOpacity: 0.1,
    shadowRadius: 1,
  },
  filterButtonContentSmall: {
    flexDirection: 'row',
    alignItems: 'center',
    gap: 4,
  },
  filterButtonTextSmall: {
    fontSize: 12,
    fontWeight: '600',
    fontFamily: 'Alexandria-SemiBold',
  },
  filtersContainer: {
    padding: 15,
    borderRadius: 12,
    marginBottom: 15,
    elevation: 2,
    shadowColor: '#000',
    shadowOffset: { width: 0, height: 1 },
    shadowOpacity: 0.1,
    shadowRadius: 2,
  },
  filterSection: {
    marginBottom: 15,
  },
  filterLabel: {
    fontSize: 14,
    fontWeight: '600',
    marginBottom: 10,
    fontFamily: 'Alexandria-SemiBold',
  },
  filterChips: {
    flexDirection: 'row',
  },
  filterChip: {
    paddingHorizontal: 16,
    paddingVertical: 8,
    borderRadius: 20,
    marginRight: 8,
    borderWidth: 1,
  },
  filterChipText: {
    fontSize: 13,
    fontWeight: '500',
    fontFamily: 'Alexandria-Medium',
  },
  resetButton: {
    paddingVertical: 10,
    paddingHorizontal: 20,
    borderRadius: 8,
    alignItems: 'center',
    marginTop: 5,
  },
  resetButtonText: {
    fontSize: 14,
    fontWeight: '600',
    fontFamily: 'Alexandria-SemiBold',
  },
  filterResultText: {
    fontSize: 12,
    marginBottom: 10,
    fontStyle: 'italic',
    fontFamily: 'Alexandria-Regular',
  },
  sectionTitle: {
    fontSize: 18,
    fontWeight: 'bold',
    marginBottom: 6,
    fontFamily: 'Alexandria-Bold',
  },
  seeAll: {
    fontSize: 14,
    fontWeight: '500',
    fontFamily: 'Alexandria-Medium',
  },
  categoriesContainer: {
    paddingVertical: 10,
  },
  categoryItem: {
    paddingHorizontal: 16,
    paddingVertical: 8,
    marginRight: 10,
    borderRadius: 20,
    backgroundColor: 'rgba(107, 70, 193, 0.1)',
  },
  categoryText: {
    fontSize: 14,
    fontFamily: 'Alexandria-Regular',
  },
  productCard: {
    flexDirection: 'row',
    padding: 15,
    marginHorizontal: 20,
    marginBottom: 15,
    borderRadius: 10,
    elevation: 2,
    shadowColor: '#000',
    shadowOffset: { width: 0, height: 1 },
    shadowOpacity: 0.1,
    shadowRadius: 2,
  },
  productImageContainer: {
    width: 60,
    height: 60,
    borderRadius: 10,
    backgroundColor: 'rgba(107, 70, 193, 0.1)',
    justifyContent: 'center',
    alignItems: 'center',
    marginRight: 15,
  },
  productImage: {
    width: 60,
    height: 60,
    borderRadius: 10,
  },
  productImageEmoji: {
    fontSize: 30,
    fontFamily: 'Alexandria-Regular',
  },
  productInfo: {
    flex: 1,
  },
  productName: {
    fontSize: 16,
    fontWeight: 'bold',
    marginBottom: 5,
    fontFamily: 'Alexandria-Bold',
  },
  productDescription: {
    fontSize: 12,
    marginBottom: 10,
    lineHeight: 16,
    maxHeight: 32, // Allow for 2 lines (12px font * 2 lines with lineHeight)
    fontFamily: 'Alexandria-Regular',
  },
  productFooter: {
    flexDirection: 'row',
    justifyContent: 'space-between',
    alignItems: 'center',
  },
  productPrice: {
    fontSize: 16,
    fontWeight: 'bold',
    fontFamily: 'Alexandria-Bold',
  },
  productRating: {
    fontSize: 12,
    fontFamily: 'Alexandria-Regular',
  },
  addButton: {
    alignSelf: 'flex-start',
    paddingHorizontal: 15,
    paddingVertical: 8,
    borderRadius: 20,
    marginLeft: 10,
    marginTop: 20,
  },
  addButtonText: {
    fontWeight: 'bold',
    fontSize: 12,
    fontFamily: 'Alexandria-Bold',
  },
  modalOverlay: {
    flex: 1,
    backgroundColor: 'rgba(0, 0, 0, 0.5)',
    justifyContent: 'flex-end',
  },
  modalContainer: {
    maxHeight: Dimensions.get('window').height * 0.85,
    borderTopLeftRadius: 20,
    borderTopRightRadius: 20,
    paddingBottom: 20,
    elevation: 10,
    shadowColor: '#000',
    shadowOffset: { width: 0, height: -2 },
    shadowOpacity: 0.25,
    shadowRadius: 10,
    width: '100%',
  },
  modalHeader: {
    flexDirection: 'row',
    justifyContent: 'space-between',
    alignItems: 'center',
    paddingHorizontal: 20,
    paddingVertical: 16,
    paddingRight: 12,
    borderBottomWidth: 1,
  },
  modalTitle: {
    fontSize: 20,
    fontWeight: 'bold',
    flex: 1,
    fontFamily: 'Alexandria-Bold',
  },
  modalCloseButton: {
    padding: 8,
    minWidth: 40,
    minHeight: 40,
    justifyContent: 'center',
    alignItems: 'center',
    marginLeft: 8,
  },
  modalCloseText: {
    fontSize: 22,
    fontWeight: 'bold',
    lineHeight: 22,
    fontFamily: 'Alexandria-Bold',
  },
  modalContent: {
    maxHeight: Dimensions.get('window').height * 0.55,
    paddingHorizontal: 20,
    paddingTop: 10,
  },
  modalFooter: {
    flexDirection: 'row',
    padding: 20,
    borderTopWidth: 1,
    alignItems: 'center',
  },
  priceRangeContainer: {
    flexDirection: 'row',
    gap: 10,
    marginTop: 10,
  },
  priceInputContainer: {
    flex: 1,
  },
  priceLabel: {
    fontSize: 12,
    marginBottom: 5,
    fontFamily: 'Alexandria-Regular',
  },
  priceInput: {
    borderWidth: 1,
    borderRadius: 8,
    padding: 12,
    fontSize: 14,
    fontFamily: 'Alexandria-Regular',
  },
  applyButton: {
    paddingVertical: 12,
    paddingHorizontal: 20,
    borderRadius: 8,
    alignItems: 'center',
  },
  applyButtonText: {
    fontSize: 16,
    fontWeight: 'bold',
    fontFamily: 'Alexandria-Bold',
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
    paddingVertical: 60,
    paddingHorizontal: 20,
  },
  emptyIcon: {
    fontSize: 64,
    marginBottom: 16,
  },
  emptyText: {
    fontSize: 18,
    fontWeight: 'bold',
    textAlign: 'center',
    marginBottom: 8,
    fontFamily: 'Alexandria-Bold',
  },
  emptySubtext: {
    fontSize: 14,
    textAlign: 'center',
    marginBottom: 16,
    fontFamily: 'Alexandria-Regular',
  },
});

export default HomeScreen;