# Setup Instructions for Your Existing Keystore

You've generated a keystore file in the root `app` folder. Here's how to set it up:

## Your Keystore Details:
- **File**: `my-release-key.keystore` (in `app` folder)
- **Password**: `123456`
- **Alias**: `my-key-alias`
- **Location**: `D:\Bss_Prpjects\CreApp\Capp\cs\app\my-release-key.keystore`

## Quick Setup (Choose One):

### Option 1: Run Setup Script (Easiest)

**PowerShell:**
```powershell
cd app/android
.\setup-existing-keystore.ps1
```

**Batch File (Double-click):**
Just double-click `setup-existing-keystore.bat` in the `app/android` folder

### Option 2: Manual Setup

1. **Copy keystore to correct location:**
   ```powershell
   cd app/android
   copy ..\my-release-key.keystore app\release.keystore
   ```

2. **Create keystore.properties file:**
   Create `app/android/app/keystore.properties` with this content:
   ```
   MYAPP_RELEASE_STORE_FILE=release.keystore
   MYAPP_RELEASE_KEY_ALIAS=my-key-alias
   MYAPP_RELEASE_STORE_PASSWORD=123456
   MYAPP_RELEASE_KEY_PASSWORD=123456
   ```

## After Setup: Build AAB

Once setup is complete, build your AAB file:

**PowerShell:**
```powershell
cd app/android
.\build-release-aab.ps1
```

**Batch File:**
Double-click `build-release-aab.bat` in `app/android` folder

**Manual:**
```powershell
cd app/android
.\gradlew.bat bundleRelease
```

## Your AAB File Location:
After successful build:
```
app/android/app/build/outputs/bundle/release/app-release.aab
```

## Important Notes:
- ✅ The keystore will be copied to `app/android/app/release.keystore`
- ✅ The `keystore.properties` file will be created automatically
- ✅ Your password `123456` and alias `my-key-alias` are configured
- ⚠️ **SAVE YOUR PASSWORD** - You'll need it for all future updates!
