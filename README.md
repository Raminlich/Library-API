# Library-API

A Web Api written in .NET Core 8 with SQL Server for Books and Authors management
Third party Packages:

1. MediatR (for CQRS pattern)
2. AutoMapper (for object mapping)

## Installation

1. Clone the repository:
   ```bash
    git clone https://github.com/Raminlich/Library-API.git
    ```

2. Restore NuGet packages:
   ```bash
    dotnet restore
    ```
 or if you are comfortable using Package Manage Console 
  ```bash
     Restore-Package
  ```

3. Set up your database connection string in `appsettings.json`:
    ```bash
   "ConnectionStrings": {
    "Default": "server=YOUR_SERVER;database=LibraryDB;Trusted_Connection=True;TrustServerCertificate=True;"
   }
    ```

## Database Migration

1. Create a migration:
    ```bash
    dotnet ef migrations add initial
    ```

2. Update the database:
    ```bash
    dotnet ef database update
    ```
or if you are comfortable using Package Manage Console 

1. Create a migration:
    ```bash
    Add-Migration initial
    ```
    
2. Update the database:
    ```bash
    Update-Database
    ```

    
