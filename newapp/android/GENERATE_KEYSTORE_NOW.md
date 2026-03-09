# Generate Keystore - Complete Command

## If you're in PowerShell and want to complete the command:

Press `Ctrl+C` to cancel the current command, then use one of these options:

### Option 1: Use the Script (Recommended)
```powershell
cd android
.\generate-keystore.ps1
```

### Option 2: Complete Manual Command
Navigate to the correct directory first:
```powershell
cd android\app
```

Then run this complete command:
```powershell
keytool -genkeypair -v -storetype PKCS12 -keystore release.keystore -alias release-key -keyalg RSA -keysize 2048 -validity 10000 -storepass "YOUR_PASSWORD" -keypass "YOUR_PASSWORD" -dname "CN=Android, OU=Mobile, O=YourCompany, L=City, ST=State, C=US"
```

Replace `YOUR_PASSWORD` with your actual password (minimum 6 characters).

### Option 3: Interactive Mode (Easier)
If you want keytool to prompt you for information:
```powershell
cd android\app
keytool -genkeypair -v -storetype PKCS12 -keystore release.keystore -alias release-key -keyalg RSA -keysize 2048 -validity 10000
```

This will prompt you for:
- Keystore password
- Key password  
- Your name, organization, etc.

## After Generating Keystore

1. The keystore will be created at: `app/android/app/release.keystore`
2. You need to create `keystore.properties` file manually or run the script which does it automatically
3. Then you can build your AAB file
