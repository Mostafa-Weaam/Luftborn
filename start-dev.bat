@echo off
echo 🚀 Starting Item Management System...
echo ======================================

REM Check if .NET is installed
dotnet --version >nul 2>&1
if %errorlevel% neq 0 (
    echo ❌ .NET is not installed. Please install .NET 7.0 SDK first.
    pause
    exit /b 1
)

REM Check if Node.js is installed
node --version >nul 2>&1
if %errorlevel% neq 0 (
    echo ❌ Node.js is not installed. Please install Node.js first.
    pause
    exit /b 1
)

echo 🔧 Starting ASP.NET Core Backend...
cd Luftborn.Presentation
start /min cmd /c "dotnet run"
echo ✅ Backend started
cd ..

timeout /t 3 /nobreak >nul

echo ⚛️  Starting React Frontend...
cd frontend

REM Install dependencies if node_modules doesn't exist
if not exist "node_modules" (
    echo 📦 Installing frontend dependencies...
    npm install
)

start /min cmd /c "npm start"
echo ✅ Frontend started
cd ..

echo.
echo 🎉 Development servers started successfully!
echo ======================================
echo 📱 Frontend: http://localhost:3000
echo 🔌 Backend API: https://localhost:7243
echo 📚 Swagger UI: https://localhost:7243/swagger
echo.
echo Press any key to stop both servers...
pause >nul

echo 🛑 Stopping development servers...
taskkill /f /im dotnet.exe >nul 2>&1
taskkill /f /im node.exe >nul 2>&1
echo ✅ Servers stopped successfully!
pause