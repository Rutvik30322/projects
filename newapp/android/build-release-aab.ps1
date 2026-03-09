# Script to build Release AAB (Android App Bundle) for Play Store
# Make sure you have generated the keystore first using generate-keystore.ps1

Write-Host "========================================" -ForegroundColor Cyan
Write-Host "  Android Release AAB Builder" -ForegroundColor Cyan
Write-Host "========================================" -ForegroundColor Cyan
Write-Host ""

# Navigate to android directory
$androidDir = $PSScriptRoot
if (-not (Test-Path (Join-Path $androidDir "gradlew.bat"))) {
    Write-Host "✗ ERROR: gradlew.bat not found in $androidDir" -ForegroundColor Red
    exit 1
}

Set-Location $androidDir

# Check if keystore exists
$keystorePath = Join-Path $androidDir "app\release.keystore"
$keystorePropsPath = Join-Path $androidDir "app\keystore.properties"

if (-not (Test-Path $keystorePath) -and -not (Test-Path $keystorePropsPath)) {
    Write-Host "⚠ WARNING: Release keystore not found!" -ForegroundColor Yellow
    Write-Host ""
    Write-Host "Please generate a keystore first by running:" -ForegroundColor Yellow
    Write-Host "  .\generate-keystore.ps1" -ForegroundColor White
    Write-Host ""
    Write-Host "Or if you're using Play App Signing, you can continue with debug keystore." -ForegroundColor Yellow
    Write-Host ""
    $continue = Read-Host "Continue anyway? (y/n)"
    if ($continue -ne "y" -and $continue -ne "Y") {
        exit 0
    }
}

# Clean previous build
Write-Host "Cleaning previous build..." -ForegroundColor Yellow
& .\gradlew.bat clean | Out-Null

# Build release AAB
Write-Host ""
Write-Host "Building Release AAB (Android App Bundle)..." -ForegroundColor Yellow
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
        Write-Host "✓ Your AAB file is ready for Play Store upload!" -ForegroundColor Green
        Write-Host ""
        Write-Host "Next steps:" -ForegroundColor Cyan
        Write-Host "1. Go to Google Play Console" -ForegroundColor White
        Write-Host "2. Create a new app or select existing app" -ForegroundColor White
        Write-Host "3. Go to Production > Create new release" -ForegroundColor White
        Write-Host "4. Upload the AAB file" -ForegroundColor White
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
