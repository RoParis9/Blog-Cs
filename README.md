# Simple CRUD Project - Users, Posts, and Comments

This project is a simple CRUD (Create, Read, Update, Delete) application built using C# programming language. It serves as a learning project to understand and practice C# concepts, ASP.NET Core, and database operations.

## Project Overview

The project consists of the following entities:

- User: Represents a user of the application. It stores user information such as name, email, and password.

- Post: Represents a blog post. It contains information about the post's title, content, creation date, and associated user.

- Comment: Represents a comment made on a post. It includes the comment content, creation date, and associated user and post.

The application allows performing basic CRUD operations on these entities, including creating, reading, updating, and deleting users, posts, and comments.

## Technologies Used

- C#: The primary programming language used to develop the application.
- ASP.NET Core: The framework used for building web APIs and handling HTTP requests.
- Entity Framework Core: The object-relational mapping (ORM) tool used for database operations.
- PostgreSQL: The database management system used to store and retrieve data.
- Docker: Used to containerize the application and simplify deployment.


## Getting Started

To run the project locally, follow these steps:

1. Install the necessary dependencies and tools (e.g., .NET Core 7 SDK, docker-compose).
2. Clone the repository: `git clone <repository-url>`.
3. Configure the connection string for the PostgreSQL database in the project settings.
4. Run the command docker-compose up -d to get the postgres database
5. Run the command dotnet ef database update to apply the migrations on the database.
6. Build and run the project using the development server with the command "dotnet run".
7. Access the application in a web browser at the specified URL.

## Contributions

This project was created for educational purposes to learn C# and related technologies. Contributions, suggestions, and improvements are welcome. Feel free to submit a pull request or open an issue if you come across any bugs or have ideas for enhancements.

## License

This project is released under the [MIT License](LICENSE).

