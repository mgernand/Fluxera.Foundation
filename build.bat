@echo off
setlocal

:: Configuration
set PACKAGE_DIR=../../Packages

dotnet build ./Foundation.slnx -c Release -p:PackageOutputPath=../../Packages

echo.
echo All packages have been built.
pause