# Alexandria Font Application Guide

This guide explains how to apply Alexandria fonts to all screens in the mobile app.

## Font Mapping

Based on `fontWeight`, use the following font families:

- **Regular** (default, no fontWeight, or '400'): `'Alexandria-Regular'`
- **Medium** ('500' or 'medium'): `'Alexandria-Medium'`
- **SemiBold** ('600' or 'semibold'): `'Alexandria-SemiBold'`
- **Bold** ('bold', '700', or 700): `'Alexandria-Bold'`
- **Light** ('300', 'light', or 300): `'Alexandria-Light'`

## How to Apply

For each text style in your `StyleSheet.create()`, add `fontFamily` based on the `fontWeight`:

### Example 1: Regular Text
```typescript
text: {
  fontSize: 16,
  fontFamily: 'Alexandria-Regular', // Add this
}
```

### Example 2: Bold Text
```typescript
title: {
  fontSize: 20,
  fontWeight: 'bold',
  fontFamily: 'Alexandria-Bold', // Add this
}
```

### Example 3: Medium Weight
```typescript
label: {
  fontSize: 14,
  fontWeight: '500',
  fontFamily: 'Alexandria-Medium', // Add this
}
```

### Example 4: SemiBold
```typescript
buttonText: {
  fontSize: 16,
  fontWeight: '600',
  fontFamily: 'Alexandria-SemiBold', // Add this
}
```

## Already Updated Screens

✅ **HomeScreen.tsx** - All text styles including banner text
✅ **LoginScreen.tsx** - All text styles
✅ **SignUpScreen.tsx** - All text styles
✅ **SplashScreen.tsx** - All text styles

## Remaining Screens to Update

The following screens still need font families added to their text styles:

1. **AllProductsScreen.tsx**
2. **SettingsScreen.tsx**
3. **AddAddressScreen.tsx**
4. **NotificationsScreen.tsx**
5. **AboutScreen.tsx**
6. **ChatbotScreen.tsx**
7. **OrderDetailScreen.tsx**
8. **DeliveryAddressScreen.tsx**
9. **PaymentScreen.tsx**
10. **OrdersScreen.tsx**
11. **ProfileScreen.tsx**
12. **ProductDetailScreen.tsx**
13. **CartScreen.tsx**
14. **ForgotPasswordScreen.tsx**
15. **HelpSupportScreen.tsx**
16. **ThemedLayoutDemoScreen.tsx**
17. **PaymentMethodsScreen.tsx**
18. **ChangePasswordScreen.tsx**

## Quick Update Pattern

For each screen file:

1. Find `StyleSheet.create({`
2. Look for all style objects that have:
   - `fontSize`
   - `fontWeight`
   - `textAlign`
   - Or any text-related properties
3. Add `fontFamily` based on `fontWeight` (see mapping above)
4. If no `fontWeight`, use `'Alexandria-Regular'`

## Helper Function

You can use the helper from `src/utils/addFontsToStyles.ts`:

```typescript
import { getFontFamily } from '../utils/addFontsToStyles';

const styles = StyleSheet.create({
  text: {
    fontSize: 16,
    fontWeight: 'bold',
    fontFamily: getFontFamily('bold'), // Returns 'Alexandria-Bold'
  },
});
```

## TextInput Components

Don't forget to add fonts to `TextInput` styles as well:

```typescript
input: {
  borderWidth: 1,
  borderRadius: 8,
  padding: 15,
  fontSize: 16,
  fontFamily: 'Alexandria-Regular', // Add this
}
```

## Verification

After updating, rebuild the app:
```bash
npm run android
# or
npm run ios
```

All text should now display using the Alexandria font family!
