import React, { useState, useEffect } from 'react';
import { 
  View, 
  Text, 
  StyleSheet, 
  TextInput, 
  TouchableOpacity, 
  Platform,
  Image,
  Dimensions,
  useWindowDimensions
} from 'react-native';
import { KeyboardAwareScrollView } from 'react-native-keyboard-aware-scroll-view';
import { useTheme } from '../context/ThemeContext';
import Toast from 'react-native-toast-message';
import ThemedLayout from '../components/ThemedLayout';
import MoonIcon from '../components/MoonIcon';
import PhoneIcon from '../components/PhoneIcon';
import LockIcon from '../components/LockIcon';
import EyeCloseIcon from '../components/EyeCloseIcon';
import EyeOpenIcon from '../components/EyeOpenIcon';
import { useAppDispatch, useAppSelector } from '../store/hooks';
import { login, clearError, clearSuccess } from '../store/slices/authSlice';

const { width: screenWidth } = Dimensions.get('window');

const LoginScreen: React.FC<{ navigation: any }> = ({ navigation }) => {
  const { colors, theme, toggleTheme } = useTheme();
  const dispatch = useAppDispatch();
  const { isLoading, error, success, isAuthenticated } = useAppSelector((state) => state.auth);
  const windowDimensions = useWindowDimensions();
  
  const [mobileNumber, setMobileNumber] = useState('');
  const [password, setPassword] = useState('');
  const [showPassword, setShowPassword] = useState(false);
  const [requiresOtp, setRequiresOtp] = useState(false);

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
        text1: 'Login Failed',
        text2: error,
        visibilityTime: 3000,
      });
      dispatch(clearError());
    }
  }, [error, dispatch]);

  // Handle success messages
  useEffect(() => {
    if (success) {
      if (success.includes('OTP')) {
        // OTP required - navigate to OTP screen
        setRequiresOtp(true);
        navigation.navigate('LoginOTP', { mobile: mobileNumber });
      } else {
      Toast.show({
        type: 'success',
        text1: 'Success',
        text2: success,
        visibilityTime: 2000,
      });
      }
      dispatch(clearSuccess());
    }
  }, [success, dispatch, navigation, mobileNumber]);

  const handleLogin = async () => {
    // Validation
    if (!mobileNumber || !password) {
      Toast.show({
        type: 'error',
        text1: 'Error',
        text2: 'Please enter both mobile number and password',
        visibilityTime: 2000,
      });
      return;
    }

    // Mobile validation (10 digits)
    if (!/^\d{10}$/.test(mobileNumber)) {
      Toast.show({
        type: 'error',
        text1: 'Error',
        text2: 'Please enter a valid 10-digit mobile number',
        visibilityTime: 2000,
      });
      return;
    }

    // Password validation (minimum length)
    if (password.length < 6) {
      Toast.show({
        type: 'error',
        text1: 'Error',
        text2: 'Password must be at least 6 characters',
        visibilityTime: 2000,
      });
      return;
    }

    // Reset OTP requirement
    setRequiresOtp(false);
    const result = await dispatch(login({ mobile: mobileNumber, password }));
    
    // Check if OTP is required
    if (result.type === 'auth/login/fulfilled' && result.payload?.requiresOtp) {
      navigation.navigate('LoginOTP', { mobile: mobileNumber });
    }
  };

  return (
    <ThemedLayout>
      <View style={styles.root}>
        {/* FIXED BACKGROUND LAYER - Never moves, positioned relative to screen */}
        <View style={styles.backgroundLayer}>
          <View style={styles.bottomShape}>
            <View style={styles.bottomShapeCurve} />
          </View>
        </View>

        {/* SCROLLABLE CONTENT LAYER */}
        <KeyboardAwareScrollView
          style={styles.scrollView}
          contentContainerStyle={styles.scrollContainer}
          enableOnAndroid={true}
          enableAutomaticScroll={true}
          extraScrollHeight={120}
          keyboardOpeningTime={0}
          keyboardShouldPersistTaps="handled"
          showsVerticalScrollIndicator={false}
        >
          {/* Header with Theme Toggle */}
          <View style={styles.header}>
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

          {/* Welcome Message */}
          <Text style={styles.title}>Welcome Back!</Text>
          <Text style={styles.subtitle}>
            Login To Your ChocoDelight Account
          </Text>

          {/* Login Form Card */}
          <View style={styles.formCard}>
            {/* Mobile Number Input */}
            <View style={styles.inputRow}>
              <PhoneIcon size={16} color="#381230" />
              <TextInput
                style={styles.input}
                placeholder="Mobile Number"
                placeholderTextColor="#000000"
                value={mobileNumber}
                onChangeText={setMobileNumber}
                keyboardType="phone-pad"
                autoCapitalize="none"
                returnKeyType="next"
              />
            </View>
            <View style={styles.underline} />

            {/* Password Input */}
            <View style={styles.inputRow}>
              <LockIcon size={16} color="#381230" />
              <TextInput
                style={[styles.input, styles.passwordInput]}
                placeholder="Password"
                placeholderTextColor="#000000"
                value={password}
                onChangeText={setPassword}
                secureTextEntry={!showPassword}
                autoCapitalize="none"
                returnKeyType="done"
              />
              <TouchableOpacity 
                onPress={() => setShowPassword(!showPassword)}
                style={styles.eyeButton}
              >
                {showPassword ? (
                  <EyeOpenIcon size={16} color="#381230" />
                ) : (
                <EyeCloseIcon size={16} color="#381230" />
                )}
              </TouchableOpacity>
            </View>
            <View style={styles.underline} />

            {/* Remember me */}
            <View style={styles.rememberMeContainer}>
              <Text style={styles.rememberMe}>Remember me</Text>
            </View>

            {/* Login Button */}
            <TouchableOpacity 
              style={styles.loginButton}
              onPress={handleLogin}
              disabled={isLoading}
            >
              <Text style={styles.loginButtonText}>
                {isLoading ? 'LOGGING IN...' : 'LOGIN'}
              </Text>
            </TouchableOpacity>

            {/* Sign Up Link */}
            <View style={styles.signupContainer}>
              <Text style={styles.signupText}>
                Don't have an account?{' '}
              </Text>
              <TouchableOpacity onPress={() => navigation.navigate('SignUp')}>
                <Text style={styles.signupLink}>Sign Up</Text>
              </TouchableOpacity>
            </View>
          </View>

          {/* Forgot Password Link */}
          <TouchableOpacity 
            style={styles.forgotPasswordButton} 
            onPress={() => navigation.navigate('ForgotPassword')}
          >
            <Text style={styles.forgotPasswordText}>Forgot password?</Text>
          </TouchableOpacity>
        </KeyboardAwareScrollView>
      </View>
    </ThemedLayout>
  );
};

