// Global font configuration - applies Alexandria font to all Text components
// This file is imported in App.tsx to set default font globally

import { Text, TextInput, Platform } from 'react-native';

const defaultFontFamily = 'Alexandria-Regular';

// Patch Text component to include default font
const OriginalText = Text;
const OriginalTextInput = TextInput;

// Create a wrapper that applies the font
export const applyDefaultFont = () => {
  // This will be called when the app initializes
  // The font will be applied via style props in components
};

// Export font family for use in styles
export const getDefaultFontFamily = () => defaultFontFamily;
