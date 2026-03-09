import React, { useState, useEffect } from 'react';
import { View, Text, StyleSheet, TextInput, TouchableOpacity, Platform, ActivityIndicator, Image, Dimensions } from 'react-native';
import { KeyboardAwareScrollView } from 'react-native-keyboard-aware-scroll-view';
import { useTheme } from '../context/ThemeContext';
import Toast from 'react-native-toast-message';
import ThemedLayout from '../components/ThemedLayout';
import MoonIcon from '../components/MoonIcon';
import OtpIcon from '../components/OtpIcon';
import { useAppDispatch, useAppSelector } from '../store/hooks';
import { verifyLoginOtp, sendLoginOtp, clearError, clearSuccess } from '../store/slices/authSlice';

const { width: screenWidth } = Dimensions.get('window');

const LoginOTPScreen: React.FC<{ navigation: any; route: any }> = ({ navigation, route }) => {
  const { colors, theme, toggleTheme } = useTheme();
  const dispatch = useAppDispatch();
  const { isLoading, error, success, isAuthenticated } = useAppSelector((state) => state.auth);
  
  const mobile = route.params?.mobile || '';
  const [otp, setOtp] = useState('');
  const [resendTimer, setResendTimer] = useState(60);

  // Timer for resend OTP
  useEffect(() => {
    if (resendTimer > 0) {
      const timer = setTimeout(() => setResendTimer(resendTimer - 1), 1000);
      return () => clearTimeout(timer);
    }
  }, [resendTimer]);

  // Handle authentication state changes
  useEffect(() => {
    if (isAuthenticated) {
      navigation.replace('HomeTabs', {
        screen: 'Home',
      });
    }
  }, [isAuthenticated, navigation]);

  // Handle error messages
  useEffect(() => {
    if (error) {
      Toast.show({
        type: 'error',
        text1: 'Error',
        text2: error,
        visibilityTime: 3000,
      });
      dispatch(clearError());
    }
  }, [error, dispatch]);

  // Handle success messages
  useEffect(() => {
    if (success && !success.includes('OTP')) {
      Toast.show({
        type: 'success',
        text1: 'Success',
        text2: success,
        visibilityTime: 2000,
      });
      dispatch(clearSuccess());
    }
  }, [success, dispatch]);

  const handleVerifyOtp = async () => {
    if (!otp.trim()) {
      Toast.show({
        type: 'error',
        text1: 'Error',
        text2: 'Please enter the OTP',
        visibilityTime: 2000,
      });
      return;
    }

    if (!/^[0-9]{6}$/.test(otp)) {
      Toast.show({
        type: 'error',
        text1: 'Error',
        text2: 'Please enter a valid 6-digit OTP',
        visibilityTime: 2000,
      });
      return;
    }

    dispatch(verifyLoginOtp({ mobile, otp }));
  };

  const handleResendOtp = async () => {
    if (resendTimer > 0) return;
    
    try {
      dispatch(sendLoginOtp(mobile));
      setResendTimer(60);
      Toast.show({
        type: 'success',
        text1: 'OTP Sent',
        text2: 'OTP has been resent to your mobile number',
        visibilityTime: 2000,
      });
    } catch (error: any) {
      Toast.show({
        type: 'error',
        text1: 'Error',
        text2: 'Failed to resend OTP. Please try again.',
        visibilityTime: 2000,
      });
    }
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
          <Text style={styles.title}>Enter OTP</Text>
          <Text style={styles.subtitle}>
            We've sent a 6-digit OTP to {mobile.substring(0, 2)}****{mobile.substring(6)}
          </Text>

          {/* Form Card */}
          <View style={styles.formCard}>
            <View style={styles.inputRow}>
              <OtpIcon size={16} color="#381230" />
              <TextInput
                style={[styles.input, styles.otpInput]}
                placeholder="000000"
                placeholderTextColor="#000000"
                value={otp}
                onChangeText={(text) => setOtp(text.replace(/[^0-9]/g, '').substring(0, 6))}
                keyboardType="number-pad"
                maxLength={6}
                returnKeyType="done"
                editable={!isLoading}
              />
            </View>
            <View style={styles.underline} />

            <TouchableOpacity 
              style={styles.button}
              onPress={handleVerifyOtp}
              disabled={isLoading}
            >
              {isLoading ? (
                <ActivityIndicator size="small" color="#FFFFFF" />
              ) : (
                <Text style={styles.buttonText}>
                  VERIFY OTP
                </Text>
              )}
            </TouchableOpacity>

            <View style={styles.resendContainer}>
              <Text style={styles.resendText}>
                Didn't receive OTP?{' '}
              </Text>
              {resendTimer > 0 ? (
                <Text style={styles.resendTimer}>
                  Resend in {resendTimer}s
                </Text>
              ) : (
                <TouchableOpacity onPress={handleResendOtp}>
                  <Text style={styles.resendLink}>
                    Resend OTP
                  </Text>
                </TouchableOpacity>
              )}
            </View>

            <TouchableOpacity 
              style={styles.backButton}
              onPress={() => navigation.goBack()}
            >
              <Text style={styles.backButtonText}>
                Change Mobile Number
              </Text>
            </TouchableOpacity>
          </View>
        </KeyboardAwareScrollView>
      </View>
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
    fontSize: 11,
    fontFamily: 'Alexandria-Regular',
    color: '#381230',
    textDecorationLine: 'underline',
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
  otpInput: {
    textAlign: 'center',
    fontSize: 20,
    letterSpacing: 8,
    fontFamily: 'Alexandria-Bold',
  },
  underline: {
    height: 1,
    backgroundColor: '#E0E0E0',
    marginBottom: 12,
    marginLeft: 28,
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
  resendContainer: {
    flexDirection: 'row',
    justifyContent: 'center',
    alignItems: 'center',
    marginTop: 10,
  },
  resendText: {
    fontSize: 11,
    fontFamily: 'Alexandria-Regular',
    color: '#000000',
  },
  resendTimer: {
    fontSize: 11,
    fontFamily: 'Alexandria-Regular',
    color: '#000000',
  },
  resendLink: {
    fontSize: 11,
    fontFamily: 'Alexandria-Regular',
    color: '#381230',
    textDecorationLine: 'underline',
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
});

export default LoginOTPScreen;
