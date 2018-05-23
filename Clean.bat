@REM Removes all irrelevant files and folders.

@echo off & set "quiet=1> nul 2>nul"
set "cmx=call cmx "
set thisDir=%~d0%~p0

%cmx%Dir_Delete "%thisDir%\.vs"
%cmx%Dir_Delete "%thisDir%\packages"

%cmx%Dir_Delete "%thisDir%\Idex\bin"
%cmx%Dir_Delete "%thisDir%\Idex\obj"
%cmx%Dir_Delete "%thisDir%\Idex\.vs"

%cmx%File_DeleteTree "%thisDir%\UpgradeLog*.htm"
REM %cmx%File_DeleteTree "%thisDir%\*.csproj.bak"
%cmx%File_DeleteTree "%thisDir%\*.csproj.user"
REM %cmx%File_DeleteTree "%thisDir%\*.nuget.props"
REM %cmx%File_DeleteTree "%thisDir%\*.nuget.targets"
REM %cmx%File_DeleteTree "%thisDir%\*.lock.json"

REM %cmx%File_DeleteTree "%thisDir%\*.sln"


