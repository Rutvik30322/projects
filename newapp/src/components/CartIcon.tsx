import React from 'react';
import { Image, StyleSheet } from 'react-native';
import { useTheme } from '../context/ThemeContext';

interface CartIconProps {
  size?: number;
  focused?: boolean;
  color?: string;
}

const CartIcon: React.FC<CartIconProps> = ({ size = 24, focused = false, color }) => {
  const { colors, theme } = useTheme();

  return (
    <Image
      source={require('../assets/svgs/PINK-&-PURPLE-LOG-DETAILS 1.png')}
      style={[styles.icon, { width: size, height: size }]}
      resizeMode="contain"
    />
  );
};

const styles = StyleSheet.create({
  icon: {
    tintColor: undefined, // Keep original colors from PNG
  },
});

export default CartIcon;
