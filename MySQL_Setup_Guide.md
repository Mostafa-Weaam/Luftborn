# MySQL Integration Setup Guide

This document provides a complete guide for setting up and using MySQL with the Luftborn solution.

## Overview

The Luftborn solution now includes full MySQL support using:
- **Entity Framework Core 8.0.13**
- **Pomelo.EntityFrameworkCore.MySql 8.0.3** (Official MySQL provider for EF Core)
- **Clean Architecture** pattern with proper dependency injection

## Prerequisites

1. **.NET 8 SDK** - Already configured
2. **MySQL Server** - Install one of the following:
   - MySQL 8.0+ (recommended)
   - MariaDB 10.4+ (also supported)

## MySQL Server Installation

### Option 1: Docker (Recommended for Development)
```bash
# Start MySQL container
docker run --name luftborn-mysql \
  -e MYSQL_ROOT_PASSWORD=password \
  -e MYSQL_DATABASE=LuftbornDb \
  -p 3306:3306 \
  -d mysql:8.0

# For development with sample data
docker run --name luftborn-mysql-dev \
  -e MYSQL_ROOT_PASSWORD=password \
  -e MYSQL_DATABASE=LuftbornDb_Dev \
  -p 3307:3306 \
  -d mysql:8.0
```

### Option 2: Local Installation
- **Windows**: Download from [MySQL Downloads](https://dev.mysql.com/downloads/mysql/)
- **Ubuntu/Debian**: `sudo apt update && sudo apt install mysql-server`
- **CentOS/RHEL**: `sudo yum install mysql-server`
- **macOS**: `brew install mysql`

## Configuration

### Connection Strings
The solution is pre-configured with connection strings in:

**appsettings.json** (Production):
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=LuftbornDb;User=root;Password=password;Port=3306;"
  }
}
```

**appsettings.Development.json** (Development):
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=LuftbornDb_Dev;User=root;Password=password;Port=3306;"
  }
}
```

### Customize Connection String
Update the connection string parameters as needed:
- **Server**: Your MySQL server hostname
- **Database**: Your database name
- **User**: Your MySQL username
- **Password**: Your MySQL password
- **Port**: Your MySQL port (default: 3306)

## Database Setup

### 1. Create Database Migration
```bash
# Add Entity Framework tools (if not already installed)
dotnet tool install --global dotnet-ef

# Create initial migration
dotnet ef migrations add InitialCreate --project Luftborn.Infrastructure --startup-project Luftborn.Presentation

# Apply migration to database
dotnet ef database update --project Luftborn.Infrastructure --startup-project Luftborn.Presentation
```

### 2. Verify Database Schema
After running migrations, your MySQL database will contain:
- `Items` table with columns: `Id`, `Title`, `Description`
- `__EFMigrationsHistory` table for tracking migrations

## Architecture Overview

### Project Structure
```
Luftborn.Infrastructure/
├── Dbcontext/
│   └── LuftbornDbContext.cs          # Main DbContext
├── DependencyInjection.cs            # Service registration
└── Luftborn.Infrastructure.csproj    # MySQL packages

Luftborn.Presentation/
├── Program.cs                        # MySQL configuration
└── appsettings.json                  # Connection strings
```

### Database Context Configuration
The `LuftbornDbContext` is configured in `DependencyInjection.cs`:

```csharp
services.AddDbContext<LuftbornDbContext>(options =>
    options.UseMySql(connectionString, 
        ServerVersion.AutoDetect(connectionString),
        b => b.MigrationsAssembly("Luftborn.Infrastructure")));
```

## Usage Examples

### 1. Basic CRUD Operations
```csharp
// In your service or controller
public class ItemService
{
    private readonly LuftbornDbContext _context;

    public ItemService(LuftbornDbContext context)
    {
        _context = context;
    }

    public async Task<List<Item>> GetAllItemsAsync()
    {
        return await _context.Items.ToListAsync();
    }

    public async Task<Item> CreateItemAsync(Item item)
    {
        _context.Items.Add(item);
        await _context.SaveChangesAsync();
        return item;
    }
}
```

### 2. Testing the API
```bash
# Start the application
dotnet run --project Luftborn.Presentation

# The API will be available at:
# - HTTPS: https://localhost:7000
# - HTTP: http://localhost:5000
# - Swagger UI: https://localhost:7000/swagger
```

## Troubleshooting

### Common Issues

1. **Connection Error**: "Unable to connect to any of the specified MySQL hosts"
   - **Solution**: Ensure MySQL server is running and connection string is correct

2. **Authentication Error**: "Access denied for user"
   - **Solution**: Verify username/password in connection string
   - **Check**: User has permissions on the specified database

3. **Database Doesn't Exist**: "Unknown database"
   - **Solution**: Create database manually or ensure it exists before running migrations

4. **Port Conflicts**: "Address already in use"
   - **Solution**: Change the port in connection string or stop conflicting services

### MySQL Commands for Troubleshooting
```sql
-- Connect to MySQL
mysql -u root -p

-- Show databases
SHOW DATABASES;

-- Create database manually if needed
CREATE DATABASE LuftbornDb;
CREATE DATABASE LuftbornDb_Dev;

-- Show users and permissions
SELECT user, host FROM mysql.user;
SHOW GRANTS FOR 'root'@'localhost';

-- Grant permissions (if needed)
GRANT ALL PRIVILEGES ON LuftbornDb.* TO 'root'@'localhost';
GRANT ALL PRIVILEGES ON LuftbornDb_Dev.* TO 'root'@'localhost';
FLUSH PRIVILEGES;
```

## Production Considerations

1. **Security**:
   - Use strong passwords
   - Create dedicated database users (not root)
   - Enable SSL connections
   - Restrict database access by IP

2. **Performance**:
   - Configure connection pooling
   - Set appropriate indexes
   - Monitor query performance
   - Use read replicas for scaling

3. **Connection String for Production**:
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=your-prod-server;Database=LuftbornDb;User=luftborn_user;Password=your-secure-password;SslMode=Required;"
     }
   }
   ```

## Additional Features

### Available MySQL-Specific Features
- **JSON Column Support**: Store and query JSON data
- **Spatial Data Support**: Geographic data types and functions
- **Full-Text Search**: Advanced text search capabilities
- **Stored Procedures**: Call MySQL stored procedures from EF Core
- **Bulk Operations**: High-performance bulk insert/update/delete

### Example: Using JSON Columns
```csharp
public class Item
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    
    // JSON column example
    [Column(TypeName = "json")]
    public string Metadata { get; set; }
}
```

## Resources

- [Pomelo.EntityFrameworkCore.MySql Documentation](https://github.com/PomeloFoundation/Pomelo.EntityFrameworkCore.MySql)
- [Entity Framework Core Documentation](https://docs.microsoft.com/en-us/ef/core/)
- [MySQL Documentation](https://dev.mysql.com/doc/)
- [Connection String Reference](https://mysqlconnector.net/connection-options/)

## Support

For issues related to:
- **MySQL Provider**: [Pomelo GitHub Issues](https://github.com/PomeloFoundation/Pomelo.EntityFrameworkCore.MySql/issues)
- **Entity Framework Core**: [EF Core GitHub Issues](https://github.com/dotnet/efcore/issues)
- **MySQL Server**: [MySQL Support](https://www.mysql.com/support/)