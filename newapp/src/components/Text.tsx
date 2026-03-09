import React from 'react';
import { Text as RNText, TextProps as RNTextProps, StyleSheet } from 'react-native';
import { useTheme } from '../context/ThemeContext';

interface TextProps extends RNTextProps {
  weight?: 'regular' | 'medium' | 'bold' | 'light' | 'semiBold';
}

const Text: React.FC<TextProps> = ({ style, weight = 'regular', ...props }) => {
  const { fonts } = useTheme();
  
  const fontFamily = weight === 'regular' 
    ? fonts.regular 
    : weight === 'medium' 
    ? fonts.medium 
    : weight === 'bold'
    ? fonts.bold
    : fonts.regular;

  return (
    <RNText 
      style={[
        { fontFamily },
        style
      ]} 
      {...props}
    />
  );
};

export default Text;
