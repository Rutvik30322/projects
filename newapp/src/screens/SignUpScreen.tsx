import React, { useState, useEffect } from 'react';
import { View, Text, StyleSheet, TextInput, TouchableOpacity, Platform, Image, Dimensions } from 'react-native';
import { KeyboardAwareScrollView } from 'react-native-keyboard-aware-scroll-view';
import { useTheme } from '../context/ThemeContext';
import Toast from 'react-native-toast-message';
import ThemedLayout from '../components/ThemedLayout';
import PhoneIcon from '../components/PhoneIcon';
import UserIcon from '../components/UserIcon';
import EmailIcon from '../components/EmailIcon';
import LockIcon from '../components/LockIcon';
import EyeCloseIcon from '../components/EyeCloseIcon';
import EyeOpenIcon from '../components/EyeOpenIcon';
import MoonIcon from '../components/MoonIcon';
import { useAppDispatch, useAppSelector } from '../store/hooks';
import { register, clearError, clearSuccess } from '../store/slices/authSlice';

const { width: screenWidth } = Dimensions.get('window');

const SignUpScreen: React.FC<{ navigation: any }> = ({ navigation }) => {
  const { colors, theme, toggleTheme } = useTheme();
  const dispatch = useAppDispatch();
  const { isLoading, error, success, isAuthenticated } = useAppSelector((state) => state.auth);
  
  const [name, setName] = useState('');
  const [email, setEmail] = useState('');
  const [mobileNumber, setMobileNumber] = useState('');
  const [password, setPassword] = useState('');
  const [confirmPassword, setConfirmPassword] = useState('');
  const [showPassword, setShowPassword] = useState(false);
  const [showConfirmPassword, setShowConfirmPassword] = useState(false);

  // Handle authentication state changes
  useEffect(() => {
    if (isAuthenticated) {
      navigation.replace('HomeTabs');
    }
  }, [isAuthenticated, navigation]);

  // Handle error messages
  useEffect(() => {
    if (error) {
      Toast.show({
        type: 'error',
        text1: 'Registration Failed',
        text2: error,
        visibilityTime: 3000,
      });
      dispatch(clearError());
    }
  }, [error, dispatch]);

  // Handle success messages
  useEffect(() => {
    if (success) {
      Toast.show({
        type: 'success',
        text1: 'Success',
        text2: success,
        visibilityTime: 2000,
      });
      dispatch(clearSuccess());
    }
  }, [success, dispatch]);

  const handleSignUp = async () => {
    // Validation - Check all fields are filled
    if (!name || !email || !mobileNumber || !password || !confirmPassword) {
      Toast.show({
        type: 'error',
        text1: 'Error',
        text2: 'Please fill in all fields',
        visibilityTime: 2000,
      });
      return;
    }

    // Name validation
    const trimmedName = name.trim();
    if (trimmedName.length < 2) {
      Toast.show({
        type: 'error',
        text1: 'Error',
        text2: 'Name must be at least 2 characters',
        visibilityTime: 2000,
      });
      return;
    }

    if (trimmedName.length > 50) {
      Toast.show({
        type: 'error',
        text1: 'Error',
        text2: 'Name must be less than 50 characters',
        visibilityTime: 2000,
      });
      return;
    }

    // Email validation
    const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    if (!emailRegex.test(email.trim())) {
      Toast.show({
        type: 'error',
        text1: 'Error',
        text2: 'Please enter a valid email address',
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

    // Password validation
    if (password.length < 6) {
      Toast.show({
        type: 'error',
        text1: 'Error',
        text2: 'Password must be at least 6 characters',
        visibilityTime: 2000,
      });
      return;
    }

    if (password.length > 50) {
      Toast.show({
        type: 'error',
        text1: 'Error',
        text2: 'Password must be less than 50 characters',
        visibilityTime: 2000,
      });
      return;
    }

    // Password confirmation validation
    if (password !== confirmPassword) {
      Toast.show({
        type: 'error',
        text1: 'Error',
        text2: 'Passwords do not match',
        visibilityTime: 2000,
      });
      return;
    }

    // Dispatch register action
    dispatch(register({ name: trimmedName, email: email.trim(), mobile: mobileNumber, password }));
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
          <Text style={styles.title}>Create Account</Text>
          <Text style={styles.subtitle}>
          Join ChocoDelight and enjoy delicious chocolates
        </Text>

          {/* Form Card */}
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

            {/* Full Name Input */}
            <View style={styles.inputRow}>
              <UserIcon size={16} color="#381230" />
            <TextInput
                style={styles.input}
                placeholder="Full Name"
                placeholderTextColor="#000000"
              value={name}
              onChangeText={setName}
              autoCapitalize="words"
              returnKeyType="next"
            />
          </View>
            <View style={styles.underline} />

            {/* Email Address Input */}
            <View style={styles.inputRow}>
              <EmailIcon size={16} color="#381230" />
            <TextInput
                style={styles.input}
                placeholder="Email Address"
                placeholderTextColor="#000000"
              value={email}
              onChangeText={setEmail}
              keyboardType="email-address"
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
              returnKeyType="next"
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

            {/* Confirm Password Input */}
            <View style={styles.inputRow}>
              <LockIcon size={16} color="#381230" />
            <TextInput
                style={[styles.input, styles.passwordInput]}
                placeholder="Confirm Password"
                placeholderTextColor="#000000"
              value={confirmPassword}
              onChangeText={setConfirmPassword}
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

            {/* Create Account Button */}
            <TouchableOpacity 
              style={styles.button}
              onPress={handleSignUp}
              disabled={isLoading}
            >
              <Text style={styles.buttonText}>
                {isLoading ? 'CREATING...' : 'CREATE ACCOUNT'}
              </Text>
            </TouchableOpacity>

            {/* Login Link */}
            <View style={styles.signupContainer}>
              <Text style={styles.signupText}>
                Already have an account?{' '}
              </Text>
              <TouchableOpacity onPress={() => navigation.navigate('Login')}>
                <Text style={styles.signupLink}>Login</Text>
              </TouchableOpacity>
            </View>
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

export default SignUpScreen;