
nuget pack ./ORSCF.IdentityManagement.Contract.nuspec -Symbols -OutputDirectory ".\(Stage)\Packages" -InstallPackageToOutputPath

IF NOT EXIST "..\..\..\(NuGetRepo)" GOTO NOCOPYTOGLOBALREPO
xcopy ".\(Stage)\Packages\orscf.identitymanagement.contract.nuspec" "..\..\..\(NuGetRepo)\" /d /r /y /s
xcopy ".\(Stage)\Packages\ORSCF.IdentityManagement.Contract*.nupkg*" "..\..\..\(NuGetRepo)\" /d /r /y /s
:NOCOPYTOGLOBALREPO

PAUSE