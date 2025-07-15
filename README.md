# Item Manager Application

A full-stack application for managing items with CRUD operations, built with .NET 8 Web API backend and React TypeScript frontend.

## Features

- **Backend**: .NET 8 Web API with Clean Architecture
- **Frontend**: React 18 with TypeScript
- **Database**: MySQL with Entity Framework Core
- **CRUD Operations**: Create, Read, Update, Delete items
- **Modern UI**: Responsive design with modern CSS
- **Error Handling**: Comprehensive error handling and loading states
- **API Documentation**: Swagger/OpenAPI documentation

## Project Structure

```
├── Luftborn.Application/    # Application layer (DTOs, Services, Interfaces)
├── Luftborn.Domain/         # Domain layer (Entities, Repositories)
├── Luftborn.Infrastructure/ # Infrastructure layer (Database, Repositories)
├── Luftborn.Presentation/   # Presentation layer (Controllers, API)
├── Luftborn.SharedKernel/   # Shared utilities and common code
├── frontend/                # React TypeScript frontend
├── MySQL_Setup_Guide.md     # Database setup guide
└── README.md               # This file
```

## Prerequisites

### Backend
- .NET 8 SDK
- MySQL Server
- Visual Studio or VS Code (optional)

### Frontend
- Node.js 16 or higher
- npm or yarn package manager

## Getting Started

### Quick Start (Recommended)
1. **Database Setup**: Follow the instructions in `MySQL_Setup_Guide.md` to set up MySQL.

2. **Run Both Applications**: Use the provided startup scripts:
   - **Linux/Mac**: `./start.sh`
   - **Windows**: `start.bat`

The scripts will:
- Check prerequisites
- Install frontend dependencies
- Start both backend and frontend servers
- Open in new terminal windows/tabs

### Manual Setup

If you prefer to run the applications manually:

#### Backend Setup
1. Navigate to the presentation project:
   ```bash
   cd Luftborn.Presentation
   ```

2. Update the connection string in `appsettings.json` if needed

3. Run the API:
   ```bash
   dotnet run
   ```

The API will be available at `https://localhost:5001` (or `http://localhost:5000`)

#### Frontend Setup
1. Navigate to the frontend directory:
   ```bash
   cd frontend
   ```

2. Install dependencies:
   ```bash
   npm install
   ```

3. Start the development server:
   ```bash
   npm start
   ```

The frontend will be available at `http://localhost:3000`

## API Endpoints

The following endpoints are available:

### Items
- `GET /api/item` - Get all items
- `GET /api/item/{id}` - Get item by ID
- `POST /api/item` - Create new item
- `PUT /api/item/{id}` - Update existing item
- `DELETE /api/item/{id}` - Delete item

### API Documentation
Visit `https://localhost:5001/swagger` when the API is running to view the interactive API documentation.

## Item Model

```typescript
interface Item {
  id: string;          // GUID
  title: string;       // Required
  description: string; // Optional
}
```

## Development

### Backend Development
- Clean Architecture with separate layers
- Entity Framework Core for database operations
- Dependency injection
- API versioning support
- Comprehensive error handling

### Frontend Development
- React 18 with TypeScript
- React Router for navigation
- Axios for HTTP requests
- Modern CSS with responsive design
- Component-based architecture

## CORS Configuration

The backend is configured to accept requests from `http://localhost:3000` (React development server). If you change the frontend port, update the CORS configuration in `Luftborn.Presentation/Program.cs`.

## Production Deployment

### Backend
1. Build the application:
   ```bash
   dotnet build --configuration Release
   ```

2. Publish the application:
   ```bash
   dotnet publish --configuration Release
   ```

### Frontend
1. Build the React application:
   ```bash
   cd frontend
   npm run build
   ```

2. Deploy the `build` folder to your web server

## Troubleshooting

### Common Issues

1. **Database Connection Issues**
   - Verify MySQL is running
   - Check connection string in `appsettings.json`
   - Ensure database exists and migrations are applied

2. **CORS Issues**
   - Verify frontend is running on `http://localhost:3000`
   - Check CORS configuration in `Program.cs`

3. **API Not Found**
   - Ensure backend is running on `https://localhost:5001`
   - Check API base URL in `frontend/src/services/api.ts`

## Contributing

1. Fork the repository
2. Create a feature branch
3. Make your changes
4. Test thoroughly
5. Submit a pull request

## License

This project is licensed under the MIT License.