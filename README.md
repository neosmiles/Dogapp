# Dogapp

Dogapp is a C# application designed to manage information about dogs. This application is built with a focus on maintaining a database of dog details, handling CRUD operations, and providing an API for interacting with the data.

## Features

- **CRUD Operations**: Create, Read, Update, Delete dog information.
- **API Integration**: Exposes endpoints for managing dog data.
- **Database Support**: Uses a database to store dog information.

## Requirements

- .NET Framework
- SQL Server

## Installation

1. Clone the repository:
   ```sh
   git clone https://github.com/neosmiles/Dogapp.git
   ```
2. Navigate to the project directory:
   ```sh
   cd Dogapp
   ```
3. Restore dependencies:
   ```sh
   dotnet restore
   ```

## Usage

1. Update the database connection string in `appsettings.json`.
2. Run the application:
   ```sh
   dotnet run
   ```
3. Access the API at `http://localhost:5000/api/dogs`.

## Project Structure

- `api/`: Contains the API controllers and models.
- `.gitignore`: Specifies files to be ignored by Git.
- `DogApp.sln`: Solution file for the project.
- `global.json`: Global configuration for the .NET SDK.

## Contributing

Contributions are welcome! Please fork the repository and submit a pull request.

## License

This project is licensed under the MIT License.

---

Feel free to customize this template based on additional details or specific requirements of your project.
