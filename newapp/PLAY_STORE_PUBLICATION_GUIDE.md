# Google Play Store Publication Guide

This guide covers all the requirements and steps to publish your app on the Google Play Store according to the latest policies (2024-2025).

## ✅ Compliance Checklist

### 1. Target SDK Version
- ✅ **Current**: Target SDK 36 (Android 14+)
- ✅ **Status**: Compliant with latest Play Store requirements

### 2. 64-bit Support
- ✅ **Status**: Enabled
- ✅ **ABIs**: armeabi-v7a, arm64-v8a, x86, x86_64
- All native libraries support 64-bit architecture

### 3. Android 12+ Compatibility
- ✅ **android:exported**: Properly declared in AndroidManifest.xml
- ✅ **Status**: MainActivity has `android:exported="true"`

### 4. Storage Permissions (Android 13+)
- ✅ **READ_EXTERNAL_STORAGE**: Limited to Android 12 and below (maxSdkVersion="32")
- ✅ **READ_MEDIA_IMAGES**: Used for Android 13+ (API 33+)
- ✅ **Runtime Permission Handling**: Updated in ProfileScreen.tsx

### 5. Code Obfuscation & Optimization
- ✅ **ProGuard/R8**: Enabled for release builds
- ✅ **Resource Shrinking**: Enabled
- ✅ **ProGuard Rules**: Configured for React Native and all dependencies

### 6. App Bundle Format
- ✅ **Format**: Using AAB (Android App Bundle) - required by Play Store
- ✅ **Build Command**: `./gradlew bundleRelease`

## 📋 Pre-Publication Requirements

### 1. Privacy Policy
**Required if your app:**
- Collects user data
- Uses sensitive permissions (Camera, Storage, etc.)
- Processes payments (Razorpay)

**Action Required:**
1. Create a privacy policy page on your website
2. Include it in Play Console → App Content → Privacy Policy
3. Add privacy policy URL to your app's About screen (if applicable)

**Privacy Policy Should Cover:**
- What data you collect
- How you use the data
- Third-party services (Razorpay, analytics, etc.)
- User rights (data deletion, access, etc.)

### 2. Data Safety Section
**Required in Play Console:**
1. Go to Play Console → App Content → Data Safety
2. Declare:
   - Data collection (if any)
   - Data sharing
   - Security practices
   - Data deletion options

### 3. Content Rating
**Required:**
1. Complete content rating questionnaire in Play Console
2. Based on your app (e-commerce, payments):
   - Likely rating: "Everyone" or "Teen"
   - May include: User-generated content, Purchases

### 4. App Signing
**Two Options:**

#### Option A: Play App Signing (Recommended)
1. Upload your AAB to Play Console
2. Google manages your signing key
3. You can use debug keystore for first upload
4. Google provides upload certificate for future releases

#### Option B: Your Own Keystore
1. Generate release keystore:
   ```bash
   keytool -genkeypair -v -storetype PKCS12 -keystore my-release-key.keystore -alias my-key-alias -keyalg RSA -keysize 2048 -validity 10000
   ```
2. Store keystore securely (never commit to git)
3. Update `build.gradle` with release signing config
4. Keep backup of keystore and passwords

### 5. App Icons & Graphics
**Required:**
- ✅ App icon (512x512px)
- ✅ Feature graphic (1024x500px)
- ✅ Screenshots (at least 2, up to 8)
- ✅ Promo graphic (optional)

## 🚀 Build & Upload Process

### Step 1: Build Release Bundle
```bash
cd app/android
./gradlew clean
./gradlew bundleRelease
```

**Output Location:**
```
app/android/app/build/outputs/bundle/release/app-release.aab
```

### Step 2: Verify Bundle
- Check bundle size (should be reasonable)
- Verify ProGuard is working (check for obfuscated code)
- Test on different devices if possible

