rem use VS Dev Cmd window (very import) then cd to D:\Dev\XDog\XDog\XDogApp\XDogApp\XDogApp.Android and run this
msbuild /t:SignAndroidPackage /p:Configuration=Release XDogApp.Android.csproj

rem then copy D:\Dev\XDog\XDog\XDogApp\XDogApp\XDogApp.Android\bin\Release\*.apk D:\Dev\XDog\XDog\XDogApp\XDogUITest\bin\Release