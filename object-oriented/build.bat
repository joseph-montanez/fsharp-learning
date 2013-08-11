
echo Compiling Application
"C:\Program Files (x86)\Microsoft SDKs\F#\3.0\Framework\v4.0\Fsc.exe" -r FSharp.Data.TypeProviders.dll -r System.Data.Linq.dll main.fs

echo Running Application
main.exe
