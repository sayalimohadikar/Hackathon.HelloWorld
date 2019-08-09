@echo off
REM This is just a bootstrap file for loading the main Atlas.Build scripts
REM You shouldn't need to change this file. 
REM See https://github.com/kinnser/Atlas.Build for more details

:: Download NuGet
set builddir=%~dp0\build
if not exist "%builddir%\tools" mkdir "%builddir%\tools"
if not exist "%builddir%\tools\nuget" mkdir "%builddir%\tools\nuget"
if not exist "%builddir%\tools\nuget\nuget.exe" powershell -NonInteractive -NoProfile -ExecutionPolicy Unrestricted -Command "(New-Object Net.WebClient).DownloadFile('https://dist.nuget.org/win-x86-commandline/latest/nuget.exe', '%builddir%\tools\nuget\nuget.exe')"

:: Download Atlas.Build package
set myget=https://www.myget.org/F/ksi-core/auth/df32a8ba-0288-466a-9401-0cf5ea7f2e6e/api/v3/index.json
set package=Atlas.Build
if not exist "%builddir%\tools\%package%" %builddir%\tools\nuget\nuget.exe install %package% -Source %myget% -NonInteractive -OutputDirectory %builddir%\tools -ExcludeVersion

:: Run Atlas.Build
powershell -NonInteractive -NoProfile -ExecutionPolicy Unrestricted -Command "& { %builddir%\tools\%package%\Content\build.ps1 -Script %builddir%\build.cake %* }"

