import React, { useState, useEffect } from 'react';
import { View, Text, StyleSheet, TouchableOpacity, FlatList, Alert, ActivityIndicator, Modal } from 'react-native';
import { useTheme } from '../context/ThemeContext';
import Toast from 'react-native-toast-message';
import ThemedLayout from '../components/ThemedLayout';
import Logo from '../components/Logo';
import DeleteIcon from '../components/DeleteIcon';
import addressService, { Address } from '../services/addressService';
import { useAppSelector } from '../store/hooks';

const DeliveryAddressScreen: React.FC<{ route: any, navigation: any }> = ({ route, navigation }) => {
  const { colors, theme } = useTheme();
  const { isAuthenticated } = useAppSelector((state) => state.auth);
  const [addresses, setAddresses] = useState<Address[]>([]);
  const [loading, setLoading] = useState(true);
  
  // Load addresses from API
  useEffect(() => {
    // Check authentication before loading addresses
    if (!isAuthenticated) {
      setLoading(false);
      Toast.show({
        type: 'error',
        text1: 'Authentication Required',
        text2: 'Please login to view your delivery addresses',
        visibilityTime: 3000,
      });
      return;
    }
    loadAddresses();
  }, [isAuthenticated]);

  // Reload addresses when screen comes into focus
  useEffect(() => {
    const unsubscribe = navigation.addListener('focus', () => {
      if (isAuthenticated) {
        loadAddresses();
      } else {
        setLoading(false);
        Toast.show({
          type: 'error',
          text1: 'Authentication Required',
          text2: 'Please login to view your delivery addresses',
          visibilityTime: 3000,
        });
      }
    });
    
    return unsubscribe;
  }, [navigation, isAuthenticated]);

  const loadAddresses = async () => {
    // Double check authentication before making API call
    if (!isAuthenticated) {
      Toast.show({
        type: 'error',
        text1: 'Authentication Required',
        text2: 'Please login to view your delivery addresses',
        visibilityTime: 3000,
      });
      return;
    }

    try {
      setLoading(true);
      const response = await addressService.getAddresses();
      if (response.data && response.data.addresses) {
        setAddresses(response.data.addresses);
      }
    } catch (error: any) {
      console.error('Failed to load addresses:', error);
      // Check if error is due to authentication
      const errorMessage = error?.message || error?.error || 'Failed to load addresses';
      if (errorMessage.includes('authorized') || errorMessage.includes('token') || errorMessage.includes('401') || errorMessage.includes('authentication')) {
        Toast.show({
          type: 'error',
          text1: 'Authentication Required',
          text2: 'Please login to view your delivery addresses',
          visibilityTime: 3000,
        });
      } else {
        Toast.show({
          type: 'error',
          text1: 'Error',
          text2: errorMessage,
          visibilityTime: 2000,
        });
      }
    } finally {
      setLoading(false);
    }
  };

  // Handle edit address
  const handleEditAddress = (address: Address) => {
    // Format address for editing screen
    const addressData = {
      _id: address._id,
      name: address.name || '',
      address: address.addressLine,
      city: address.city,
      state: address.state,
      pincode: address.pincode,
      phone: address.phone || '',
      type: address.type || 'Home',
      isDefault: address.isDefault,
    };
    navigation.navigate('AddAddress', { addressData });
  };

  // Handle set as default
  const handleSetDefault = async (addressId: string) => {
    try {
      await addressService.setDefaultAddress(addressId);
      await loadAddresses(); // Reload addresses
      Toast.show({
        type: 'success',
        text1: 'Default Address Updated',
        text2: 'This address is now set as your default',
        visibilityTime: 2000,
      });
    } catch (error: any) {
      Toast.show({
        type: 'error',
        text1: 'Error',
        text2: error.message || 'Failed to set default address',
        visibilityTime: 2000,
      });
    }
  };
    
  // State for delete confirmation modal
  const [showDeleteModal, setShowDeleteModal] = useState(false);
  const [deleteAddressId, setDeleteAddressId] = useState<string | null>(null);
  const [deleteAddressName, setDeleteAddressName] = useState('');
    
  // Handle delete address
  const handleDeleteAddress = (address: Address) => {
    setDeleteAddressId(address._id);
    setDeleteAddressName(address.name || 'Address');
    setShowDeleteModal(true);
  };
    
  // Confirm delete address
  const confirmDeleteAddress = async () => {
    if (deleteAddressId) {
      try {
        await addressService.deleteAddress(deleteAddressId);
        await loadAddresses(); // Reload addresses
        Toast.show({
          type: 'success',
          text1: 'Address Deleted',
          text2: `The address "${deleteAddressName}" has been deleted successfully.`,
          visibilityTime: 2000,
        });
      } catch (error: any) {
        Toast.show({
          type: 'error',
          text1: 'Error',
          text2: error.message || 'Failed to delete address',
          visibilityTime: 2000,
        });
      } finally {
        setShowDeleteModal(false);
        setDeleteAddressId(null);
        setDeleteAddressName('');
      }
    }
  };
    
  // Cancel delete
  const cancelDelete = () => {
    setShowDeleteModal(false);
    setDeleteAddressId(null);
    setDeleteAddressName('');
  };
    
  const renderAddress = ({ item }: { item: Address }) => {
    const fullAddress = `${item.addressLine}, ${item.city}, ${item.state} - ${item.pincode}`;
    const addressName = item.name || `${item.type || 'Home'} Address`;
    
    return (
      <View style={[styles.addressCard, { backgroundColor: colors.surface, elevation: 2 }]}>  
        <View style={styles.addressHeader}>
          <View style={{ flexDirection: 'row', alignItems: 'center', gap: 8 }}>
            <Text style={[styles.addressType, { color: colors.primary }]}>
              {item.type === 'Home' ? '🏠' : item.type === 'Office' ? '🏢' : '📍'}
            </Text>
            <Text style={[styles.addressName, { color: colors.text }]}>{addressName}</Text>
          </View>
          {item.isDefault && (
            <Text style={[styles.defaultBadge, { backgroundColor: colors.primary, color: colors.onPrimary }]}>
              Default
            </Text>
          )}
        </View>
        <Text style={[styles.addressText, { color: colors.text }]}>{fullAddress}</Text>
        {item.phone && (
          <Text style={[styles.addressPhone, { color: colors.textSecondary }]}>📞 {item.phone}</Text>
        )}
        <View style={styles.addressActions}>
          {!item.isDefault && (
            <TouchableOpacity 
              style={styles.actionButton}
              onPress={() => handleSetDefault(item._id)}
            >
              <Text style={[styles.actionText, { color: colors.primary }]}>Set Default</Text>
            </TouchableOpacity>
          )}
          <TouchableOpacity 
            style={styles.actionButton}
            onPress={() => handleEditAddress(item)}
          >
            <Text style={[styles.actionText, { color: colors.primary }]}>Edit</Text>
          </TouchableOpacity>
          <TouchableOpacity 
            style={styles.actionButton}
            onPress={() => handleDeleteAddress(item)}
          >
            <Text style={[styles.actionText, { color: colors.error }]}>Delete</Text>
          </TouchableOpacity>
        </View>
      </View>
    );
  };

  return (
    <ThemedLayout edges={['top']}>
      <View style={[styles.container, { backgroundColor: colors.background }]}>  
      {/* Header with back button */}
      <View style={[styles.header, { backgroundColor: colors.surface }]}>  
        <TouchableOpacity 
          style={styles.backButton}
          onPress={() => navigation.goBack()}
        >
          <Text style={[styles.backButtonText, { color: colors.text }]}>←</Text>
        </TouchableOpacity>
        <View style={styles.headerTitleContainer}>
          <Logo size={50} style={styles.headerLogo} />
        <Text style={[styles.headerTitle, { color: colors.text }]}>Delivery Addresses</Text>
        </View>
        <View style={styles.headerSpacer} />
      </View>
      
      {/* Delete Confirmation Modal */}
      <Modal
        visible={showDeleteModal}
        transparent={true}
        animationType="fade"
        onRequestClose={cancelDelete}
      >
        <View style={styles.modalOverlay}>
          <View style={[styles.modalContainer, { backgroundColor: colors.surface }]}>
            <View style={styles.modalIconContainer}>
              <DeleteIcon size={48} color={colors.error} />
            </View>
            
            <Text style={[styles.modalTitle, { color: colors.text }]}>Delete Address</Text>
            <Text style={[styles.modalMessage, { color: colors.textSecondary }]}>
              Are you sure you want to delete the address "{deleteAddressName}"?
            </Text>
            
            <View style={styles.modalButtonContainer}>
              <TouchableOpacity 
                style={[styles.modalCancelButton, { backgroundColor: colors.textSecondary + '20', borderColor: colors.textSecondary }]}
                onPress={cancelDelete}
              >
                <Text style={[styles.modalCancelButtonText, { color: colors.text }]}>Cancel</Text>
              </TouchableOpacity>
              
              <TouchableOpacity 
                style={[styles.modalConfirmButton, { backgroundColor: colors.error }]}
                onPress={confirmDeleteAddress}
              >
                <View style={styles.modalButtonContent}>
                  <DeleteIcon size={18} color={colors.onPrimary} />
                  <Text style={[styles.modalConfirmButtonText, { color: colors.onPrimary }]}>Delete</Text>
                </View>
              </TouchableOpacity>
            </View>
          </View>
        </View>
      </Modal>
      <Text style={[styles.title, { color: colors.text }]}>Delivery Addresses</Text>
      
      {!isAuthenticated ? (
        <View style={styles.emptyContainer}>
          <Text style={[styles.emptyIcon, { color: colors.textSecondary }]}>🔒</Text>
          <Text style={[styles.emptyText, { color: colors.text }]}>Authentication Required</Text>
          <Text style={[styles.emptySubtext, { color: colors.textSecondary }]}>
            Please login to view your delivery addresses
          </Text>
          <TouchableOpacity
            style={[styles.loginButton, { backgroundColor: colors.primary, marginTop: 20 }]}
            onPress={() => navigation.navigate('Login')}
          >
            <Text style={[styles.loginButtonText, { color: colors.onPrimary }]}>
              Go to Login
            </Text>
          </TouchableOpacity>
        </View>
      ) : loading ? (
        <View style={styles.loadingContainer}>
          <ActivityIndicator size="large" color={colors.primary} />
          <Text style={[styles.loadingText, { color: colors.textSecondary }]}>Loading addresses...</Text>
        </View>
      ) : addresses.length === 0 ? (
        <>
          <View style={styles.emptyContainer}>
            <Text style={[styles.emptyIcon, { color: colors.textSecondary }]}>📍</Text>
            <Text style={[styles.emptyText, { color: colors.text }]}>No addresses found</Text>
            <Text style={[styles.emptySubtext, { color: colors.textSecondary }]}>
              Add your first address to get started
            </Text>
          </View>
          <View style={styles.buttonContainer}>
            <TouchableOpacity 
              style={[styles.addButton, { backgroundColor: colors.primary }]}
              onPress={() => navigation.navigate('AddAddress')}>
              <Text style={[styles.addButtonText, { color: colors.onPrimary }]}>Add New Address</Text>
            </TouchableOpacity>
          </View>
        </>
      ) : (
        <>
          <FlatList
            data={addresses}
            renderItem={renderAddress}
            keyExtractor={item => item._id}
            showsVerticalScrollIndicator={false}
            contentContainerStyle={{ paddingBottom: 100 }}
          />
          <View style={styles.buttonContainer}>
            <TouchableOpacity 
              style={[styles.addButton, { backgroundColor: colors.primary }]}
              onPress={() => navigation.navigate('AddAddress')}>
              <Text style={[styles.addButtonText, { color: colors.onPrimary }]}>Add New Address</Text>
            </TouchableOpacity>
          </View>
        </>
      )}
      </View>
    </ThemedLayout>
  );
};

