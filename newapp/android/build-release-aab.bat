@echo off
REM Script to build Release AAB (Android App Bundle) for Play Store
REM Make sure you have generated the keystore first using generate-keystore.bat

echo ========================================
echo   Android Release AAB Builder
echo ========================================
echo.

cd /d "%~dp0"

if not exist "gradlew.bat" (
    echo ERROR: gradlew.bat not found
    pause
    exit /b 1
)

REM Check if keystore exists
if not exist "app\release.keystore" (
    if not exist "app\keystore.properties" (
        echo WARNING: Release keystore not found!
        echo.
        echo Please generate a keystore first by running:
        echo   generate-keystore.bat
        echo.
        echo Or if you're using Play App Signing, you can continue with debug keystore.
        echo.
        set /p continue="Continue anyway? (y/n): "
        if /i not "%continue%"=="y" (
            exit /b 0
        )
    )
)

REM Clean previous build
echo Cleaning previous build...
call gradlew.bat clean >nul 2>&1

REM Build release AAB
echo.
echo Building Release AAB (Android App Bundle)...
echo This may take several minutes...
echo.

call gradlew.bat bundleRelease

if %ERRORLEVEL% EQU 0 (
    echo.
    echo ========================================
    echo   BUILD SUCCESSFUL!
    echo ========================================
    echo.
    
    if exist "app\build\outputs\bundle\release\app-release.aab" (
        echo Release AAB Location:
        echo   %CD%\app\build\outputs\bundle\release\app-release.aab
        echo.
        echo Your AAB file is ready for Play Store upload!
        echo.
        echo Next steps:
        echo 1. Go to Google Play Console
        echo 2. Create a new app or select existing app
        echo 3. Go to Production ^> Create new release
        echo 4. Upload the AAB file
        echo.
    ) else (
        echo WARNING: AAB file not found at expected location
    )
) else (
    echo.
    echo ========================================
    echo   BUILD FAILED
    echo ========================================
    echo.
    echo Check the error messages above for details.
)

pause
