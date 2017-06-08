@echo off
set ECHO=

set TARGET=Mjollnir
set TARGET_DIR=%~dp0
set TARGET_VERSION=5.2.1

set MSBUILD=%ProgramFiles(x86)%\Microsoft Visual Studio\2017\Community\MSBuild\15.0\Bin\MSBuild.exe
set NUGET=%TARGET_DIR%.nuget\NuGet.exe

%ECHO% "%MSBUILD%" "%TARGET_DIR%%TARGET%.sln" /t:Rebuild /p:Configuration=Release
%ECHO% "%NUGET%" pack "%TARGET_DIR%%TARGET%\%TARGET%.nuspec" -Properties version=%TARGET_VERSION% -OutputDir "%TARGET_DIR:~0,-1%"
