# Android Release Keystore Setup Guide

This guide will help you generate a release keystore file for signing your Android App Bundle (AAB) for Google Play Store submission.

## Prerequisites

- Java JDK installed (keytool comes with JDK)
- PowerShell (Windows) or Terminal (Mac/Linux)

## Step 1: Generate Keystore

### Windows (PowerShell)

1. Open PowerShell in the `app/android` directory
2. Run the keystore generation script:

```powershell
.\generate-keystore.ps1
```

3. Follow the prompts to enter:
   - Keystore password (minimum 6 characters)
   - Key password (or press Enter to use same as keystore)
   - Key alias (default: release-key)
   - Validity period in days (default: 10000)

### Manual Method (All Platforms)

If the script doesn't work, you can generate the keystore manually:

```bash
cd app/android/app
keytool -genkeypair -v -storetype PKCS12 -keystore release.keystore -alias release-key -keyalg RSA -keysize 2048 -validity 10000
```

You'll be prompted to enter:
- Keystore password
- Key password
- Your name, organization, etc.

## Step 2: Verify Keystore Generation

After generation, you should have:
- `app/android/app/release.keystore` - The keystore file
- `app/android/app/keystore.properties` - Configuration file with credentials

## Step 3: Secure Your Keystore

⚠️ **IMPORTANT SECURITY NOTES:**

1. **Backup your keystore file** - Store it in a secure location (encrypted backup, password manager, etc.)
2. **Never commit keystore files to Git** - They should be in `.gitignore`
3. **Save your passwords** - You'll need them for future updates
4. **If you lose the keystore**, you cannot update your app on Play Store

### Add to .gitignore

Make sure these files are in your `.gitignore`:

```
app/android/app/release.keystore
app/android/app/keystore.properties
*.keystore
```

## Step 4: Build Release AAB

### Windows (PowerShell)

```powershell
cd app/android
.\build-release-aab.ps1
```

### Manual Build

```bash
cd app/android
./gradlew bundleRelease
```

The AAB file will be located at:
```
app/android/app/build/outputs/bundle/release/app-release.aab
```

## Step 5: Upload to Play Store

1. Go to [Google Play Console](https://play.google.com/console)
2. Select your app
3. Go to **Production** > **Create new release**
4. Upload the `app-release.aab` file
5. Fill in release notes and submit

## Troubleshooting

### "keytool: command not found"

- Make sure Java JDK is installed
- Add JDK bin directory to your PATH
- On Windows, JDK is usually at: `C:\Program Files\Java\jdk-XX\bin`

### "Keystore was tampered with, or password was incorrect"

- Double-check your keystore password
- Make sure `keystore.properties` has correct passwords

### Build fails with signing errors

- Verify `keystore.properties` exists and has correct values
- Check that `release.keystore` file exists in `app/android/app/`
- Ensure passwords don't have special characters that need escaping

## Using Play App Signing (Alternative)

If you prefer Google to manage your signing key:

1. You can use the debug keystore for the first upload
2. Google Play will generate a new signing key
3. Future updates will be signed by Google automatically
4. This is the recommended approach for most developers

## Need Help?

- [Android Signing Documentation](https://developer.android.com/studio/publish/app-signing)
- [Play App Signing Guide](https://support.google.com/googleplay/android-developer/answer/9842756)
