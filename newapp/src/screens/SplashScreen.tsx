import React, { useEffect } from 'react';
import { View, Text } from 'react-native';
import LinearGradient from 'react-native-linear-gradient';
import AsyncStorage from '@react-native-async-storage/async-storage';
import Logo from '../components/Logo';
import { createStyles } from '../utils/createStyles';
import { useAppDispatch } from '../store/hooks';
import { loadUser } from '../store/slices/authSlice';

const SplashScreen: React.FC<{ navigation: any }> = ({ navigation }) => {
  const dispatch = useAppDispatch();

  useEffect(() => {
    const init = async () => {
      try {
        // Silently try to restore a saved session into Redux (no blocking)
        const token = await AsyncStorage.getItem('token');
        const expirationStr = await AsyncStorage.getItem('tokenExpiration');
        const isExpired = expirationStr
          ? Date.now() >= parseInt(expirationStr, 10)
          : true;

        if (token && !isExpired) {
          // Restore session into Redux in background — don't wait for result
          dispatch(loadUser());
        }
      } catch {
        // Ignore any errors — app will work as guest
      }

      // Always navigate to HomeTabs
      // Users can browse without login; Login is triggered on cart/checkout/profile
      navigation.replace('HomeTabs');
    };

    // Show splash for 1.5s then navigate
    const timer = setTimeout(init, 1500);
    return () => clearTimeout(timer);
  }, [navigation, dispatch]);

  return (
    <LinearGradient
      colors={['#4B213FCC', '#381230']}
      start={{ x: 0, y: 0 }}
      end={{ x: 0, y: 1 }}
      style={styles.container}
    >
      <View style={styles.content}>
        <View style={styles.logoContainer}>
          <Logo size={120} />
        </View>
        <Text style={styles.tagline}>
          Premium Chocolate Experience
        </Text>
      </View>
      <Text style={styles.footer}>
        Made with ❤️ for chocolate lovers
      </Text>
    </LinearGradient>
  );
};

const styles = createStyles({
  container: {
    flex: 1,
    justifyContent: 'space-between',
    alignItems: 'center',
    paddingVertical: 40,
  },
  content: {
    flex: 1,
    justifyContent: 'center',
    alignItems: 'center',
    width: '100%',
  },
  logoContainer: {
    width: 160,
    height: 160,
    borderRadius: 24,
    backgroundColor: '#FFFFFF',
    justifyContent: 'center',
    alignItems: 'center',
    marginBottom: 30,
    elevation: 8,
    shadowColor: '#000',
    shadowOffset: { width: 0, height: 4 },
    shadowOpacity: 0.3,
    shadowRadius: 6,
  },
  tagline: {
    fontSize: 16,
    color: '#FFFFFF',
    textAlign: 'center',
    fontFamily: 'Alexandria-Regular',
    letterSpacing: 0.5,
  },
  footer: {
    fontSize: 12,
    color: '#FFFFFF',
    opacity: 0.8,
    textAlign: 'center',
    marginBottom: 20,
  },
});

export default SplashScreen;