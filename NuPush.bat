@echo off
set ECHO=

set TARGET=%*
set TARGET_DIR=%~dp0

set NUGET=%TARGET_DIR%.nuget\NuGet.exe

for %%I in (%TARGET%) do (
	for %%J in ("%TARGET_DIR%%%I\*.nupkg") do (
		set TARGET_PACKAGE=%%J
	)

	%ECHO% "%NUGET%" push "%TARGET_PACKAGE%"
)
