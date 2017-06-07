# RazzleDazzle Razl Script Runner
A Razl helper that allows easier use of the Razl scripts

This does essentially the same as the `Razl.exe /scripts:script.xml` call, but it puts everything in one console screen and stops it bouncing between screens. 

## Continuous Integration
The build can be packaged, delivered and run by a Continuous Integration server.

## Building RazzleDazzle
The build of this requires an install of Hedgehog Razl on the builder's computer.

## Running RazzleDazzle
Either: 
- drop into the Razl folder and run from there `C:\Program Files (x86)\Hedgehog Development\Razl`
- after the build, pack up the `/bin/Release` folder with all referenced files, and run from wherever you wish. 

## Usage
`> RazzleDazzle.exe scriptfile.xml`



