
nuget pack ./ORSCF.StudyWorkflowDefinition.Contract.nuspec -Symbols -OutputDirectory ".\(Stage)\Packages" -InstallPackageToOutputPath

IF NOT EXIST "..\..\..\(NuGetRepo)" GOTO NOCOPYTOGLOBALREPO
xcopy ".\(Stage)\Packages\orscf.studyworkflowdefinition.contract.nuspec" "..\..\..\(NuGetRepo)\" /d /r /y /s
xcopy ".\(Stage)\Packages\ORSCF.StudyWorkflowDefinition.Contract*.nupkg*" "..\..\..\(NuGetRepo)\" /d /r /y /s
:NOCOPYTOGLOBALREPO

PAUSE