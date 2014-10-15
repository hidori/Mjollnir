@echo off
if not "%VS120COMNTOOLS%" == "" goto SKIP_VSVARS
	call "%ProgramFiles(x86)%\Microsoft Visual Studio 12.0\Common7\Tools\VsVars32.bat"
:SKIP_VSVARS

set TARGET=Mjollnir
set TARGET_DIR=%~dp0

msbuild "%TARGET_DIR%%TARGET%.sln" /t:Rebuild /p:Configuration=Release
nuget pack "%TARGET_DIR%%TARGET%.nuspec" -OutputDir "%TARGET_DIR:~0,-1%"