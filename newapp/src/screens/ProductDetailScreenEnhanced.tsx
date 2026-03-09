import React, { useState, useRef, useEffect, useCallback } from 'react';
import {
  View,
  Text,
  StyleSheet,
  ScrollView,
  TouchableOpacity,
  FlatList,
  Image,
  Dimensions,
  ActivityIndicator,
} from 'react-native';
import { GestureHandlerRootView } from 'react-native-gesture-handler';
import { useTheme } from '../context/ThemeContext';
import { useCart } from '../context/CartContext';
import ThemedLayout from '../components/ThemedLayout';
import ProductHeader from '../components/ProductHeader';
import HeartIcon from '../components/HeartIcon';
import ReplacementIcon from '../components/ReplacementIcon';
import SupportIcon from '../components/SupportIcon';
import FastDeliveryIcon from '../components/FastDeliveryIcon';
import Toast from 'react-native-toast-message';
import productService, { Product } from '../services/productService';

const screenWidth = Dimensions.get('window').width;
const imageCarouselWidth = screenWidth - 40;

const ProductDetailScreenEnhanced: React.FC<{ route: any, navigation: any }> = ({
  route,
  navigation
}) => {
  const { productId } = route.params || {};
  const { colors, theme } = useTheme();
  const { addToCart, items: cartItems } = useCart();
  const [product, setProduct] = useState<Product | null>(null);
  const [similarProducts, setSimilarProducts] = useState<Product[]>([]);
  const [loading, setLoading] = useState(true);
  const [loadingSimilar, setLoadingSimilar] = useState(false);
  const [currentImageIndex, setCurrentImageIndex] = useState(0);
  const [isFavorite, setIsFavorite] = useState(false);
  const [showProductDetails, setShowProductDetails] = useState(false);
  const [showInformation, setShowInformation] = useState(false);
  const [likedProducts, setLikedProducts] = useState<Set<string>>(new Set());
  const scrollViewRef = useRef<ScrollView>(null);

  // Group similar products by category
  const groupProductsByCategory = React.useMemo(() => {
    return similarProducts.reduce((acc, prod) => {
      const category = prod.category || 'Other';
      if (!acc[category]) {
        acc[category] = [];
      }
      acc[category].push(prod);
      return acc;
    }, {} as Record<string, Product[]>);
  }, [similarProducts]);

  const loadProduct = useCallback(async () => {
    if (!productId) return;

    try {
      setLoading(true);
      const response = await productService.getProductById(productId);

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
  }, [productId]);

  const loadSimilarProducts = useCallback(async () => {
    if (!product) return;

    try {
      setLoadingSimilar(true);

      // Limit to 20 — avoids fetching all products on every detail view
      const response = await productService.getAllProducts({ limit: 20 });

      let products = [];

      if (response?.data?.data?.products) {
        products = response.data.data.products;
      } else if (response?.data?.products) {
        products = response.data.products;
      } else if ((response as any)?.products) {
        products = (response as any).products;
      }

      const similar = products.filter((p: Product) => p._id !== product._id);

      setSimilarProducts(similar);
    } catch (error: any) {
      console.error('Failed to load similar products:', error);
      setSimilarProducts([]);
    } finally {
      setLoadingSimilar(false);
    }
  }, [product]);

  // Fetch product details from backend
  useEffect(() => {
    if (productId) {
      loadProduct();
    }
  }, [productId, loadProduct]);

  // Load similar products when product loads
  useEffect(() => {
    if (product) {
      loadSimilarProducts();
      setCurrentImageIndex(0);
      scrollViewRef.current?.scrollTo({ x: 0, animated: false });
    }
  }, [product, loadSimilarProducts]);

  const isValidImageUrl = (url: string | undefined): boolean => {
    if (!url) return false;
    return url.startsWith('http://') || url.startsWith('https://');
  };

  const getProductImages = (): string[] => {
    if (!product) return [];
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
    return images.length > 0 ? images : ['🍫'];
  };

  if (loading) {
    return (
      <GestureHandlerRootView style={{ flex: 1 }}>
        <ThemedLayout edges={['top']}>
          <View style={[styles.container, { backgroundColor: colors.background }]}>
            <ProductHeader
              onBackPress={() => navigation.goBack()}
              onSearchPress={() => navigation.navigate('AllProducts')}
            />
            <View style={styles.loadingContainer}>
              <ActivityIndicator size="large" color={colors.primary} />
              <Text style={[styles.loadingText, { color: colors.textSecondary }]}>Loading product...</Text>
            </View>
          </View>
        </ThemedLayout>
      </GestureHandlerRootView>
    );
  }

  if (!product) {
    return (
      <GestureHandlerRootView style={{ flex: 1 }}>
        <ThemedLayout edges={['top']}>
          <View style={[styles.container, { backgroundColor: colors.background }]}>
            <ProductHeader
              onBackPress={() => navigation.goBack()}
              onSearchPress={() => navigation.navigate('AllProducts')}
            />
            <View style={styles.loadingContainer}>
              <Text style={[styles.loadingText, { color: colors.text }]}>Product not found</Text>
            </View>
          </View>
        </ThemedLayout>
      </GestureHandlerRootView>
    );
  }

  const productImages = getProductImages();

  const handlePageChange = (index: number) => {
    setCurrentImageIndex(index);
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

  const handleSimilarProductPress = (productId: string) => {
    if (navigation && productId) {
      navigation.replace('ProductDetailEnhanced', { productId });
    }
  };

  const handleLike = (productId: string) => {
    setLikedProducts(prev => {
      const newSet = new Set(prev);
      if (newSet.has(productId)) {
        newSet.delete(productId);
      } else {
        newSet.add(productId);
      }
      return newSet;
    });
  };

  const SimilarProductCard = ({ item }: { item: Product }) => {
    const isValidImageUrl = item.image && (
      item.image.startsWith('http://') || item.image.startsWith('https://')
    );
    const isLiked = likedProducts.has(item._id);
    const imageUrl = isValidImageUrl ? item.image : null;
    const ratingStars = '⭐'.repeat(Math.floor(item.rating || 0));

    return (
      <TouchableOpacity
        style={[styles.horizontalProductCard, { backgroundColor: colors.surface }]}
        onPress={() => handleSimilarProductPress(item._id)}
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
            <Text style={[styles.horizontalProductName, { color: colors.text }]} numberOfLines={1}>
              {item.name}
            </Text>
            <TouchableOpacity
              style={[styles.horizontalAddButton, { backgroundColor: '#381230' }]}
              onPress={(e) => {
                e.stopPropagation();
                handleAddToCart(item);
              }}
              activeOpacity={0.7}
            >
              <Text style={styles.horizontalAddButtonText}>+</Text>
            </TouchableOpacity>
          </View>
          <Text style={[styles.horizontalProductCategory, { color: colors.textSecondary }]}>
            {item.category || 'Products'}
          </Text>
          <View style={styles.horizontalProductRating}>
            <Text style={styles.ratingStars}>{ratingStars}</Text>
          </View>
          <View style={styles.horizontalProductPriceRow}>
            <Text style={[styles.horizontalProductPrice, { color: colors.primary }]}>
              MRP ₹ {item.price}
            </Text>
            <TouchableOpacity
              style={styles.horizontalLikeButton}
              onPress={(e) => {
                e.stopPropagation();
                handleLike(item._id);
              }}
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
    <GestureHandlerRootView style={{ flex: 1 }}>
      <ThemedLayout edges={['top']}>
        <View style={[styles.container, { backgroundColor: colors.background }]}>
          {/* Reusable Header */}
          <ProductHeader
            onBackPress={() => navigation.goBack()}
            onSearchPress={() => navigation.navigate('AllProducts')}
          />

          <ScrollView
            showsVerticalScrollIndicator={true}
            contentContainerStyle={styles.scrollContent}
            nestedScrollEnabled={true}
            scrollEnabled={true}
            bounces={true}
            alwaysBounceVertical={false}
          >
            {/* Product Images Carousel */}
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
                scrollEnabled={true}
                bounces={true}
                alwaysBounceHorizontal={true}
                alwaysBounceVertical={false}
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
                        {
                          backgroundColor: index === currentImageIndex
                            ? colors.primary || '#E91E63'
                            : colors.textSecondary + '80'
                        }
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
                <View style={styles.productNameContainer}>
                  <Text style={[styles.productName, { color: '#381230' }]} numberOfLines={2}>
                    {product.name}
                  </Text>
                  <Text style={[styles.productWeight, { color: '#381230' }]}>
                    {product.weight || '500 gm'}
                  </Text>
                </View>
                <TouchableOpacity
                  style={styles.heartButton}
                  onPress={() => setIsFavorite(!isFavorite)}
                  activeOpacity={0.7}
                >
                  <HeartIcon size={24} color="#381230" filled={isFavorite} />
                </TouchableOpacity>
              </View>
              <Text style={[styles.productCategoryLabel, { color: '#381230' }]}>
                Category: {product.category}
              </Text>
              <View style={styles.priceRatingRow}>
                <Text style={[styles.productPrice, { color: '#381230' }]}>
                  ₹ {product.price} MRP
                </Text>
                <View style={styles.ratingRow}>
                  <Text style={{ color: '#FFD700', fontSize: 12 }}>
                    {'★'.repeat(Math.floor(product.rating || 0))}
                    {'☆'.repeat(5 - Math.floor(product.rating || 0))}
                  </Text>
                  <Text style={[styles.ratingCount, { color: '#381230' }]}>
                    ({product.numReviews ? (product.numReviews >= 10000 ? '10k+' : product.numReviews) : 0})
                  </Text>
                  <View style={[styles.vegIndicator, { backgroundColor: '#4CAF50' }]} />
                </View>
              </View>

              {/* View Product Details - Expandable (instant show/hide, no heavy animation) */}
              <View style={styles.viewDetailsSeparator} />
              <TouchableOpacity
                style={styles.viewDetailsButton}
                onPress={() => setShowProductDetails(prev => !prev)}
                activeOpacity={0.7}
              >
                <Text style={styles.viewDetailsText}>
                  View Product Details {showProductDetails ? '▴' : '▾'}
                </Text>
              </TouchableOpacity>

              {/* Expanded Product Details Card — instantly shown/hidden */}
              {showProductDetails && (
                <View style={styles.expandedDetailsCard}>
                  {/* Service Icons Section */}
                  <View style={styles.serviceIconsContainer}>
                    <View style={styles.serviceIconItem}>
                      <View style={[styles.serviceIconCircle, { backgroundColor: '#381230' }]}>
                        <View style={styles.serviceIconImageContainer}>
                          <ReplacementIcon size={16} color="#FFFFFF" />
                        </View>
                        <View style={styles.serviceIconTextContainer}>
                          <Text style={styles.serviceIconTextWhite}>72 Hours</Text>
                          <Text style={styles.serviceIconTextWhite}>Replacement</Text>
                        </View>
                      </View>
                    </View>
                    <View style={styles.serviceIconItem}>
                      <View style={[styles.serviceIconCircle, { backgroundColor: '#381230' }]}>
                        <View style={styles.serviceIconImageContainer}>
                          <SupportIcon size={16} color="#FFFFFF" />
                        </View>
                        <View style={styles.serviceIconTextContainer}>
                          <Text style={styles.serviceIconTextWhite}>24*7</Text>
                          <Text style={styles.serviceIconTextWhite}>Support</Text>
                        </View>
                      </View>
                    </View>
                    <View style={styles.serviceIconItem}>
                      <View style={[styles.serviceIconCircle, { backgroundColor: '#381230' }]}>
                        <View style={styles.serviceIconImageContainer}>
                          <FastDeliveryIcon size={21} color="#FFFFFF" />
                        </View>
                        <View style={styles.serviceIconTextContainer}>
                          <Text style={styles.serviceIconTextWhite}>Fast</Text>
                          <Text style={styles.serviceIconTextWhite}>Delivery</Text>
                        </View>
                      </View>
                    </View>
                  </View>

                  {/* Information Section */}
                  <TouchableOpacity
                    style={styles.expandableSection}
                    onPress={() => setShowInformation(prev => !prev)}
                    activeOpacity={0.7}
                  >
                    <Text style={styles.expandableSectionText}>Information</Text>
                    <Text style={styles.expandableSectionChevron}>
                      {showInformation ? '▴' : '▾'}
                    </Text>
                  </TouchableOpacity>
                  {showInformation && (
                    <View style={styles.expandedSectionContent}>
                      <Text style={styles.sectionContentText}>
                        {product.description || 'No description available.'}
                      </Text>
                      <Text style={[styles.sectionContentText, { marginTop: 12 }]}>
                        Brand: {product.name.split(' ')[0] || 'Delfi'}{'\n'}
                        Weight: {product.weight || '500g'}{'\n'}
                        Category: {product.category || 'N/A'}{'\n'}
                        Country of Origin: India{'\n'}
                        Storage: Store in a cool, dry place{'\n'}
                        Best Before: See package for details
                      </Text>
                    </View>
                  )}
                </View>
              )}
            </View>

            {/* Similar Products Section - Category-wise with View More */}
            {product && (
              <>
                {loadingSimilar ? (
                  <View style={styles.similarProductsSection}>
                    <Text style={[styles.similarProductsTitle, { color: colors.text }]}>
                      Similar Products
                    </Text>
                    <ActivityIndicator size="small" color={colors.primary} style={{ marginVertical: 20 }} />
                  </View>
                ) : Object.keys(groupProductsByCategory).length === 0 ? (
                  <View style={styles.similarProductsSection}>
                    <Text style={[styles.similarProductsTitle, { color: colors.text }]}>
                      Similar Products
                    </Text>
                    <View style={styles.noSimilarProducts}>
                      <Text style={[styles.noSimilarProductsText, { color: colors.textSecondary }]}>
                        No similar products found
                      </Text>
                    </View>
                  </View>
                ) : (
                  <View style={styles.similarProductsSection}>
                    <Text style={[styles.similarProductsTitle, { color: colors.text }]}>
                      Similar Products
                    </Text>
                    {Object.entries(groupProductsByCategory).map(([categoryName, categoryProducts]) => {
                      const displayProducts = categoryProducts.slice(0, 3);
                      const hasMoreProducts = categoryProducts.length > 3;

                      const listData = [...displayProducts];
                      if (hasMoreProducts) {
                        listData.push({ _id: 'view-more', isViewMore: true, categoryName } as any);
                      }

                      return (
                        <View key={categoryName} style={styles.categorySection}>
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
                              length: 150 + 12,
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
                              return <SimilarProductCard item={item as Product} />;
                            }}
                          />
                        </View>
                      );
                    })}
                  </View>
                )}
              </>
            )}
          </ScrollView>
        </View>
      </ThemedLayout>
    </GestureHandlerRootView>
  );
};

const styles = StyleSheet.create({
  container: {
    flex: 1,
    overflow: 'hidden',
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
    overflow: 'hidden',
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
    marginTop: 10,
    marginBottom: 20,
    padding: 16,
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
    marginBottom: 8,
  },
  productNameContainer: {
    flex: 1,
    marginRight: 8,
  },
  productName: {
    fontSize: 18,
    fontWeight: 'bold',
    fontFamily: 'Alexandria-Bold',
    lineHeight: 22,
    color: '#381230',
  },
  productWeight: {
    fontSize: 14,
    fontFamily: 'Alexandria-Regular',
    color: '#381230',
    marginTop: 2,
  },
  heartButton: {
    padding: 5,
    marginTop: 2,
  },
  productCategoryLabel: {
    fontSize: 12,
    marginBottom: 10,
    fontFamily: 'Alexandria-Regular',
    color: '#381230',
  },
  priceRatingRow: {
    flexDirection: 'row',
    alignItems: 'center',
    justifyContent: 'space-between',
    marginBottom: 12,
  },
  productPrice: {
    fontSize: 14,
    fontWeight: 'bold',
    fontFamily: 'Alexandria-Bold',
    color: '#381230',
  },
  ratingRow: {
    flexDirection: 'row',
    alignItems: 'center',
  },
  ratingCount: {
    fontSize: 11,
    marginLeft: 3,
    fontFamily: 'Alexandria-Regular',
    color: '#381230',
  },
  vegIndicator: {
    width: 12,
    height: 12,
    borderRadius: 2,
    marginLeft: 6,
  },
  viewDetailsSeparator: {
    height: 1,
    backgroundColor: '#E0E0E0',
    marginTop: 12,
    marginBottom: 12,
  },
  viewDetailsButton: {
    paddingVertical: 10,
  },
  viewDetailsText: {
    fontSize: 13,
    fontFamily: 'Alexandria-Regular',
    color: '#381230',
  },
  expandedDetailsContainer: {
    overflow: 'hidden',
  },
  expandedDetailsCard: {
    paddingTop: 12,
    paddingBottom: 12,
  },
  expandedDetails: {
    paddingTop: 12,
    paddingBottom: 12,
  },
  productDescription: {
    fontSize: 13,
    lineHeight: 20,
    fontFamily: 'Alexandria-Regular',
    color: '#381230',
  },
  serviceIconsContainer: {
    flexDirection: 'row',
    justifyContent: 'space-around',
    marginTop: 15,
    marginBottom: 15,
    paddingVertical: 15,
    backgroundColor: '#FFFFFF',
    borderRadius: 12,
  },
  serviceIconItem: {
    alignItems: 'center',
    flex: 1,
  },
  serviceIconCircle: {
    width: 100,
    height: 100,
    borderRadius: 50,
    backgroundColor: '#381230',
    justifyContent: 'center',
    alignItems: 'center',
    paddingVertical: 8,
    paddingHorizontal: 4,
  },
  serviceIconImageContainer: {
    marginBottom: 2,
    alignItems: 'center',
    justifyContent: 'center',
  },
  serviceIconTextContainer: {
    alignItems: 'center',
    justifyContent: 'center',
  },
  serviceIconText: {
    fontSize: 10,
    textAlign: 'center',
    fontFamily: 'Alexandria-Regular',
    paddingHorizontal: 4,
  },
  serviceIconTextWhite: {
    fontSize: 8,
    textAlign: 'center',
    fontFamily: 'Alexandria-Regular',
    color: '#FFFFFF',
    paddingHorizontal: 2,
    lineHeight: 10,
    includeFontPadding: false,
  },
  expandableSection: {
    paddingVertical: 16,
    paddingHorizontal: 16,
    marginTop: 12,
    borderTopWidth: 1,
    borderTopColor: '#E0E0E0',
    flexDirection: 'row',
    justifyContent: 'space-between',
    alignItems: 'center',
    backgroundColor: '#FFFFFF',
    borderRadius: 12,
    marginHorizontal: 0,
  },
  expandableSectionText: {
    fontSize: 14,
    fontFamily: 'Alexandria-Regular',
    color: '#381230',
    fontWeight: '500',
  },
  expandableSectionChevron: {
    fontSize: 18,
    fontFamily: 'Alexandria-Regular',
    color: '#381230',
    fontWeight: 'bold',
  },
  expandedSectionContent: {
    marginTop: 8,
    marginBottom: 8,
    paddingTop: 12,
    paddingBottom: 12,
    paddingHorizontal: 16,
    backgroundColor: '#FFFFFF',
    borderRadius: 12,
    marginHorizontal: 0,
  },
  sectionContentText: {
    fontSize: 13,
    lineHeight: 22,
    fontFamily: 'Alexandria-Regular',
    color: '#381230',
  },
  similarProductsSection: {
    marginBottom: 20,
  },
  similarProductsTitle: {
    fontSize: 18,
    fontWeight: 'bold',
    marginHorizontal: 20,
    marginBottom: 12,
    fontFamily: 'Alexandria-Bold',
  },
  noSimilarProducts: {
    padding: 20,
    alignItems: 'center',
  },
  noSimilarProductsText: {
    fontSize: 14,
    fontStyle: 'italic',
    fontFamily: 'Alexandria-Regular',
  },
  categorySection: {
    marginBottom: 12,
  },
  categoryProductsContainer: {
    paddingHorizontal: 20,
    paddingRight: 5,
    paddingVertical: 4,
    alignItems: 'center',
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
    color: '#FFFFFF',
    fontFamily: 'Alexandria-Bold',
    lineHeight: 16,
  },
  horizontalLikeButton: {
    padding: 2,
  },
});

export default ProductDetailScreenEnhanced;
