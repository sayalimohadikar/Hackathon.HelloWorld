@echo off
echo This batch file will copy your local json file (if exists) else the examples file, then start the Test Service in dev mode.

pushd bin\Debug\netcoreapp2.1

if exist "..\..\..\appsettings.local.json" (
	echo Copying appsettings.local.json to execution directory.
	copy ..\..\..\appsettings.local.json appsettings.local.json
)

set ASPNETCORE_ENVIRONMENT=Development
dotnet HelloWorld.SimpleWebsite.dll --console

popd