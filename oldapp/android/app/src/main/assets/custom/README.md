# Alexandria Font Setup

## Instructions to Add Alexandria Font

1. Download Alexandria font family from Google Fonts:
   - Visit: https://fonts.google.com/specimen/Alexandria
   - Download the font family

2. Extract and copy the following font files to this directory (`app/src/assets/fonts/`):
   - `Alexandria-Regular.ttf`
   - `Alexandria-Medium.ttf`
   - `Alexandria-SemiBold.ttf`
   - `Alexandria-Bold.ttf`
   - `Alexandria-Light.ttf`

3. After adding the font files, run:
   ```bash
   npx react-native-asset
   ```
   Or for iOS:
   ```bash
   cd ios && pod install && cd ..
   ```

4. Rebuild the app:
   ```bash
   npm run android
   # or
   npm run ios
   ```

## Font Usage

The Alexandria font is now configured globally. All Text components will use Alexandria-Regular by default.

To use different weights:
- Regular: `fontFamily: 'Alexandria-Regular'`
- Medium: `fontFamily: 'Alexandria-Medium'`
- SemiBold: `fontFamily: 'Alexandria-SemiBold'`
- Bold: `fontFamily: 'Alexandria-Bold'`
- Light: `fontFamily: 'Alexandria-Light'`

Or use the ThemedText component from `src/components/ThemedText.tsx`:
```tsx
import ThemedText from '../components/ThemedText';

<ThemedText weight="bold">Bold Text</ThemedText>
<ThemedText weight="medium">Medium Text</ThemedText>
```
