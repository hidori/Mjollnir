@echo off
set ECHO=

set TARGET=Mjollnir
set TARGET_DIR=%~dp0
set TARGET_VERSION=5.0.9

set MSBUILD=%SystemRoot%\Microsoft.NET\Framework64\v4.0.30319\MSBuild.exe
set NUGET=%TARGET_DIR%.nuget\NuGet.exe

%ECHO% "%MSBUILD%" "%TARGET_DIR%%TARGET%.sln" /t:Rebuild /p:Configuration=Release
%ECHO% "%NUGET%" pack "%TARGET_DIR%%TARGET%\%TARGET%.nuspec" -Properties version=%TARGET_VERSION% -OutputDir "%TARGET_DIR%%TARGET%"
