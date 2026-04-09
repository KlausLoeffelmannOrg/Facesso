@echo off
setlocal EnableDelayedExpansion

:: ================================================================
:: prepare-devenv.cmd
:: Builds FacessoSetup from source and configures the Facesso
:: development environment (database restore, registry, admin user).
::
:: Usage:
::   prepare-devenv.cmd [/container | /local] [/source <path>]
::
:: Options:
::   /container   Configure for container environment (default).
::                Uses SQL auth: Server=localhost,1433;User Id=sa;...
::   /local       Configure for local developer environment.
::                Uses Windows auth: .\SQLEXPRESS
::   /source      Path to FacessoSetup.csproj or its parent directory.
::                Default: src\Tools\FacessoSetup\FacessoSetup.csproj
::                relative to the repo root detected from this script.
:: ================================================================

:: ----------------------------------------------------------
:: Require Administrator
:: ----------------------------------------------------------
net session >nul 2>&1
if %errorlevel% neq 0 (
    echo.
    echo ERROR: This script must be run as Administrator.
    echo Right-click and choose "Run as administrator", or use
    echo an elevated command prompt / terminal.
    echo.
    pause
    exit /b 1
)

:: ----------------------------------------------------------
:: Defaults
:: ----------------------------------------------------------
set "MODE=container"
set "SOURCE="
set "REPO_ROOT="

:: ----------------------------------------------------------
:: Parse arguments
:: ----------------------------------------------------------
:parse_args
if "%~1"=="" goto :args_done
if /i "%~1"=="/container" (
    set "MODE=container"
    shift
    goto :parse_args
)
if /i "%~1"=="/local" (
    set "MODE=local"
    shift
    goto :parse_args
)
if /i "%~1"=="/source" (
    set "SOURCE=%~2"
    shift
    shift
    goto :parse_args
)
if /i "%~1"=="/?" goto :usage
if /i "%~1"=="/help" goto :usage
if /i "%~1"=="--help" goto :usage
echo Unknown option: %~1
goto :usage

:args_done

:: ----------------------------------------------------------
:: Detect repo root
:: ----------------------------------------------------------
:: Walk up from the directory containing this script to find
:: the repo root (identified by a .git folder or the src\ tree).
set "SCRIPT_DIR=%~dp0"
set "SCRIPT_DIR=%SCRIPT_DIR:~0,-1%"

:: If script is in DemoData\, go one level up.
for %%D in ("%SCRIPT_DIR%") do set "PARENT_DIR=%%~dpD"
set "PARENT_DIR=%PARENT_DIR:~0,-1%"

if exist "%PARENT_DIR%\src\Tools\FacessoSetup\FacessoSetup.csproj" (
    set "REPO_ROOT=%PARENT_DIR%"
) else if exist "%SCRIPT_DIR%\src\Tools\FacessoSetup\FacessoSetup.csproj" (
    set "REPO_ROOT=%SCRIPT_DIR%"
) else (
    :: Try current directory
    if exist "src\Tools\FacessoSetup\FacessoSetup.csproj" (
        set "REPO_ROOT=%CD%"
    ) else (
        echo ERROR: Cannot detect repo root. Run from the Facesso repo directory
        echo        or use /source to point to FacessoSetup.csproj.
        exit /b 1
    )
)

echo.
echo ============================================================
echo  Facesso Development Environment Setup
echo ============================================================
echo  Mode     : %MODE%
echo  Repo root: %REPO_ROOT%
echo.

:: ----------------------------------------------------------
:: Resolve FacessoSetup source
:: ----------------------------------------------------------
if "%SOURCE%"=="" (
    set "SOURCE=%REPO_ROOT%\src\Tools\FacessoSetup\FacessoSetup.csproj"
)

:: If SOURCE points to a directory, append the csproj name.
if exist "%SOURCE%\FacessoSetup.csproj" (
    set "SOURCE=%SOURCE%\FacessoSetup.csproj"
)

if not exist "%SOURCE%" (
    echo ERROR: FacessoSetup project not found at:
    echo        %SOURCE%
    exit /b 1
)

:: Derive the solution path from the csproj location.
for %%F in ("%SOURCE%") do set "SETUP_DIR=%%~dpF"
set "SETUP_DIR=%SETUP_DIR:~0,-1%"
set "SLN_PATH=%SETUP_DIR%\FacessoSetup.sln"

