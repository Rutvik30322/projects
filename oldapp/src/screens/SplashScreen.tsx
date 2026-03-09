import React, { useEffect } from 'react';
import { View, Text, Image, ActivityIndicator } from 'react-native';
import { useTheme } from '../context/ThemeContext';
import ThemedLayout from '../components/ThemedLayout';
import Logo from '../components/Logo';
import { createStyles } from '../utils/createStyles';

const SplashScreen: React.FC<{ navigation: any }> = ({ navigation }) => {
  const { colors, theme } = useTheme();

  useEffect(() => {
    // Navigate to home screen after 5 seconds
    const timer = setTimeout(() => {
      navigation.replace('HomeTabs');
    }, 5000);

    return () => clearTimeout(timer);
    
    // OLD CODE - Navigate to login screen after 5 seconds
    // const timer = setTimeout(() => {
    //   navigation.replace('Login');
    // }, 5000);
  }, [navigation]);

  return (
    <ThemedLayout>
      <View style={[styles.container, { backgroundColor: colors.background }]}>
      <View style={styles.content}>
        {/* App Logo/Icon */}
        <View style={styles.logoContainer}>
          <Logo size={150} />
        </View>
        
        {/* App Title */}
        <Text style={[styles.title, { color: colors.text }]}>dabbo</Text>
        
        {/* Tagline */}
        <Text style={[styles.tagline, { color: colors.textSecondary }]}>
          Premium Chocolate Experience
        </Text>
        
        {/* Loading indicator */}
        <ActivityIndicator 
          size="large" 
          color={colors.primary} 
          style={styles.loader}
        />
      </View>
      
      {/* Footer */}
      <Text style={[styles.footer, { color: colors.textSecondary }]}>
        Made with ❤️ for chocolate lovers
      </Text>
    </View>
    </ThemedLayout>
  );
};

const styles = createStyles({
  container: {
    flex: 1,
    justifyContent: 'space-between',
    alignItems: 'center',
    padding: 20,
  },
  content: {
    flex: 1,
    justifyContent: 'center',
    alignItems: 'center',
    width: '100%',
  },
  logoContainer: {
    width: 180,
    height: 180,
    borderRadius: 90,
    backgroundColor: '#FFFFFF',
    justifyContent: 'center',
    alignItems: 'center',
    marginBottom: 20,
    elevation: 5,
    shadowColor: '#000',
    shadowOffset: { width: 0, height: 2 },
    shadowOpacity: 0.25,
    shadowRadius: 3.84,
    overflow: 'hidden',
  },
  title: {
    fontSize: 32,
    fontWeight: 'bold',
    marginBottom: 10,
    textAlign: 'center',
    fontFamily: 'Alexandria-Bold',
  },
  tagline: {
    fontSize: 16,
    marginBottom: 30,
    textAlign: 'center',
    fontFamily: 'Alexandria-Regular',
  },
  loader: {
    marginTop: 20,
  },
  footer: {
    fontSize: 12,
    marginBottom: 20,
    textAlign: 'center',
  },
});

export default SplashScreen;