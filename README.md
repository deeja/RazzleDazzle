# RazzleDazzle Razl Script Runner
A Razl helper that allows easier use of the Razl scripts

This does essentially the same as the `Razl.exe /scripts:script.xml` call, but it puts everything in one console screen and stops it bouncing between screens. 

## Continuous Integration
The build can be packaged, delivered and run by a Continuous Integration server.

## Building RazzleDazzle
NOTE: The build of this requires an install of Hedgehog Razl on the builder's computer.

- Run the `Build.Ps1` script in the root of the repository

This creates both the a dropable exe files (explained below), as well as a distributable package that can be used with a delivery server, such as Octopus.

## Running RazzleDazzle
Either: 
- drop into the Razl folder and run from there `C:\Program Files (x86)\Hedgehog Development\Razl`
- pack up the `/build` folder with all referenced files, and run from wherever you wish. 
- deploy and use the nuget package that is created with your favourite deployment tool. e.g. Octopus

## Usage
`> RazzleDazzle.exe scriptfile.xml`



