@echo off

REM Move to the .NET Core application directory
cd KLA\

echo Cleaning, Building & Running dotnet application...
dotnet clean
dotnet build
REM Run the dotnet application in the background
start "dotnet run" cmd /c dotnet run

REM Wait for a short time to ensure dotnet run has started
timeout /nobreak /t 5 >nul

REM Move back to the original directory
cd ..

REM Move to the npm project directory
cd currency-converter-frontend

echo Starting npm...
REM Run npm start in the foreground
start "npm start" cmd /c npm start

echo Script execution completed.
