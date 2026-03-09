import React, { useState } from 'react';
import { View, Text, StyleSheet, TouchableOpacity, TextInput, Platform, Dimensions, Image } from 'react-native';
import { KeyboardAwareScrollView } from 'react-native-keyboard-aware-scroll-view';
import { useTheme } from '../context/ThemeContext';
import Toast from 'react-native-toast-message';
import ThemedLayout from '../components/ThemedLayout';
import MoonIcon from '../components/MoonIcon';
import LockIcon from '../components/LockIcon';
import EyeCloseIcon from '../components/EyeCloseIcon';
import EyeOpenIcon from '../components/EyeOpenIcon';

const { width: screenWidth } = Dimensions.get('window');

const ChangePasswordScreen: React.FC<{ navigation: any }> = ({ navigation }) => {
  const { colors, theme, toggleTheme } = useTheme();
  const [currentPassword, setCurrentPassword] = useState('');
  const [newPassword, setNewPassword] = useState('');
  const [confirmNewPassword, setConfirmNewPassword] = useState('');
  const [showConfirmationModal, setShowConfirmationModal] = useState(false);
  const [showCurrentPassword, setShowCurrentPassword] = useState(false);
  const [showNewPassword, setShowNewPassword] = useState(false);
  const [showConfirmPassword, setShowConfirmPassword] = useState(false);

  const handleChangePassword = () => {
    // Validation
    if (!currentPassword.trim()) {
      Toast.show({
        type: 'error',
        text1: 'Validation Error',
        text2: 'Please enter your current password',
        visibilityTime: 2000,
      });
      return;
    }

    if (!newPassword.trim()) {
      Toast.show({
        type: 'error',
        text1: 'Validation Error',
        text2: 'Please enter a new password',
        visibilityTime: 2000,
      });
      return;
    }

    if (newPassword.length < 6) {
      Toast.show({
        type: 'error',
        text1: 'Validation Error',
        text2: 'New password must be at least 6 characters long',
        visibilityTime: 2000,
      });
      return;
    }

    if (newPassword !== confirmNewPassword) {
      Toast.show({
        type: 'error',
        text1: 'Validation Error',
        text2: 'New passwords do not match',
        visibilityTime: 2000,
      });
      return;
    }

    // Show confirmation modal
    setShowConfirmationModal(true);
  };

  const confirmChangePassword = () => {
    // Here you would typically make an API call to change the password
    Toast.show({
      type: 'success',
      text1: 'Password Changed',
      text2: 'Your password has been changed successfully!',
      visibilityTime: 3000,
    });

    setShowConfirmationModal(false);
    navigation.goBack();
  };

  const cancelChangePassword = () => {
    setShowConfirmationModal(false);
  };

  return (
    <ThemedLayout>
      <View style={styles.container}>
        {/* Curved Bottom Shape - Behind everything - Fixed position */}
        <View style={styles.bottomShapeContainer}>
          <View style={styles.bottomShape}>
            <View style={styles.bottomShapeCurve} />
          </View>
        </View>

        <KeyboardAwareScrollView
          contentContainerStyle={styles.scrollContainer}
          enableOnAndroid={true}
          extraScrollHeight={20}
          keyboardShouldPersistTaps="handled"
          showsVerticalScrollIndicator={false}
        >
          {/* Header with Theme Toggle */}
          <View style={styles.header}>
            <TouchableOpacity onPress={() => navigation.goBack()} style={styles.backButton}>
              <Text style={styles.backButtonText}>←</Text>
            </TouchableOpacity>
            <TouchableOpacity onPress={toggleTheme} style={styles.themeToggle}>
              <MoonIcon size={24} color="#381230" />
            </TouchableOpacity>
          </View>

          {/* Logo */}
          <View style={styles.logoContainer}>
            <Image 
              source={require('../assets/PINK-&-PURPLE-LOG-DETAILS (1) 1.png')}
              style={styles.logoImage}
              resizeMode="contain"
            />
          </View>

          {/* Title */}
          <Text style={styles.title}>Change Password</Text>
          <Text style={styles.subtitle}>
            Update your password to keep your account secure
          </Text>

          {/* Form Card */}
          <View style={styles.formCard}>
            <View style={styles.inputRow}>
              <LockIcon size={16} color="#381230" />
              <TextInput
                style={[styles.input, styles.passwordInput]}
                placeholder="Current Password"
                placeholderTextColor="#000000"
                value={currentPassword}
                onChangeText={setCurrentPassword}
                secureTextEntry={!showCurrentPassword}
                autoCapitalize="none"
                returnKeyType="next"
              />
              <TouchableOpacity 
                onPress={() => setShowCurrentPassword(!showCurrentPassword)}
                style={styles.eyeButton}
              >
                {showCurrentPassword ? (
                  <EyeOpenIcon size={16} color="#381230" />
                ) : (
                  <EyeCloseIcon size={16} color="#381230" />
                )}
              </TouchableOpacity>
            </View>
            <View style={styles.underline} />

            <View style={styles.inputRow}>
              <LockIcon size={16} color="#381230" />
            <TextInput
                style={[styles.input, styles.passwordInput]}
                placeholder="New Password"
                placeholderTextColor="#000000"
              value={newPassword}
              onChangeText={setNewPassword}
                secureTextEntry={!showNewPassword}
                autoCapitalize="none"
                returnKeyType="next"
              />
              <TouchableOpacity 
                onPress={() => setShowNewPassword(!showNewPassword)}
                style={styles.eyeButton}
              >
                {showNewPassword ? (
                  <EyeOpenIcon size={16} color="#381230" />
                ) : (
                  <EyeCloseIcon size={16} color="#381230" />
                )}
              </TouchableOpacity>
          </View>
            <View style={styles.underline} />

            <View style={styles.inputRow}>
              <LockIcon size={16} color="#381230" />
            <TextInput
                style={[styles.input, styles.passwordInput]}
                placeholder="Confirm New Password"
                placeholderTextColor="#000000"
              value={confirmNewPassword}
              onChangeText={setConfirmNewPassword}
                secureTextEntry={!showConfirmPassword}
                autoCapitalize="none"
                returnKeyType="done"
              />
              <TouchableOpacity 
                onPress={() => setShowConfirmPassword(!showConfirmPassword)}
                style={styles.eyeButton}
              >
                {showConfirmPassword ? (
                  <EyeOpenIcon size={16} color="#381230" />
                ) : (
                  <EyeCloseIcon size={16} color="#381230" />
                )}
              </TouchableOpacity>
          </View>
            <View style={styles.underline} />

          <TouchableOpacity
              style={styles.button}
            onPress={handleChangePassword}
          >
              <Text style={styles.buttonText}>CHANGE PASSWORD</Text>
          </TouchableOpacity>
        </View>
        </KeyboardAwareScrollView>
      </View>
      {/* Confirmation Modal */}
      {showConfirmationModal && (
        <View style={styles.modalOverlay}>
          <View style={[styles.modalContent, { backgroundColor: colors.surface }]}>
            <Text style={[styles.modalTitle, { color: colors.text }]}>Confirm Password Change</Text>
            <Text style={[styles.modalMessage, { color: colors.text }]}>
              Are you sure you want to change your password?
            </Text>

            <View style={styles.modalButtons}>
              <TouchableOpacity
                style={[styles.modalCancelButton, { backgroundColor: colors.textSecondary }]}
                onPress={cancelChangePassword}
              >
                <Text style={[styles.modalButtonText, { color: colors.background }]}>Cancel</Text>
              </TouchableOpacity>

              <TouchableOpacity
                style={[styles.modalConfirmButton, { backgroundColor: colors.primary }]}
                onPress={confirmChangePassword}
              >
                <Text style={[styles.modalButtonText, { color: colors.onPrimary }]}>Confirm</Text>
              </TouchableOpacity>
            </View>
          </View>
        </View>
      )}
    </ThemedLayout>
  );
};

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: '#FFFFFF',
    position: 'relative',
  },
  scrollContainer: {
    flexGrow: 1,
    paddingBottom: 150,
  },
  header: {
    flexDirection: 'row',
    justifyContent: 'space-between',
    alignItems: 'center',
    paddingTop: 20,
    paddingHorizontal: 20,
    paddingBottom: 10,
  },
  backButton: {
    padding: 5,
  },
  backButtonText: {
    fontSize: 24,
    fontWeight: 'bold',
    color: '#381230',
  },
  themeToggle: {
    padding: 5,
  },
  logoContainer: {
    alignItems: 'center',
    marginTop: 20,
    marginBottom: 30,
  },
  logoImage: {
    width: 150,
    height: 80,
  },
  title: {
    fontSize: 25,
    fontWeight: 'bold',
    textAlign: 'center',
    marginBottom: 6,
    fontFamily: 'Alexandria-Bold',
    color: '#000000',
  },
  subtitle: {
    fontSize: 14,
    textAlign: 'center',
    marginBottom: 30,
    paddingHorizontal: 20,
    fontFamily: 'Alexandria-Regular',
    color: '#000000',
  },
  formCard: {
    backgroundColor: '#FFFFFF',
    borderRadius: 20,
    padding: 14,
    marginHorizontal: 50,
    marginBottom: 15,
    marginTop: 60,
    shadowColor: '#000',
    shadowOffset: { width: 0, height: 4 },
    shadowOpacity: 0.15,
    shadowRadius: 10,
    elevation: 5,
    width: screenWidth - 100,
    alignSelf: 'center',
    zIndex: 1,
    position: 'relative',
  },
  inputRow: {
    flexDirection: 'row',
    alignItems: 'center',
    marginBottom: 4,
  },
  input: {
    flex: 1,
    fontSize: 12,
    fontFamily: 'Alexandria-Regular',
    color: '#000000',
    marginLeft: 10,
    paddingVertical: 4,
  },
  passwordInput: {
    paddingRight: 40,
  },
  underline: {
    height: 1,
    backgroundColor: '#E0E0E0',
    marginBottom: 12,
    marginLeft: 28,
  },
  eyeButton: {
    position: 'absolute',
    right: 0,
    padding: 8,
  },
  button: {
    backgroundColor: '#381230',
    borderRadius: 12,
    padding: 12,
    alignItems: 'center',
    marginTop: 20,
    marginBottom: 12,
  },
  buttonText: {
    fontSize: 12,
    fontWeight: 'bold',
    fontFamily: 'Alexandria-Bold',
    color: '#FFFFFF',
    letterSpacing: 0.6,
  },
  bottomShapeContainer: {
    position: 'absolute',
    bottom: 0,
    left: 0,
    right: 0,
    height: 500,
    zIndex: 0,
    overflow: 'hidden',
    width: '100%',
    pointerEvents: 'none',
    elevation: 0,
    ...(Platform.OS === 'android' && {
      position: 'absolute',
      bottom: 0,
    }),
  },
  bottomShape: {
    position: 'absolute',
    bottom: 0,
    left: 0,
    right: 0,
    width: '100%',
    height: 350,
    backgroundColor: '#381230',
    borderTopLeftRadius: 50,
    borderTopRightRadius: 50,
    borderBottomLeftRadius: 0,
    borderBottomRightRadius: 0,
  },
  bottomShapeCurve: {
    position: 'absolute',
    top: 100,
    left: 0,
    right: 0,
    width: '100%',
    height: 350,
    backgroundColor: '#381230',
    borderTopLeftRadius: 200,
    borderTopRightRadius: 200,
  },
  modalOverlay: {
    position: 'absolute',
    top: 0,
    bottom: 0,
    left: 0,
    right: 0,
    backgroundColor: 'rgba(0,0,0,0.5)',
    justifyContent: 'center',
    alignItems: 'center',
    zIndex: 10,
  },
  modalContent: {
    width: '80%',
    maxWidth: 400,
    padding: 20,
    borderRadius: 10,
    elevation: 5,
  },
  modalTitle: {
    fontSize: 18,
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
  modalButtons: {
    flexDirection: 'row',
    justifyContent: 'space-between',
  },
  modalCancelButton: {
    flex: 1,
    padding: 12,
    borderRadius: 8,
    alignItems: 'center',
    marginRight: 5,
  },
  modalConfirmButton: {
    flex: 1,
    padding: 12,
    borderRadius: 8,
    alignItems: 'center',
    marginLeft: 5,
  },
  modalButtonText: {
    fontSize: 16,
    fontWeight: 'bold',
  },
});

export default ChangePasswordScreen;