const styles = StyleSheet.create({
  container: {
    flex: 1,
    padding: 20,
  },
  title: {
    fontSize: 24,
    fontWeight: 'bold',
    marginBottom: 20,
  },
  addressCard: {
    padding: 15,
    borderRadius: 10,
    marginBottom: 15,
  },
  addressHeader: {
    flexDirection: 'row',
    justifyContent: 'space-between',
    alignItems: 'center',
    marginBottom: 10,
  },
  addressName: {
    fontSize: 16,
    fontWeight: '500',
  },
  defaultBadge: {
    fontSize: 12,
    fontWeight: 'bold',
    paddingVertical: 2,
    paddingHorizontal: 8,
    borderRadius: 10,
  },
  addressText: {
    fontSize: 14,
    lineHeight: 20,
    marginBottom: 15,
  },
  addressActions: {
    flexDirection: 'row',
    justifyContent: 'flex-end',
  },
  actionButton: {
    marginLeft: 15,
  },
  actionText: {
    fontSize: 14,
    fontWeight: '500',
  },
  buttonContainer: {
    paddingBottom: 90, // Extra padding for bottom navigation bar
  },
  addButton: {
    padding: 15,
    borderRadius: 10,
    alignItems: 'center',
  },
  addButtonText: {
    fontSize: 16,
    fontWeight: 'bold',
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
    backgroundColor: 'rgba(244, 67, 54, 0.1)',
    justifyContent: 'center',
    alignItems: 'center',
    marginBottom: 20,
  },
  modalTitle: {
    fontSize: 24,
    fontWeight: 'bold',
    marginBottom: 10,
    textAlign: 'center',
  },
  modalMessage: {
    fontSize: 16,
    marginBottom: 20,
    textAlign: 'center',
    lineHeight: 22,
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
  },
  modalConfirmButton: {
    flex: 1,
    paddingVertical: 14,
    paddingHorizontal: 20,
    borderRadius: 12,
    alignItems: 'center',
  },
  modalButtonContent: {
    flexDirection: 'row',
    alignItems: 'center',
    justifyContent: 'center',
    gap: 10,
  },
  modalConfirmButtonText: {
    fontSize: 16,
    fontWeight: 'bold',
  },
  header: {
    flexDirection: 'row',
    alignItems: 'center',
    paddingVertical: 15,
    paddingHorizontal: 10,
    marginBottom: 10,
  },
  backButton: {
    padding: 10,
  },
  backButtonText: {
    fontSize: 18,
    fontWeight: 'bold',
  },
  headerTitleContainer: {
    flexDirection: 'row',
    alignItems: 'center',
    flex: 1,
    justifyContent: 'center',
  },
  headerLogo: {
    marginRight: 8,
  },
  headerTitle: {
    flex: 1,
    textAlign: 'center',
    fontSize: 18,
    fontWeight: 'bold',
  },
  headerSpacer: {
    width: 40,
  },
  loadingContainer: {
    flex: 1,
    justifyContent: 'center',
    alignItems: 'center',
    paddingVertical: 40,
  },
  loadingText: {
    marginTop: 10,
    fontSize: 14,
  },
  emptyContainer: {
    flex: 1,
    justifyContent: 'center',
    alignItems: 'center',
    paddingVertical: 60,
  },
  emptyIcon: {
    fontSize: 64,
    marginBottom: 16,
  },
  emptyText: {
    fontSize: 18,
    fontWeight: '600',
    marginBottom: 8,
  },
  emptySubtext: {
    fontSize: 14,
    textAlign: 'center',
  },
  addressType: {
    fontSize: 20,
  },
  addressPhone: {
    fontSize: 14,
    marginTop: 8,
    marginBottom: 12,
  },
  loginButton: {
    paddingVertical: 12,
    paddingHorizontal: 24,
    borderRadius: 8,
    alignItems: 'center',
  },
  loginButtonText: {
    fontSize: 16,
    fontWeight: '600',
  },
});

export default DeliveryAddressScreen;