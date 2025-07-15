@echo off
echo 🚀 Starting Item Manager Application...

REM Check if .NET is installed
dotnet --version >nul 2>&1
if %errorlevel% neq 0 (
    echo ❌ .NET SDK not found. Please install .NET 8 SDK.
    pause
    exit /b 1
)

REM Check if Node.js is installed
node --version >nul 2>&1
if %errorlevel% neq 0 (
    echo ❌ Node.js not found. Please install Node.js 16 or higher.
    pause
    exit /b 1
)

REM Check if npm is installed
npm --version >nul 2>&1
if %errorlevel% neq 0 (
    echo ❌ npm not found. Please install npm.
    pause
    exit /b 1
)

echo ✅ Prerequisites check passed

REM Install frontend dependencies if needed
echo 📦 Installing frontend dependencies...
cd frontend
if not exist node_modules (
    npm install
)

REM Start backend API in a new command window
echo 🔧 Starting backend API...
cd ..\Luftborn.Presentation
start "Backend API" cmd /k "dotnet run"

REM Wait a moment for the backend to start
echo ⏳ Waiting for backend to start...
timeout /t 5 /nobreak >nul

REM Start frontend development server in a new command window
echo 🎨 Starting frontend development server...
cd ..\frontend
start "Frontend" cmd /k "npm start"

echo 🎉 Both servers are starting up!
echo 📍 Backend API: https://localhost:5001
echo 📍 Frontend: http://localhost:3000
echo 📖 API Documentation: https://localhost:5001/swagger
echo.
echo Press any key to continue...
pause >nul