// Global text style configuration with Alexandria font
// Use this as a base style for all Text components

import { TextStyle } from 'react-native';

export const globalTextStyle: TextStyle = {
  fontFamily: 'Alexandria-Regular',
};

// Text styles with different font weights
export const textStyles = {
  regular: { fontFamily: 'Alexandria-Regular' } as TextStyle,
  medium: { fontFamily: 'Alexandria-Medium' } as TextStyle,
  semiBold: { fontFamily: 'Alexandria-SemiBold' } as TextStyle,
  bold: { fontFamily: 'Alexandria-Bold' } as TextStyle,
  light: { fontFamily: 'Alexandria-Light' } as TextStyle,
};

// Helper function to create text styles with font
export const createTextStyleWithFont = (style: TextStyle, weight: 'regular' | 'medium' | 'bold' | 'light' | 'semiBold' = 'regular'): TextStyle => {
  return {
    ...textStyles[weight],
    ...style,
  };
};