const styles = StyleSheet.create({
  root: {
    flex: 1,
    backgroundColor: '#FFFFFF',
    overflow: 'hidden',
    position: 'relative',
  },
  backgroundLayer: {
    position: 'absolute',
    bottom: 0,
    left: 0,
    right: 0,
    width: '100%',
    height: 500,
    zIndex: 0,
    pointerEvents: 'none',
    elevation: 0,
    // Fixed at bottom - will NOT scroll or move with keyboard
    // Positioned absolutely outside scroll system
  },
  scrollView: {
    flex: 1,
    backgroundColor: 'transparent',
    zIndex: 1,
    // Ensure scroll view doesn't affect background layer
  },
  scrollContainer: {
    flexGrow: 1,
    paddingBottom: 350,
    backgroundColor: 'transparent',
    zIndex: 1,
    // Content can scroll, but background stays fixed
  },
  header: {
    flexDirection: 'row',
    justifyContent: 'flex-end',
    paddingTop: 20,
    paddingRight: 20,
    paddingBottom: 10,
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
    backgroundColor: '#F4F4F4',
    borderRadius: 20,
    padding: 14,
    marginHorizontal: 50,
    marginBottom: 15,
    marginTop: 30,
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
  rememberMeContainer: {
    marginLeft: 28,
    marginBottom: 14,
  },
  rememberMe: {
    fontSize: 11,
    fontFamily: 'Alexandria-Regular',
    color: '#666666',
  },
  loginButton: {
    backgroundColor: '#381230',
    borderRadius: 12,
    padding: 12,
    alignItems: 'center',
    marginBottom: 12,
  },
  loginButtonText: {
    fontSize: 12,
    fontWeight: 'bold',
    fontFamily: 'Alexandria-Bold',
    color: '#FFFFFF',
    letterSpacing: 0.6,
  },
  signupContainer: {
    alignItems: 'center',
  },
  signupText: {
    fontSize: 11,
    fontFamily: 'Alexandria-Regular',
    color: '#000000',
  },
  signupLink: {
    fontSize: 11,
    fontFamily: 'Alexandria-Regular',
    color: '#381230',
    textDecorationLine: 'underline',
  },
  forgotPasswordButton: {
    alignItems: 'center',
    marginTop: 10,
  },
  forgotPasswordText: {
    fontSize: 14,
    fontFamily: 'Alexandria-Regular',
    color: '#FFFFFF',
  },
  bottomShape: {
    position: 'absolute',
    bottom: 0,
    width: '100%',
    height: 350,
    backgroundColor: '#381230',
    borderTopLeftRadius: 50,
    borderTopRightRadius: 50,
  },
  bottomShapeCurve: {
    position: 'absolute',
    top: 100,
    width: '100%',
    height: 350,
    backgroundColor: '#381230',
    borderTopLeftRadius: 200,
    borderTopRightRadius: 200,
  },
});

export default LoginScreen;
