# Item Management System

A full-stack web application with a React.js frontend and ASP.NET Core backend implementing CRUD operations for managing items.

## Features

- **Create**: Add new items with title and description
- **Read**: View all items in a responsive card layout
- **Update**: Edit existing items
- **Delete**: Remove items with confirmation
- **Modern UI**: Clean, responsive design with animations
- **TypeScript**: Full type safety in the frontend
- **Clean Architecture**: Well-structured backend with proper separation of concerns

## Tech Stack

### Backend
- ASP.NET Core 7.0
- Entity Framework Core (with MySQL)
- Clean Architecture pattern
- Swagger/OpenAPI documentation
- CORS enabled for React frontend

### Frontend
- React.js 18 with TypeScript
- Modern CSS with animations
- Responsive design
- RESTful API integration
- Error handling and loading states

## Prerequisites

- [.NET 7.0 SDK](https://dotnet.microsoft.com/download/dotnet/7.0)
- [Node.js](https://nodejs.org/) (v14 or higher)
- [MySQL](https://www.mysql.com/) (or update connection string for other databases)

## Getting Started

### 1. Backend Setup

1. **Configure Database Connection**
   - Update the connection string in `Luftborn.Presentation/appsettings.json`
   - Ensure MySQL is running

2. **Run Database Migrations**
   ```bash
   cd Luftborn.Presentation
   dotnet ef database update
   ```

3. **Start the Backend**
   ```bash
   cd Luftborn.Presentation
   dotnet run
   ```

   The API will be available at:
   - HTTPS: `https://localhost:7243`
   - HTTP: `http://localhost:5123`
   - Swagger UI: `https://localhost:7243/swagger`

### 2. Frontend Setup

1. **Install Dependencies**
   ```bash
   cd frontend
   npm install
   ```

2. **Start the Development Server**
   ```bash
   npm start
   ```

   The React app will be available at:
   - `http://localhost:3000`

## API Endpoints

### Items
- `GET /api/item` - Get all items
- `GET /api/item/{id}` - Get item by ID
- `POST /api/item` - Create new item
- `PUT /api/item/{id}` - Update existing item
- `DELETE /api/item/{id}` - Delete item

### Request/Response Examples

**Create Item (POST /api/item)**
```json
{
  "title": "Sample Item",
  "description": "This is a sample item description"
}
```

**Response**
```json
{
  "data": {
    "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    "title": "Sample Item",
    "description": "This is a sample item description"
  },
  "success": true,
  "message": null
}
```

## Project Structure

```
├── Luftborn.Application/     # Application layer (services, DTOs)
├── Luftborn.Domain/          # Domain layer (entities, interfaces)
├── Luftborn.Infrastructure/  # Infrastructure layer (data access)
├── Luftborn.Presentation/    # Presentation layer (API controllers)
├── Luftborn.SharedKernel/    # Shared kernel (common utilities)
├── frontend/                 # React frontend
│   ├── src/
│   │   ├── components/      # React components
│   │   ├── services/        # API service functions
│   │   ├── types/          # TypeScript interfaces
│   │   └── App.tsx         # Main app component
│   └── public/             # Static files
└── README.md
```

## Development Commands

### Backend
```bash
# Run the API
dotnet run

# Run with hot reload
dotnet watch run

# Run tests
dotnet test

# Create migration
dotnet ef migrations add MigrationName

# Update database
dotnet ef database update
```

### Frontend
```bash
# Start development server
npm start

# Build for production
npm run build

# Run tests
npm test

# Type check
npm run build
```

## Configuration

### Backend Configuration
- **Database**: Update connection string in `appsettings.json`
- **CORS**: Configured to allow requests from `http://localhost:3000`
- **Swagger**: Enabled in development environment

### Frontend Configuration
- **API Base URL**: Update in `src/services/itemService.ts`
- **Port**: Default React development server port is 3000

## Troubleshooting

### Common Issues

1. **CORS Errors**
   - Ensure the backend CORS policy includes your frontend URL
   - Check that the frontend is running on `http://localhost:3000`

2. **Database Connection**
   - Verify MySQL is running
   - Check connection string in `appsettings.json`
   - Ensure database exists and migrations are applied

3. **API URL Mismatch**
   - Verify the API URL in `frontend/src/services/itemService.ts`
   - Check the backend is running on the expected port

4. **SSL Certificate Issues**
   - For development, you might need to accept the self-signed certificate
   - Or use HTTP instead of HTTPS in the frontend API calls

## Building for Production

### Backend
```bash
dotnet publish -c Release
```

### Frontend
```bash
npm run build
```

## Contributing

1. Fork the repository
2. Create a feature branch
3. Make your changes
4. Test thoroughly
5. Submit a pull request

## License

This project is licensed under the MIT License.