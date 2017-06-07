$version = "1.1.2"
$msbuild = "C:\Windows\Microsoft.NET\Framework64\v4.0.30319\MSBuild.exe"
$buildFolder = "$PSScriptRoot\build"

Set-Location $PSScriptRoot

if (!(Test-Path $msbuild)){
    Write-Host "ERROR: MSBUILD not found at path $msbuild"
     throw [System.IO.FileNotFoundException] "$msbuild not found."
}

if (Test-Path $buildFolder){
    Write-Host "Removing $buildFolder"
    Remove-Item $buildFolder -Recurse -Force
}

Write-Host "Building RazzleDazzle"
&$msbuild $PSScriptRoot\RazzleDazzle.sln /p:Configuration=Release /p:OutputPath="$buildFolder"

Write-Host "Nuget Pack"
&.\nuget.exe pack RazzleDazzle.nuspec -version $version
