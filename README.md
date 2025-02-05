# Hero API

This project is a .NET 5.0 Web API that demonstrates CRUD operations for managing superheroes. It uses Entity Framework Core with a MySQL database.

## Features

- **CRUD Operations**: Create, Read, Update, and Delete superheroes.
- **Entity Framework Core**: For database operations.
- **Swagger**: Built-in API documentation.

## Project Structure

- `Controllers/`: Contains the API controllers.
  - [`SuperHeroController.cs`](WebApplication1/Controllers/SuperHeroController.cs): Manages superhero data.
- `Data/`: Contains the database context.
  - [`DataContext.cs`](WebApplication1/Data/DataContext.cs): Defines the database context.
- `Migrations/`: Contains the database migrations.
- `Models/`: Contains the data models.
  - [`SuperHero.cs`](WebApplication1/Models/SuperHero.cs): Defines the superhero model.
- `Startup.cs`: Configures the services and the app's request pipeline.
- `Program.cs`: Contains the main entry point of the application.

## Getting Started

### Prerequisites

- [.NET 5.0 SDK](https://dotnet.microsoft.com/download/dotnet/5.0)
- [MySQL](https://www.mysql.com/)

### Setup

1. Clone the repository:
    ```sh
    git clone https://github.com/yourusername/your-repo-name.git
    cd your-repo-name
    ```

2. Update the connection string in [appsettings.json](http://_vscodecontentref_/0):
    ```json
    "ConnectionStrings": {
      "DefaultConnection": "Server=localhost;Database=superherodb;User=root;Password=yourpassword;charset=utf8mb4;pooling=true"
    }
    ```

3. Apply the migrations to create the database:
    ```sh
    dotnet ef database update
    ```

4. Run the application:
    ```sh
    dotnet run
    ```

5. Open your browser and navigate to `https://localhost:5001/swagger` to view the Swagger UI.

## API Endpoints

- **GET /api/superhero**: Retrieves a list of all superheroes.
- **GET /api/superhero/{id}**: Retrieves a superhero by ID.
- **POST /api/superhero**: Creates a new superhero.
- **PUT /api/superhero/{id}**: Updates an existing superhero by ID.
- **DELETE /api/superhero/{id}**: Deletes a superhero by ID.

## Learning Outcome

This project demonstrates my successful learning and implementation of a .NET API with CRUD operations. I have used Entity Framework Core for database interactions and documented the API with Swagger for easy testing and visualization.
