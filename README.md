# EFAssetTrackingDb

EFAssetTrackingDb is a simple console application using Entity Framework Core with four classes representing database tables: `Phone`, `Computer`, `Office`, and `HQ` (Headquarters). It also includes a `Display` class for output to the screen, a `DbQuerys` class with methods for queries to the database, and a `MyDbContext` class with connections to the database.

## Installation

1. Clone the repository to your local machine.

   ```bash
   git clone https://github.com/Daaxes/EFAssetTrackingDb.git
Open the solution in Visual Studio or your preferred C# development environment.

Install nuget packages
Microsoft.EntityFrameworkCore
Microsoft.EntityFrameworkCore.SqlServer
Microsoft.EntityFrameworkCore.Tools

Use NuGet Package Manager Console to create and update the database.
Copy code
  add-migration createDatabases
  Update-Database
Usage
Run the program by executing the Program.cs file.

bash
Copy code
dotnet run
The program will display information about assets, offices, and headquarters in the console.

Classes
Phone
Represents a phone entity in the database.

Computer
Represents a computer entity in the database.

Office
Represents an office entity in the database.

HQ (Headquarters)
Represents a headquarters entity in the database.

Display
Handles output to the console.

DbQuerys
Contains methods for database queries.

MyDbContext
DbContext class for Entity Framework Core with database connections and seeding data.

License
This project is licensed under the MIT License - see the LICENSE.md file for details.
Contains methods for database queries.

MyDbContext
DbContext class for Entity Framework Core with database connections and seeding data.
