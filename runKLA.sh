#!/bin/bash

# Move to the .NET Core application directory
cd KLA/

echo "Cleaning, Building & Running dotnet application..."
dotnet clean
dotnet build
# Run the dotnet application in the background
dotnet run &

# Wait for a moment to ensure the .NET application has started
sleep 5

# Move to the npm project directory
cd currency-converter-frontend

echo "Installing npm packages..."
# Install npm packages
npm install

echo "Starting npm..."
# Run npm start in the foreground
npm start

echo "Script execution completed."
