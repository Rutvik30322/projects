# Quick Start: Generate Keystore & Build AAB

## Step 1: Generate Keystore (Choose One Method)

### Method A: Using Batch File (Easiest - Double Click)
1. Navigate to `app/android` folder
2. Double-click `generate-keystore.bat`
3. Follow the prompts:
   - Enter keystore password (min 6 characters)
   - Enter key password (or press Enter for same)
   - Enter key alias (or press Enter for default: release-key)
   - Enter validity days (or press Enter for default: 10000)

### Method B: Using PowerShell
1. Open PowerShell in `app/android` folder
2. Run: `.\generate-keystore.ps1`
3. Follow the prompts

### Method C: Manual Command
```bash
cd app/android/app
keytool -genkeypair -v -storetype PKCS12 -keystore release.keystore -alias release-key -keyalg RSA -keysize 2048 -validity 10000
```

## Step 2: Build Release AAB

### Method A: Using Batch File (Easiest - Double Click)
1. Navigate to `app/android` folder
2. Double-click `build-release-aab.bat`
3. Wait for build to complete

### Method B: Using PowerShell
1. Open PowerShell in `app/android` folder
2. Run: `.\build-release-aab.ps1`

### Method C: Manual Command
```bash
cd app/android
./gradlew bundleRelease
```

## Step 3: Find Your AAB File

After successful build, your AAB file will be at:
```
app/android/app/build/outputs/bundle/release/app-release.aab
```

## Important Notes

⚠️ **CRITICAL**: 
- **Save your keystore password and key password** - You'll need them for all future updates
- **Backup the `release.keystore` file** - Store it in a secure location
- **If you lose the keystore**, you cannot update your app on Play Store

✅ **Security**:
- Keystore files are automatically ignored by Git
- Never share your keystore or passwords
- Store credentials in a password manager

## Troubleshooting

### "keytool: command not found"
- Install Java JDK
- Add JDK bin to PATH: `C:\Program Files\Java\jdk-XX\bin`

### Build fails
- Make sure `keystore.properties` exists in `app/android/app/`
- Verify passwords are correct
- Check that `release.keystore` exists in `app/android/app/`

## Next Steps

1. Upload AAB to [Google Play Console](https://play.google.com/console)
2. Go to your app → Production → Create new release
3. Upload the AAB file
4. Fill release notes and submit
