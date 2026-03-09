import React, { useState } from 'react';
import { View, Text, StyleSheet, TextInput, TouchableOpacity, Platform, ActivityIndicator, Image, Dimensions } from 'react-native';
import { KeyboardAwareScrollView } from 'react-native-keyboard-aware-scroll-view';
import { useTheme } from '../context/ThemeContext';
import Toast from 'react-native-toast-message';
import ThemedLayout from '../components/ThemedLayout';
import MoonIcon from '../components/MoonIcon';
import PhoneIcon from '../components/PhoneIcon';
import OtpIcon from '../components/OtpIcon';
import LockIcon from '../components/LockIcon';
import EyeCloseIcon from '../components/EyeCloseIcon';
import EyeOpenIcon from '../components/EyeOpenIcon';
import authService from '../services/authService';

const { width: screenWidth } = Dimensions.get('window');

const ForgotPasswordScreen: React.FC<{ navigation: any }> = ({ navigation }) => {
  const { colors, theme, toggleTheme } = useTheme();
  const [step, setStep] = useState<'mobile' | 'otp' | 'reset'>('mobile');
  const [mobile, setMobile] = useState('');
  const [otp, setOtp] = useState('');
  const [newPassword, setNewPassword] = useState('');
  const [confirmPassword, setConfirmPassword] = useState('');
  const [loading, setLoading] = useState(false);
  const [sendingOtp, setSendingOtp] = useState(false);
  const [resendTimer, setResendTimer] = useState(0);
  const [showNewPassword, setShowNewPassword] = useState(false);
  const [showConfirmPassword, setShowConfirmPassword] = useState(false);

  // Timer for resend OTP
  React.useEffect(() => {
    if (resendTimer > 0) {
      const timer = setTimeout(() => setResendTimer(resendTimer - 1), 1000);
      return () => clearTimeout(timer);
    }
  }, [resendTimer]);

  const handleSendOtp = async () => {
    if (!mobile.trim()) {
      Toast.show({
        type: 'error',
        text1: 'Error',
        text2: 'Please enter your mobile number',
        visibilityTime: 2000,
      });
      return;
    }

    if (!/^[0-9]{10}$/.test(mobile)) {
      Toast.show({
        type: 'error',
        text1: 'Error',
        text2: 'Please enter a valid 10-digit mobile number',
        visibilityTime: 2000,
      });
      return;
    }

    try {
      setSendingOtp(true);
      const response = await authService.sendOtp(mobile);
      
      Toast.show({
        type: 'success',
        text1: 'OTP Sent',
        text2: 'OTP has been sent to your mobile number',
        visibilityTime: 3000,
      });
      
      setStep('otp');
      setResendTimer(60); // 60 seconds timer
    } catch (error: any) {
      Toast.show({
        type: 'error',
        text1: 'Error',
        text2: error.message || 'Failed to send OTP. Please try again.',
        visibilityTime: 3000,
      });
    } finally {
      setSendingOtp(false);
    }
  };

  const handleResendOtp = async () => {
    if (resendTimer > 0) return;
    
    await handleSendOtp();
  };

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

    try {
      setLoading(true);
      const response = await authService.verifyOtp(mobile, otp);
      
      Toast.show({
        type: 'success',
        text1: 'OTP Verified',
        text2: 'OTP verified successfully',
        visibilityTime: 2000,
      });
      
      setStep('reset');
    } catch (error: any) {
      Toast.show({
        type: 'error',
        text1: 'Error',
        text2: error.message || 'Invalid OTP. Please try again.',
        visibilityTime: 3000,
      });
    } finally {
      setLoading(false);
    }
  };

  const handleResetPassword = async () => {
    if (!newPassword.trim() || !confirmPassword.trim()) {
      Toast.show({
        type: 'error',
        text1: 'Error',
        text2: 'Please enter both password fields',
        visibilityTime: 2000,
      });
      return;
    }

    if (newPassword.length < 6) {
      Toast.show({
        type: 'error',
        text1: 'Error',
        text2: 'Password must be at least 6 characters long',
        visibilityTime: 2000,
      });
      return;
    }

    if (newPassword !== confirmPassword) {
      Toast.show({
        type: 'error',
        text1: 'Error',
        text2: 'Passwords do not match',
        visibilityTime: 2000,
      });
      return;
    }

    try {
      setLoading(true);
      const response = await authService.resetPassword(mobile, otp, newPassword);
      
      Toast.show({
        type: 'success',
        text1: 'Password Reset',
        text2: 'Your password has been reset successfully',
        visibilityTime: 3000,
      });
      
      // Navigate back to login after a delay
      setTimeout(() => {
        navigation.navigate('Login');
      }, 2000);
    } catch (error: any) {
      Toast.show({
        type: 'error',
        text1: 'Error',
        text2: error.message || 'Failed to reset password. Please try again.',
        visibilityTime: 3000,
      });
    } finally {
      setLoading(false);
    }
  };

  const renderMobileStep = () => (
    <>
      <Text style={styles.title}>Forgot Password?</Text>
      <Text style={styles.subtitle}>
        Enter your mobile number and we'll send you an OTP to reset your password
      </Text>

      <View style={styles.formCard}>
        <View style={styles.inputRow}>
          <PhoneIcon size={16} color="#381230" />
          <TextInput
            style={styles.input}
            placeholder="Mobile Number"
            placeholderTextColor="#000000"
            value={mobile}
            onChangeText={setMobile}
            keyboardType="phone-pad"
            maxLength={10}
            returnKeyType="done"
            editable={!sendingOtp}
          />
        </View>
        <View style={styles.underline} />

        <TouchableOpacity 
          style={styles.button}
          onPress={handleSendOtp}
          disabled={sendingOtp}
        >
          {sendingOtp ? (
            <ActivityIndicator size="small" color="#FFFFFF" />
          ) : (
            <Text style={styles.buttonText}>
              SEND OTP
            </Text>
          )}
        </TouchableOpacity>
      </View>
    </>
  );

  const renderOtpStep = () => (
    <>
      <Text style={styles.title}>Enter OTP</Text>
      <Text style={styles.subtitle}>
        We've sent a 6-digit OTP to {mobile.substring(0, 2)}****{mobile.substring(6)}
      </Text>

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
            editable={!loading}
          />
        </View>
        <View style={styles.underline} />

        <TouchableOpacity 
          style={styles.button}
          onPress={handleVerifyOtp}
          disabled={loading}
        >
          {loading ? (
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
          onPress={() => {
            setStep('mobile');
            setOtp('');
          }}
        >
          <Text style={styles.backButtonText}>
            Change Mobile Number
          </Text>
        </TouchableOpacity>
      </View>
    </>
  );

  const renderResetStep = () => (
    <>
      <Text style={styles.title}>Reset Password</Text>
      <Text style={styles.subtitle}>
        Enter your new password
      </Text>

      <View style={styles.formCard}>
        <View style={styles.inputRow}>
          <LockIcon size={16} color="#381230" />
          <TextInput
            style={[styles.input, styles.passwordInput]}
            placeholder="New Password"
            placeholderTextColor="#000000"
            value={newPassword}
            onChangeText={setNewPassword}
            secureTextEntry={!showNewPassword}
            returnKeyType="next"
            editable={!loading}
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
            placeholder="Confirm Password"
            placeholderTextColor="#000000"
            value={confirmPassword}
            onChangeText={setConfirmPassword}
            secureTextEntry={!showConfirmPassword}
            returnKeyType="done"
            editable={!loading}
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
          onPress={handleResetPassword}
          disabled={loading}
        >
          {loading ? (
            <ActivityIndicator size="small" color="#FFFFFF" />
          ) : (
            <Text style={styles.buttonText}>
              RESET PASSWORD
            </Text>
          )}
        </TouchableOpacity>
      </View>
    </>
  );

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

        {/* Step Content */}
        {step === 'mobile' && renderMobileStep()}
        {step === 'otp' && renderOtpStep()}
        {step === 'reset' && renderResetStep()}

        {/* Back to Login */}
        <TouchableOpacity 
            style={styles.backToLoginButton}
          onPress={() => navigation.navigate('Login')}
        >
            <Text style={styles.backToLoginText}>
            Back to Login
          </Text>
        </TouchableOpacity>
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
  backButton: {
    alignItems: 'center',
    marginTop: 10,
  },
  backButtonText: {
    fontSize: 11,
    fontFamily: 'Alexandria-Regular',
    color: '#381230',
    textDecorationLine: 'underline',
  },
  backToLoginButton: {
    alignItems: 'center',
    marginTop: 20,
  },
  backToLoginText: {
    fontSize: 14,
    fontFamily: 'Alexandria-Regular',
    color: '#FFFFFF',
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

export default ForgotPasswordScreen;
