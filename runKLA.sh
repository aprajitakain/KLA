#!/bin/bash

# Move to the .NET Core application directory
cd KLA/

echo "Cleaning, Building & Running dotnet application..."
dotnet clean
dotnet build
# Run the dotnet application in the background
dotnet run &



# Move to the npm project directory
cd currency-converter-frontend

echo "Starting npm..."
# Run npm start in the foreground
npm start

echo "Script execution completed."
