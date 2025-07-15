#!/bin/bash

# Item Management System - Development Starter Script

echo "🚀 Starting Item Management System..."
echo "======================================"

# Check if .NET is installed
if ! command -v dotnet &> /dev/null; then
    echo "❌ .NET is not installed. Please install .NET 7.0 SDK first."
    exit 1
fi

# Check if Node.js is installed
if ! command -v node &> /dev/null; then
    echo "❌ Node.js is not installed. Please install Node.js first."
    exit 1
fi

# Function to start backend
start_backend() {
    echo "🔧 Starting ASP.NET Core Backend..."
    cd Luftborn.Presentation
    dotnet run &
    BACKEND_PID=$!
    echo "✅ Backend started with PID: $BACKEND_PID"
    cd ..
}

# Function to start frontend
start_frontend() {
    echo "⚛️  Starting React Frontend..."
    cd frontend
    
    # Install dependencies if node_modules doesn't exist
    if [ ! -d "node_modules" ]; then
        echo "📦 Installing frontend dependencies..."
        npm install
    fi
    
    npm start &
    FRONTEND_PID=$!
    echo "✅ Frontend started with PID: $FRONTEND_PID"
    cd ..
}

# Start both services
start_backend
sleep 3  # Give backend time to start
start_frontend

echo ""
echo "🎉 Development servers started successfully!"
echo "======================================"
echo "📱 Frontend: http://localhost:3000"
echo "🔌 Backend API: https://localhost:7243"
echo "📚 Swagger UI: https://localhost:7243/swagger"
echo ""
echo "Press Ctrl+C to stop both servers..."

# Function to cleanup on exit
cleanup() {
    echo ""
    echo "🛑 Stopping development servers..."
    kill $BACKEND_PID 2>/dev/null
    kill $FRONTEND_PID 2>/dev/null
    echo "✅ Servers stopped successfully!"
    exit 0
}

# Set up signal handlers
trap cleanup SIGINT SIGTERM

# Wait for both processes
wait