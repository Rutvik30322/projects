# How to Apply Alexandria Font Globally

The `createStyles` utility automatically adds Alexandria font to all text styles.

## Usage

Replace `StyleSheet.create` with `createStyles`:

**Before:**
```typescript
import { StyleSheet } from 'react-native';

const styles = StyleSheet.create({
  text: {
    fontSize: 16,
    fontWeight: 'bold',
  },
});
```

**After:**
```typescript
import { createStyles } from '../utils/createStyles';

const styles = createStyles({
  text: {
    fontSize: 16,
    fontWeight: 'bold', // Will automatically use Alexandria-Bold
  },
});
```

## Automatic Font Selection

The utility automatically selects the font based on `fontWeight`:
- `fontWeight: 'bold'` or `'700'` → `Alexandria-Bold`
- `fontWeight: '600'` or `'semibold'` → `Alexandria-SemiBold`
- `fontWeight: '500'` or `'medium'` → `Alexandria-Medium`
- `fontWeight: '300'` or `'light'` → `Alexandria-Light`
- Default → `Alexandria-Regular`

## Manual Override

If you need a specific font, you can still set `fontFamily` manually:
```typescript
const styles = createStyles({
  text: {
    fontSize: 16,
    fontFamily: 'Alexandria-Medium', // Manual override
  },
});
```