### Step 3: Create Play Console Listing
1. Go to [Google Play Console](https://play.google.com/console)
2. Create new app or select existing
3. Fill in:
   - App name: "dabbo" (or your preferred name)
   - Default language
   - App or game
   - Free or paid

### Step 4: Complete Store Listing
1. **App Details:**
   - Short description (80 chars)
   - Full description (4000 chars)
   - App icon
   - Feature graphic
   - Screenshots

2. **Content Rating:**
   - Complete questionnaire
   - Get rating certificate

3. **Pricing & Distribution:**
   - Select countries
   - Set price (if paid)
   - Content guidelines compliance

4. **Data Safety:**
   - Declare data collection
   - Privacy policy URL
   - Security practices

### Step 5: Upload AAB
1. Go to Production → Create new release
2. Upload `app-release.aab`
3. Add release notes
4. Review and roll out

### Step 6: Testing (Recommended)
1. Create Internal Testing track
2. Add testers
3. Test the release
4. Fix any issues
5. Promote to Production

## 🔒 Security Best Practices

### 1. API Keys
- ✅ **Razorpay Key**: Currently using test key
- ⚠️ **Action Required**: Replace with production key before release
- ⚠️ **Never commit**: Production keys to version control

### 2. Network Security
- ✅ **HTTPS**: All API calls should use HTTPS
- ✅ **Network Security Config**: Configured in `network_security_config.xml`

### 3. ProGuard Rules
- ✅ **Configured**: All React Native libraries protected
- ✅ **Test**: Ensure app works after ProGuard obfuscation

## 📊 Version Management

### Current Version
- **versionCode**: 1
- **versionName**: "1.0"

### For Updates
1. Increment `versionCode` (must be higher than previous)
2. Update `versionName` (user-visible version)
3. Example:
   ```gradle
   versionCode 2
   versionName "1.0.1"
   ```

## ⚠️ Common Issues & Solutions

### Issue: App Rejected - Missing Privacy Policy
**Solution:** Add privacy policy URL in Play Console → App Content → Privacy Policy

### Issue: App Rejected - Target SDK Too Low
**Solution:** Already compliant (SDK 36), but ensure you keep updating

### Issue: App Rejected - Missing 64-bit Support
**Solution:** Already enabled, verify in build.gradle

### Issue: App Crashes After ProGuard
**Solution:** Check ProGuard rules, add keep rules for problematic classes

### Issue: Storage Permission Not Working on Android 13+
**Solution:** Already fixed - using READ_MEDIA_IMAGES for Android 13+

## 📝 Post-Publication

### 1. Monitor
- Crash reports in Play Console
- User reviews
- ANR (Application Not Responding) reports

### 2. Updates
- Regular bug fixes
- Feature updates
- Security patches

### 3. Compliance
- Keep target SDK updated
- Update privacy policy as needed
- Respond to Play Store policy changes

## 🔗 Useful Links

- [Google Play Console](https://play.google.com/console)
- [Play Store Policies](https://play.google.com/about/developer-content-policy/)
- [Data Safety Section Guide](https://support.google.com/googleplay/android-developer/answer/10787469)
- [App Signing Best Practices](https://developer.android.com/studio/publish/app-signing)

## ✅ Final Checklist Before Upload

- [ ] Build release bundle (`./gradlew bundleRelease`)
- [ ] Test on real device
- [ ] Replace test API keys with production keys
- [ ] Create privacy policy
- [ ] Prepare app screenshots and graphics
- [ ] Write app description
- [ ] Complete content rating
- [ ] Fill Data Safety section
- [ ] Review all permissions and their usage
- [ ] Verify ProGuard doesn't break functionality
- [ ] Check app size (should be reasonable)
- [ ] Test payment flow (if applicable)
- [ ] Verify all features work correctly

---

**Last Updated:** 2024
**Target SDK:** 36 (Android 14+)
**Min SDK:** 24 (Android 7.0+)
