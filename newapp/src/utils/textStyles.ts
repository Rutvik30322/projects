import { TextStyle } from 'react-native';

// Default text style with Alexandria font
export const defaultTextStyle: TextStyle = {
  fontFamily: 'Alexandria-Regular',
};

// Text styles with different weights
export const textStyles = {
  regular: {
    fontFamily: 'Alexandria-Regular',
  } as TextStyle,
  medium: {
    fontFamily: 'Alexandria-Medium',
  } as TextStyle,
  semiBold: {
    fontFamily: 'Alexandria-SemiBold',
  } as TextStyle,
  bold: {
    fontFamily: 'Alexandria-Bold',
  } as TextStyle,
  light: {
    fontFamily: 'Alexandria-Light',
  } as TextStyle,
};

// Helper to merge font style with existing styles
export const withFont = (style: any, weight: 'regular' | 'medium' | 'bold' | 'light' | 'semiBold' = 'regular') => {
  return [
    textStyles[weight],
    style,
  ].filter(Boolean);
};
