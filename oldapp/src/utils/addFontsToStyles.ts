// Utility to add Alexandria fonts to text styles based on fontWeight
// This helps automatically apply fonts to existing styles

export const getFontFamily = (fontWeight?: string | number): string => {
  if (!fontWeight) return 'Alexandria-Regular';
  
  if (fontWeight === 'bold' || fontWeight === '700' || fontWeight === 700) {
    return 'Alexandria-Bold';
  }
  if (fontWeight === '600' || fontWeight === 600 || fontWeight === 'semibold') {
    return 'Alexandria-SemiBold';
  }
  if (fontWeight === '500' || fontWeight === 500 || fontWeight === 'medium') {
    return 'Alexandria-Medium';
  }
  if (fontWeight === '300' || fontWeight === 300 || fontWeight === 'light') {
    return 'Alexandria-Light';
  }
  
  return 'Alexandria-Regular';
};

// Helper to add fontFamily to a text style object
export const addFontToStyle = (style: any): any => {
  if (!style || typeof style !== 'object') return style;
  
  // If it's a text style (has fontSize, fontWeight, or textAlign) and no fontFamily
  if (('fontSize' in style || 'fontWeight' in style || 'textAlign' in style) && !style.fontFamily) {
    return {
      ...style,
      fontFamily: getFontFamily(style.fontWeight),
    };
  }
  
  return style;
};
