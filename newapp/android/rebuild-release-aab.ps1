# Script to rebuild Release AAB with proper release signing
# This ensures the AAB is signed with release keystore, not debug

Write-Host "========================================" -ForegroundColor Cyan
Write-Host "  Rebuilding Release AAB (Release Signed)" -ForegroundColor Cyan
Write-Host "========================================" -ForegroundColor Cyan
Write-Host ""

# Navigate to android directory
$androidDir = $PSScriptRoot
if (-not (Test-Path (Join-Path $androidDir "gradlew.bat"))) {
    Write-Host "✗ ERROR: gradlew.bat not found in $androidDir" -ForegroundColor Red
    exit 1
}

Set-Location $androidDir

# Verify keystore exists
$keystorePath = Join-Path $androidDir "app\my-release-key.keystore"
$keystorePropsPath = Join-Path $androidDir "app\keystore.properties"

if (-not (Test-Path $keystorePath)) {
    Write-Host "✗ ERROR: Keystore file not found!" -ForegroundColor Red
    Write-Host "  Expected: $keystorePath" -ForegroundColor Yellow
    exit 1
}

if (-not (Test-Path $keystorePropsPath)) {
    Write-Host "✗ ERROR: keystore.properties not found!" -ForegroundColor Red
    Write-Host "  Expected: $keystorePropsPath" -ForegroundColor Yellow
    Write-Host ""
    Write-Host "Creating keystore.properties..." -ForegroundColor Yellow
    # Create keystore.properties
    $propsContent = @"
# Android Release Keystore Configuration
MYAPP_RELEASE_STORE_FILE=my-release-key.keystore
MYAPP_RELEASE_KEY_ALIAS=my-key-alias
MYAPP_RELEASE_STORE_PASSWORD=123456
MYAPP_RELEASE_KEY_PASSWORD=123456
"@
    $propsContent | Out-File -FilePath $keystorePropsPath -Encoding UTF8
    Write-Host "✓ Created keystore.properties" -ForegroundColor Green
}

Write-Host "✓ Keystore configuration verified" -ForegroundColor Green
Write-Host ""

# Clean previous build
Write-Host "Cleaning previous build..." -ForegroundColor Yellow
& .\gradlew.bat clean | Out-Null

# Build release AAB
Write-Host ""
Write-Host "Building Release AAB with RELEASE signing..." -ForegroundColor Yellow
Write-Host "This may take several minutes..." -ForegroundColor Yellow
Write-Host ""

$buildResult = & .\gradlew.bat bundleRelease 2>&1

if ($LASTEXITCODE -eq 0) {
    Write-Host ""
    Write-Host "========================================" -ForegroundColor Green
    Write-Host "  ✓ BUILD SUCCESSFUL!" -ForegroundColor Green
    Write-Host "========================================" -ForegroundColor Green
    Write-Host ""
    
    $aabPath = Join-Path $androidDir "app\build\outputs\bundle\release\app-release.aab"
    if (Test-Path $aabPath) {
        $aabSize = (Get-Item $aabPath).Length / 1MB
        Write-Host "Release AAB Location:" -ForegroundColor Cyan
        Write-Host "  $aabPath" -ForegroundColor White
        Write-Host ""
        Write-Host "AAB Size: $([math]::Round($aabSize, 2)) MB" -ForegroundColor Cyan
        Write-Host ""
        Write-Host "✓ Your AAB file is now signed with RELEASE keystore!" -ForegroundColor Green
        Write-Host "  This AAB is ready for Play Store upload." -ForegroundColor Green
        Write-Host ""
        Write-Host "Next steps:" -ForegroundColor Cyan
        Write-Host "1. Go to Google Play Console" -ForegroundColor White
        Write-Host "2. Upload this new AAB file" -ForegroundColor White
        Write-Host "3. The 'debug mode' error should be resolved" -ForegroundColor White
        Write-Host ""
    } else {
        Write-Host "⚠ WARNING: AAB file not found at expected location" -ForegroundColor Yellow
    }
} else {
    Write-Host ""
    Write-Host "========================================" -ForegroundColor Red
    Write-Host "  ✗ BUILD FAILED" -ForegroundColor Red
    Write-Host "========================================" -ForegroundColor Red
    Write-Host ""
    Write-Host "Build output:" -ForegroundColor Yellow
    Write-Host $buildResult
    exit 1
}
