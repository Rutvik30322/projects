# APK Build Guide

## API Configuration for Production

### 1. Update API URL for Production

Edit `app/src/config/apiConfig.ts` and update the `PRODUCTION_API_URL`:

```typescript
export const PRODUCTION_API_URL = 'https://your-production-domain.com/api';
```

**Important:**
- For **HTTPS**: Use `https://your-domain.com/api` (recommended for production)
- For **HTTP**: Make sure your server IP/domain is added to `network_security_config.xml`

### 2. Update Network Security Config

If using HTTP (not recommended for production), edit:
`app/android/app/src/main/res/xml/network_security_config.xml`

Add your production domain:
```xml
<domain includeSubdomains="true">your-production-domain.com</domain>
```

### 3. Build Release APK

#### Option A: Using Gradle (Recommended)

1. Open terminal in the `app/android` directory
2. Run:
```bash
cd android
./gradlew assembleRelease
```

The APK will be generated at:
`app/android/app/build/outputs/apk/release/app-release.apk`

#### Option B: Using Android Studio

1. Open `app/android` folder in Android Studio
2. Go to **Build** → **Generate Signed Bundle / APK**
3. Select **APK**
4. Create or select a keystore
5. Select **release** build variant
6. Click **Finish**

### 4. Build Signed APK (For Play Store)

1. Generate a keystore (if you don't have one):
```bash
cd android/app
keytool -genkeypair -v -storetype PKCS12 -keystore my-release-key.keystore -alias my-key-alias -keyalg RSA -keysize 2048 -validity 10000
```

2. Create `android/gradle.properties` and add:
```properties
MYAPP_RELEASE_STORE_FILE=my-release-key.keystore
MYAPP_RELEASE_KEY_ALIAS=my-key-alias
MYAPP_RELEASE_STORE_PASSWORD=your-store-password
MYAPP_RELEASE_KEY_PASSWORD=your-key-password
```

3. Update `android/app/build.gradle` to use the keystore (if not already configured)

4. Build:
```bash
cd android
./gradlew assembleRelease
```

### 5. Current API Configuration

- **Development URL**: `http://172.16.10.248:5000/api`
- **Production URL**: Update in `app/src/config/apiConfig.ts`

### 6. Testing the APK

1. Install on device:
```bash
adb install app-release.apk
```

2. Make sure your backend server is accessible from the device
3. Test all API calls

### Notes

- **HTTP vs HTTPS**: For production, always use HTTPS
- **Network Security**: Android 9+ blocks cleartext traffic by default
- **Backend Server**: Ensure your backend is accessible from the internet for production
- **Firewall**: Make sure your server firewall allows connections on port 5000

### Troubleshooting

**Issue: API calls fail in production APK**
- Check if API URL is correct in `apiConfig.ts`
- Verify network security config includes your domain
- Check backend server is accessible
- Check Android logs: `adb logcat | grep -i "network\|api"`

**Issue: Cleartext traffic not allowed**
- Add domain to `network_security_config.xml`
- Or switch to HTTPS
