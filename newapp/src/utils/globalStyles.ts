import { StyleSheet, Platform } from 'react-native';

// Global text styles with Alexandria font
export const globalTextStyles = StyleSheet.create({
  default: {
    fontFamily: Platform.select({
      ios: 'Alexandria-Regular',
      android: 'Alexandria-Regular',
      default: 'Alexandria-Regular',
    }),
  },
  regular: {
    fontFamily: Platform.select({
      ios: 'Alexandria-Regular',
      android: 'Alexandria-Regular',
      default: 'Alexandria-Regular',
    }),
  },
  medium: {
    fontFamily: Platform.select({
      ios: 'Alexandria-Medium',
      android: 'Alexandria-Medium',
      default: 'Alexandria-Medium',
    }),
  },
  semiBold: {
    fontFamily: Platform.select({
      ios: 'Alexandria-SemiBold',
      android: 'Alexandria-SemiBold',
      default: 'Alexandria-SemiBold',
    }),
  },
  bold: {
    fontFamily: Platform.select({
      ios: 'Alexandria-Bold',
      android: 'Alexandria-Bold',
      default: 'Alexandria-Bold',
    }),
  },
  light: {
    fontFamily: Platform.select({
      ios: 'Alexandria-Light',
      android: 'Alexandria-Light',
      default: 'Alexandria-Light',
    }),
  },
});

// Helper function to get font family
export const getFontFamily = (weight: 'regular' | 'medium' | 'bold' | 'light' | 'semiBold' = 'regular') => {
  const fontMap = {
    regular: 'Alexandria-Regular',
    medium: 'Alexandria-Medium',
    semiBold: 'Alexandria-SemiBold',
    bold: 'Alexandria-Bold',
    light: 'Alexandria-Light',
  };
  return fontMap[weight];
};
