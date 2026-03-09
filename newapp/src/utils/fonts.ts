// Font configuration for Alexandria font family
export const fonts = {
  regular: 'Alexandria-Regular',
  medium: 'Alexandria-Medium',
  semiBold: 'Alexandria-SemiBold',
  bold: 'Alexandria-Bold',
  light: 'Alexandria-Light',
};

// Default font family for the app
export const defaultFontFamily = fonts.regular;

// Helper function to get font family based on weight
export const getFontFamily = (weight: 'regular' | 'medium' | 'bold' | 'light' | 'semiBold' = 'regular') => {
  return fonts[weight];
};
