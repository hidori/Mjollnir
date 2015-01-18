@echo off
set ECHO=

set TARGET=Mjollnir
set TARGET_DIR=%~dp0

set NUGET=%TARGET_DIR%.nuget\NuGet.exe

for %%I in ("%TARGET_DIR%%TARGET%\*.nupkg") do (
	set TARGET_PACKAGE=%%I
)

%ECHO% "%NUGET%" push "%TARGET_PACKAGE%"
