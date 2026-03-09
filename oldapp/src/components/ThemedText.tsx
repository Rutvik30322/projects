import React from 'react';
import { Text, TextProps, StyleSheet } from 'react-native';
import { useTheme } from '../context/ThemeContext';

interface ThemedTextProps extends TextProps {
  weight?: 'regular' | 'medium' | 'bold' | 'light' | 'semiBold';
  children: React.ReactNode;
}

const ThemedText: React.FC<ThemedTextProps> = ({ 
  style, 
  weight = 'regular', 
  children, 
  ...props 
}) => {
  const { colors, fonts } = useTheme();
  
  const fontFamily = weight === 'regular' 
    ? fonts.regular 
    : weight === 'medium' 
    ? fonts.medium 
    : weight === 'bold'
    ? fonts.bold
    : fonts.regular;

  return (
    <Text 
      style={[
        { 
          fontFamily,
          color: colors.text,
        },
        style
      ]} 
      {...props}
    >
      {children}
    </Text>
  );
};

export default ThemedText;
