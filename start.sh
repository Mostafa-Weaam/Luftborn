#!/bin/bash

# Item Manager Application Startup Script
# This script starts both the backend API and frontend React app

echo "🚀 Starting Item Manager Application..."

# Function to check if a command exists
command_exists() {
    command -v "$1" >/dev/null 2>&1
}

# Check prerequisites
echo "📋 Checking prerequisites..."

if ! command_exists dotnet; then
    echo "❌ .NET SDK not found. Please install .NET 8 SDK."
    exit 1
fi

if ! command_exists node; then
    echo "❌ Node.js not found. Please install Node.js 16 or higher."
    exit 1
fi

if ! command_exists npm; then
    echo "❌ npm not found. Please install npm."
    exit 1
fi

echo "✅ Prerequisites check passed"

# Install frontend dependencies if needed
echo "📦 Installing frontend dependencies..."
cd frontend
if [ ! -d "node_modules" ]; then
    npm install
fi

# Start backend API in the background
echo "🔧 Starting backend API..."
cd ../Luftborn.Presentation
dotnet run &
BACKEND_PID=$!

# Wait a moment for the backend to start
echo "⏳ Waiting for backend to start..."
sleep 5

# Start frontend development server
echo "🎨 Starting frontend development server..."
cd ../frontend
npm start &
FRONTEND_PID=$!

echo "🎉 Both servers are starting up!"
echo "📍 Backend API: https://localhost:5001"
echo "📍 Frontend: http://localhost:3000"
echo "📖 API Documentation: https://localhost:5001/swagger"
echo ""
echo "Press Ctrl+C to stop both servers"

# Function to handle shutdown
cleanup() {
    echo "🛑 Shutting down servers..."
    kill $BACKEND_PID 2>/dev/null
    kill $FRONTEND_PID 2>/dev/null
    echo "👋 Servers stopped"
    exit 0
}

# Set trap to call cleanup function on script exit
trap cleanup SIGINT SIGTERM

# Wait for both processes
wait $BACKEND_PID $FRONTEND_PID