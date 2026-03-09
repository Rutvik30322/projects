import React from 'react';
import { View, Image, StyleSheet, Text } from 'react-native';

interface LogoProps {
  size?: number;
  style?: any;
  showText?: boolean;
}

const Logo: React.FC<LogoProps> = ({ size = 100, style, showText = false }) => {
  // Using WHITE-ICON.png from app/src/assets/
  
  return (
    <View style={[styles.container, style]}>
      <Image
        source={require('../assets/WHITE-ICON.png')}
        style={[styles.logo, { width: size, height: size }]}
        resizeMode="contain"
        onError={(error) => {
          console.warn('Logo image not found. Please add WHITE-ICON.png to app/src/assets/');
        }}
      />
      {showText && (
        <Text style={styles.logoText}>dabbo</Text>
      )}
    </View>
  );
};

const styles = StyleSheet.create({
  container: {
    alignItems: 'center',
    justifyContent: 'center',
  },
  logo: {
    // Image will be sized by the size prop
  },
  logoText: {
    marginTop: 8,
    fontSize: 18,
    fontWeight: 'bold',
    color: '#6b46c1',
  },
});

export default Logo;