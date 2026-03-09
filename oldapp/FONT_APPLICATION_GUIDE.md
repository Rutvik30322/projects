# Applying Alexandria Font Globally

The Alexandria fonts are linked and ready to use. To apply them throughout the app, add `fontFamily` to your text styles.

## Quick Application

Add `fontFamily: 'Alexandria-Regular'` (or other weights) to your StyleSheet text styles:

```typescript
const styles = StyleSheet.create({
  text: {
    fontSize: 16,
    fontFamily: 'Alexandria-Regular', // Add this
  },
  boldText: {
    fontSize: 18,
    fontWeight: 'bold',
    fontFamily: 'Alexandria-Bold', // Add this
  },
});
```

## Available Font Weights

- `'Alexandria-Regular'` - Regular weight
- `'Alexandria-Medium'` - Medium weight
- `'Alexandria-SemiBold'` - SemiBold weight
- `'Alexandria-Bold'` - Bold weight
- `'Alexandria-Light'` - Light weight

## Using the Helper

You can use the `textStyles` utility from `src/utils/globalTextStyle.ts`:

```typescript
import { textStyles } from '../utils/globalTextStyle';

const styles = StyleSheet.create({
  text: {
    ...textStyles.regular,
    fontSize: 16,
  },
  boldText: {
    ...textStyles.bold,
    fontSize: 18,
  },
});
```

## Using ThemedText Component

Use the `ThemedText` component from `src/components/ThemedText.tsx`:

```typescript
import ThemedText from '../components/ThemedText';

<ThemedText weight="bold">Bold Text</ThemedText>
<ThemedText weight="medium">Medium Text</ThemedText>
```

## Note

Fonts are already linked via `react-native-asset`, so they're available immediately. Just add `fontFamily` to your styles to use them.
