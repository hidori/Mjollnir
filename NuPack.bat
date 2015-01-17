@echo off
set ECHO=

set TARGET=%*
set TARGET_DIR=%~dp0

set MSBUILD=%SystemRoot%\Microsoft.NET\Framework64\v4.0.30319\MSBuild.exe
set NUGET=%TARGET_DIR%.nuget\NuGet.exe

for %%I in (%TARGET%) do (
	%ECHO% "%MSBUILD%" "%TARGET_DIR%%TARGET%.sln" /t:Rebuild /p:Configuration=Release
	%ECHO% "%NUGET%" pack "%TARGET_DIR%%%I\%%I.nuspec" -OutputDir "%TARGET_DIR%%%I"
)
