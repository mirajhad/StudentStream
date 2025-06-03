# Student Management System

A comprehensive student management system built using .NET, following a layered architecture pattern. This system provides functionality for managing student information, courses, and academic records.

## Project Structure

The solution is organized into multiple projects following a clean architecture approach:

- **StudentManagement.UI**: The presentation layer containing the user interface components
- **StudentManagement.BLL**: Business Logic Layer handling business rules and operations
- **StudentManagement.Data**: Data Access Layer managing database operations and data persistence
- **StudentManagement.Models**: Contains the domain models and data transfer objects

## Prerequisites

- .NET 6.0 or later
- Visual Studio 2022 or later
- SQL Server (for database operations)

## Getting Started

1. Clone the repository:
```bash
git clone [repository-url]
```

2. Open the solution in Visual Studio:
   - Open `StudentManagement.sln`

3. Restore NuGet packages:
   - Right-click on the solution in Solution Explorer
   - Select "Restore NuGet Packages"

4. Build the solution:
   - Press F6 or select Build > Build Solution

5. Run the application:
   - Set StudentManagement.UI as the startup project
   - Press F5 to run the application

## Project Architecture

The project follows a layered architecture pattern:

- **UI Layer**: Handles user interface and user interactions
- **Business Layer**: Implements business logic and rules
- **Data Layer**: Manages data access and persistence
- **Models**: Contains shared domain models and DTOs

## Features

- Student information management
- Course management
- Academic record tracking
- User authentication and authorization
- Reporting and analytics

## Contributing

1. Fork the repository
2. Create a feature branch
3. Commit your changes
4. Push to the branch
5. Create a Pull Request

## License

This project is licensed under the terms included in the LICENSE.txt file.

## Contact

For any queries or support, please open an issue in the repository. 