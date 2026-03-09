import { StyleSheet, TextStyle, ViewStyle, ImageStyle } from 'react-native';

// Default font family
const DEFAULT_FONT = 'Alexandria-Regular';
const BOLD_FONT = 'Alexandria-Bold';
const MEDIUM_FONT = 'Alexandria-Medium';
const SEMIBOLD_FONT = 'Alexandria-SemiBold';
const LIGHT_FONT = 'Alexandria-Light';

// Check if a style object is a text style (has fontSize or is likely text)
const isTextStyle = (style: any): style is TextStyle => {
  if (!style || typeof style !== 'object') return false;
  // If it has fontSize, fontWeight, or textAlign, it's likely a text style
  return 'fontSize' in style || 'fontWeight' in style || 'textAlign' in style;
};

// Determine font weight based on fontWeight property
const getFontFamily = (style: TextStyle): string => {
  const fontWeight = style.fontWeight;
  if (fontWeight === 'bold' || fontWeight === '700' || fontWeight === 700) {
    return BOLD_FONT;
  }
  if (fontWeight === '600' || fontWeight === 600) {
    return SEMIBOLD_FONT;
  }
  if (fontWeight === '500' || fontWeight === 'medium' || fontWeight === 500) {
    return MEDIUM_FONT;
  }
  if (fontWeight === '300' || fontWeight === 'light' || fontWeight === 300) {
    return LIGHT_FONT;
  }
  return DEFAULT_FONT;
};

// Enhanced StyleSheet.create that automatically adds fonts to text styles
export const createStyles = <T extends Record<string, ViewStyle | TextStyle | ImageStyle>>(styles: T): T => {
  const enhancedStyles: any = {};
  
  Object.keys(styles).forEach(key => {
    const style = styles[key] as any;
    
    if (isTextStyle(style) && !style.fontFamily) {
      // Add font family based on fontWeight
      enhancedStyles[key] = {
        ...style,
        fontFamily: getFontFamily(style as TextStyle),
      } as TextStyle;
    } else {
      enhancedStyles[key] = style;
    }
  });
  
  return StyleSheet.create(enhancedStyles) as T;
};

// Export regular StyleSheet for non-text styles
export { StyleSheet };
