@echo off

echo Compiling Application
"C:\Program Files (x86)\Microsoft SDKs\F#\3.0\Framework\v4.0\Fsc.exe" main.fs

echo Running Application
main.exe
