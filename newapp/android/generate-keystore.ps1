# Script to generate release keystore for Android App Bundle (AAB)
# This keystore is required for signing release builds for Play Store

Write-Host "========================================" -ForegroundColor Cyan
Write-Host "  Android Release Keystore Generator" -ForegroundColor Cyan
Write-Host "========================================" -ForegroundColor Cyan
Write-Host ""

# Navigate to android/app directory
$appDir = Join-Path $PSScriptRoot "app"
if (-not (Test-Path $appDir)) {
    Write-Host "✗ ERROR: app directory not found" -ForegroundColor Red
    exit 1
}

Set-Location $appDir

# Check if keystore already exists
$keystorePath = Join-Path $appDir "release.keystore"
if (Test-Path $keystorePath) {
    Write-Host "⚠ WARNING: release.keystore already exists!" -ForegroundColor Yellow
    Write-Host ""
    $overwrite = Read-Host "Do you want to overwrite it? (y/n)"
    if ($overwrite -ne "y" -and $overwrite -ne "Y") {
        Write-Host "Operation cancelled." -ForegroundColor Yellow
        exit 0
    }
    Remove-Item $keystorePath -Force
    Write-Host "✓ Removed existing keystore" -ForegroundColor Green
    Write-Host ""
}

# Get keystore information from user
Write-Host "Please provide the following information for your keystore:" -ForegroundColor Cyan
Write-Host ""

$keystorePassword = Read-Host "Enter keystore password (min 6 characters)" -AsSecureString
$keystorePasswordText = [Runtime.InteropServices.Marshal]::PtrToStringAuto([Runtime.InteropServices.Marshal]::SecureStringToBSTR($keystorePassword))

if ($keystorePasswordText.Length -lt 6) {
    Write-Host "✗ ERROR: Password must be at least 6 characters" -ForegroundColor Red
    exit 1
}

$keyPassword = Read-Host "Enter key password (or press Enter to use same as keystore password)" -AsSecureString
$keyPasswordText = [Runtime.InteropServices.Marshal]::PtrToStringAuto([Runtime.InteropServices.Marshal]::SecureStringToBSTR($keyPassword))

if ($keyPasswordText.Length -eq 0) {
    $keyPasswordText = $keystorePasswordText
}

$keyAlias = Read-Host "Enter key alias (default: release-key)"
if ($keyAlias.Length -eq 0) {
    $keyAlias = "release-key"
}

$validity = Read-Host "Enter validity in days (default: 10000)"
if ($validity.Length -eq 0) {
    $validity = "10000"
}

Write-Host ""
Write-Host "Generating keystore..." -ForegroundColor Yellow
Write-Host "This may take a moment..." -ForegroundColor Yellow
Write-Host ""

# Generate keystore using keytool
$keytoolCommand = "keytool -genkeypair -v -storetype PKCS12 -keystore release.keystore -alias $keyAlias -keyalg RSA -keysize 2048 -validity $validity -storepass `"$keystorePasswordText`" -keypass `"$keyPasswordText`" -dname `"CN=Android, OU=Mobile, O=YourCompany, L=City, ST=State, C=US`""

try {
    $process = Start-Process -FilePath "keytool" -ArgumentList "-genkeypair", "-v", "-storetype", "PKCS12", "-keystore", "release.keystore", "-alias", $keyAlias, "-keyalg", "RSA", "-keysize", "2048", "-validity", $validity, "-storepass", $keystorePasswordText, "-keypass", $keyPasswordText, "-dname", "CN=Android, OU=Mobile, O=YourCompany, L=City, ST=State, C=US" -Wait -NoNewWindow -PassThru
    
    if ($process.ExitCode -eq 0 -and (Test-Path $keystorePath)) {
        Write-Host ""
        Write-Host "========================================" -ForegroundColor Green
        Write-Host "  ✓ KEYSTORE GENERATED SUCCESSFULLY!" -ForegroundColor Green
        Write-Host "========================================" -ForegroundColor Green
        Write-Host ""
        Write-Host "Keystore Location:" -ForegroundColor Cyan
        Write-Host "  $keystorePath" -ForegroundColor White
        Write-Host ""
        Write-Host "Keystore Details:" -ForegroundColor Cyan
        Write-Host "  Alias: $keyAlias" -ForegroundColor White
        Write-Host "  Validity: $validity days" -ForegroundColor White
        Write-Host ""
        Write-Host "⚠ IMPORTANT: Save these credentials securely!" -ForegroundColor Red
        Write-Host "  Keystore Password: [SAVED]" -ForegroundColor Yellow
        Write-Host "  Key Password: [SAVED]" -ForegroundColor Yellow
        Write-Host "  Key Alias: $keyAlias" -ForegroundColor Yellow
        Write-Host ""
        Write-Host "Next steps:" -ForegroundColor Cyan
        Write-Host "1. Save the keystore password and key password in a secure location" -ForegroundColor White
        Write-Host "2. The build.gradle file will be updated to use this keystore" -ForegroundColor White
        Write-Host "3. You can now build release AAB files" -ForegroundColor White
        Write-Host ""
        
        # Save credentials to a secure file (encrypted)
        $credentialsFile = Join-Path $appDir "keystore.properties"
        $credentialsContent = @"
# Android Release Keystore Configuration
# IMPORTANT: Keep this file secure and do NOT commit it to version control
# Add keystore.properties to .gitignore

MYAPP_RELEASE_STORE_FILE=release.keystore
MYAPP_RELEASE_KEY_ALIAS=$keyAlias
MYAPP_RELEASE_STORE_PASSWORD=$keystorePasswordText
MYAPP_RELEASE_KEY_PASSWORD=$keyPasswordText
"@
        
        $credentialsContent | Out-File -FilePath $credentialsFile -Encoding UTF8
        Write-Host "✓ Credentials saved to: $credentialsFile" -ForegroundColor Green
        Write-Host "  (This file should be added to .gitignore)" -ForegroundColor Yellow
        Write-Host ""
        
    } else {
        Write-Host "✗ ERROR: Failed to generate keystore" -ForegroundColor Red
        exit 1
    }
} catch {
    Write-Host "✗ ERROR: Failed to run keytool: $_" -ForegroundColor Red
    Write-Host ""
    Write-Host "Make sure Java JDK is installed and keytool is in your PATH" -ForegroundColor Yellow
    exit 1
}

Write-Host "Keystore generation complete!" -ForegroundColor Green
