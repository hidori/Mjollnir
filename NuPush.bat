@echo off
if not "%VS120COMNTOOLS%" == "" goto SKIP_VSVARS
	call "%ProgramFiles(x86)%\Microsoft Visual Studio 12.0\Common7\Tools\VsVars32.bat"
:SKIP_VSVARS

set TARGET=Mjollnir
set TARGET_DIR=%~dp0

for %%I in ("%TARGET_DIR%*.nupkg") do (
	set TARGET_PACKAGE=%%I
)

nuget push "%TARGET_PACKAGE%"
