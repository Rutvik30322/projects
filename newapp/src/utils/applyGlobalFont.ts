// This utility helps apply Alexandria font globally
// Import this in App.tsx to ensure fonts are configured

import { StyleSheet } from 'react-native';

// Default font family
export const DEFAULT_FONT = 'Alexandria-Regular';

// Helper to add font to any style
export const withFont = (style: any) => {
  if (Array.isArray(style)) {
    return [{ fontFamily: DEFAULT_FONT }, ...style];
  }
  return { fontFamily: DEFAULT_FONT, ...style };
};

// Create a custom StyleSheet that automatically adds font
export const createTextStyle = (styles: any) => {
  const textStyles: any = {};
  Object.keys(styles).forEach(key => {
    const style = styles[key];
    if (style && typeof style === 'object') {
      textStyles[key] = {
        fontFamily: DEFAULT_FONT,
        ...style,
      };
    } else {
      textStyles[key] = style;
    }
  });
  return StyleSheet.create(textStyles);
};
