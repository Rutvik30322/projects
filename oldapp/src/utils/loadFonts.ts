// Font loading utility - fonts are already linked via react-native-asset
// This function ensures fonts are ready (fonts are automatically available after linking)
export const loadAlexandriaFonts = async (): Promise<void> => {
  try {
    // Try to use expo-font if available (optional)
    try {
      const Font = require('expo-font');
      if (Font && typeof Font.loadAsync === 'function') {
        await Font.loadAsync({
          'Alexandria-Regular': require('../assets/fonts/Alexandria-Regular.ttf'),
          'Alexandria-Medium': require('../assets/fonts/Alexandria-Medium.ttf'),
          'Alexandria-SemiBold': require('../assets/fonts/Alexandria-SemiBold.ttf'),
          'Alexandria-Bold': require('../assets/fonts/Alexandria-Bold.ttf'),
          'Alexandria-Light': require('../assets/fonts/Alexandria-Light.ttf'),
        });
        console.log('✅ Alexandria fonts loaded via expo-font');
        return;
      }
    } catch (expoFontError) {
      // expo-font not available or not needed
    }
    
    // Fonts are already linked via react-native-asset, so they're available
    // Just add a small delay to ensure everything is ready
    await new Promise<void>(resolve => setTimeout(() => resolve(), 100));
    console.log('✅ Alexandria fonts available (linked via react-native-asset)');
  } catch (error) {
    // Fonts are still available via react-native-asset even if this fails
    console.log('ℹ️ Alexandria fonts available (linked via react-native-asset)');
  }
};
