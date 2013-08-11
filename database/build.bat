@echo Off
echo Building DBML
"C:\Program Files (x86)\Microsoft SDKs\Windows\v7.0A\bin\SqlMetal.exe" /server:.\SQLEXPRESS /database:FSharpDB /context:DBContext  /dbml:database.dbml

echo Compiling Application
"C:\Program Files (x86)\Microsoft SDKs\F#\3.0\Framework\v4.0\Fsc.exe" -r FSharp.Data.TypeProviders.dll -r System.Data.Linq.dll db.fs

echo Running Application
db.exe
