@echo off
REM Script to generate release keystore for Android App Bundle (AAB)
REM This keystore is required for signing release builds for Play Store

echo ========================================
echo   Android Release Keystore Generator
echo ========================================
echo.

cd /d "%~dp0app"
if not exist "app" (
    echo ERROR: app directory not found
    pause
    exit /b 1
)

REM Check if keystore already exists
if exist "release.keystore" (
    echo WARNING: release.keystore already exists!
    echo.
    set /p overwrite="Do you want to overwrite it? (y/n): "
    if /i not "%overwrite%"=="y" (
        echo Operation cancelled.
        pause
        exit /b 0
    )
    del "release.keystore"
    echo Removed existing keystore
    echo.
)

echo Please provide the following information for your keystore:
echo.

set /p keystorePassword="Enter keystore password (min 6 characters): "
if "%keystorePassword%"=="" (
    echo ERROR: Password cannot be empty
    pause
    exit /b 1
)

set /p keyPassword="Enter key password (or press Enter to use same as keystore password): "
if "%keyPassword%"=="" (
    set keyPassword=%keystorePassword%
)

set /p keyAlias="Enter key alias (default: release-key): "
if "%keyAlias%"=="" (
    set keyAlias=release-key
)

set /p validity="Enter validity in days (default: 10000): "
if "%validity%"=="" (
    set validity=10000
)

echo.
echo Generating keystore...
echo This may take a moment...
echo.

REM Generate keystore using keytool
keytool -genkeypair -v -storetype PKCS12 -keystore release.keystore -alias %keyAlias% -keyalg RSA -keysize 2048 -validity %validity% -storepass "%keystorePassword%" -keypass "%keyPassword%" -dname "CN=Android, OU=Mobile, O=YourCompany, L=City, ST=State, C=US"

if %ERRORLEVEL% EQU 0 (
    if exist "release.keystore" (
        echo.
        echo ========================================
        echo   KEYSTORE GENERATED SUCCESSFULLY!
        echo ========================================
        echo.
        echo Keystore Location:
        echo   %CD%\release.keystore
        echo.
        echo Keystore Details:
        echo   Alias: %keyAlias%
        echo   Validity: %validity% days
        echo.
        echo IMPORTANT: Save these credentials securely!
        echo   Keystore Password: [SAVED]
        echo   Key Password: [SAVED]
        echo   Key Alias: %keyAlias%
        echo.
        
        REM Save credentials to keystore.properties
        (
            echo # Android Release Keystore Configuration
            echo # IMPORTANT: Keep this file secure and do NOT commit it to version control
            echo # Add keystore.properties to .gitignore
            echo.
            echo MYAPP_RELEASE_STORE_FILE=release.keystore
            echo MYAPP_RELEASE_KEY_ALIAS=%keyAlias%
            echo MYAPP_RELEASE_STORE_PASSWORD=%keystorePassword%
            echo MYAPP_RELEASE_KEY_PASSWORD=%keyPassword%
        ) > keystore.properties
        
        echo Credentials saved to: %CD%\keystore.properties
        echo   (This file should be added to .gitignore)
        echo.
        echo Next steps:
        echo 1. Save the keystore password and key password in a secure location
        echo 2. The build.gradle file will use this keystore automatically
        echo 3. You can now build release AAB files using: build-release-aab.bat
        echo.
        echo Keystore generation complete!
    ) else (
        echo ERROR: Keystore file was not created
        pause
        exit /b 1
    )
) else (
    echo ERROR: Failed to generate keystore
    echo.
    echo Make sure Java JDK is installed and keytool is in your PATH
    echo You can find keytool in: C:\Program Files\Java\jdk-XX\bin
    pause
    exit /b 1
)

pause
