@echo off
REM Until new major version of C# is released the build number in the path will keep counting.
REM KAS *requires* .NET compiler version 4.0 or higher. Don't get confused with KSP run-time requirement of 3.5.
REM Map Q: to the KSP installation so MSBuild can resolve the reference assemblies.
subst Q: /d >nul 2>&1
subst Q: "D:\Games'\Steam\steamapps\common\Kerbal Space Program"
"C:\Program Files (x86)\Microsoft Visual Studio\2019\BuildTools\MSBuild\Current\Bin\amd64\MSBuild.exe" ..\Source\KAS.csproj /t:Clean,Build /p:Configuration=Release /p:FrameworkPathOverride="C:\Windows\Microsoft.NET\Framework64\v4.0.30319"
