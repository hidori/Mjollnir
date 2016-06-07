@echo off
set ECHO=

set TARGET=Mjollnir
set TARGET_DIR=%~dp0
set TARGET_VERSION=5.1.1

set MSBUILD=%ProgramFiles(x86)%\MSBuild\14.0\Bin\MsBuild.exe
set NUGET=%TARGET_DIR%.nuget\NuGet.exe

%ECHO% "%MSBUILD%" "%TARGET_DIR%%TARGET%.sln" /t:Rebuild /p:Configuration=Release
%ECHO% "%NUGET%" pack "%TARGET_DIR%%TARGET%\%TARGET%.nuspec" -Properties version=%TARGET_VERSION% -OutputDir "%TARGET_DIR%%TARGET%"