if not exist "%SLN_PATH%" (
    echo WARNING: FacessoSetup.sln not found. Building csproj directly.
    set "BUILD_TARGET=%SOURCE%"
) else (
    set "BUILD_TARGET=%SLN_PATH%"
)

:: ----------------------------------------------------------
:: Build FacessoSetup
:: ----------------------------------------------------------
echo.
echo --- Building FacessoSetup ---
echo.

msbuild "%BUILD_TARGET%" /restore /p:Configuration=Release /v:minimal
if %errorlevel% neq 0 (
    echo.
    echo ERROR: Build failed.
    exit /b 1
)

:: Find the built executable.
set "SETUP_EXE="
for /r "%SETUP_DIR%\bin\Release" %%F in (FacessoSetup.exe) do (
    if exist "%%F" set "SETUP_EXE=%%F"
)

if "%SETUP_EXE%"=="" (
    echo ERROR: FacessoSetup.exe not found in build output.
    exit /b 1
)

echo.
echo Built: %SETUP_EXE%

:: ----------------------------------------------------------
:: Locate demo database
:: ----------------------------------------------------------
set "DEMO_ZIP=%REPO_ROOT%\DemoData\Facesso-demo-backup.zip"
set "BACKUP_DIR=C:\backups"

if not exist "%DEMO_ZIP%" (
    echo.
    echo WARNING: Demo database not found at %DEMO_ZIP%
    echo          Skipping database restore. You can restore manually with:
    echo          %SETUP_EXE% --RestoreCompressedDb "path\to\backup.zip" "%BACKUP_DIR%"
    goto :skip_restore
)

:: ----------------------------------------------------------
:: Restore demo database
:: ----------------------------------------------------------
echo.
echo --- Restoring Demo Database ---
echo.

if /i "%MODE%"=="container" (
    "%SETUP_EXE%" --RestoreCompressedDb "%DEMO_ZIP%" "%BACKUP_DIR%"
) else (
    "%SETUP_EXE%" --RestoreCompressedDb "%DEMO_ZIP%" "%BACKUP_DIR%" --instance .\SQLEXPRESS
)

if %errorlevel% neq 0 (
    echo.
    echo ERROR: Database restore failed.
    exit /b 1
)

:skip_restore

:: ----------------------------------------------------------
:: Registry setup + default admin
:: ----------------------------------------------------------
echo.
echo --- Configuring Registry and Default Admin ---
echo.

if /i "%MODE%"=="container" (
    "%SETUP_EXE%" --setup --add-default-admin
) else (
    "%SETUP_EXE%" --setup --add-default-admin --instance .\SQLEXPRESS
)

if %errorlevel% neq 0 (
    echo.
    echo ERROR: Setup / admin configuration failed.
    exit /b 1
)

:: ----------------------------------------------------------
:: Done
:: ----------------------------------------------------------
echo.
echo ============================================================
echo  Facesso development environment is ready.
echo ============================================================
echo.
if /i "%MODE%"=="container" (
    echo  SQL connection: Server=localhost,1433;User Id=sa;Password=Sandbox#2025!;TrustServerCertificate=true;
) else (
    echo  SQL connection: Data Source=.\SQLEXPRESS;Initial Catalog=Facesso;Integrated Security=True
)
echo  Facesso admin : Admin / P@$$w0rd
echo.
echo  To reset the database later, run:
echo    %SETUP_EXE% --Backup "C:\output\Facesso-{yyyy-MM-dd-HHmmss}.bak"
echo    %SETUP_EXE% --RestoreCompressedDb "%DEMO_ZIP%" "%BACKUP_DIR%"
echo.

exit /b 0

:: ----------------------------------------------------------
:: Usage
:: ----------------------------------------------------------
:usage
echo.
echo Usage: prepare-devenv.cmd [/container ^| /local] [/source ^<path^>]
echo.
echo Options:
echo   /container   Use SQL auth on localhost:1433 (default, for containers)
echo   /local       Use Windows auth on .\SQLEXPRESS (for local dev machines)
echo   /source      Path to FacessoSetup.csproj or its directory
echo.
echo This script must be run as Administrator.
echo.
exit /b 1
