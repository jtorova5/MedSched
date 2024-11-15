# Products API with JWT Authentication
MedSched is a web-based application designed to manage medical appointments for both doctors and patients. The platform allows users to log in, schedule appointments, and manage medical records efficiently.

## Features
CRUD (Create, Read, Update, Delete) operations for Guests.
Authentication and authorization using JSON Web Tokens (JWT).
Protected endpoints, accessible only to authenticated employess.
Integrated with Swagger for API testing and exploration.

## Requirements
+ .NET 8 SDK or higher.
+ MySQL server.
+ Swagger is integrated, so no need for Postman or external API testing tools.
+ Environment Variables
Ensure you set the following environment variables before running the application:

```csharp
DB_HOST = host
DB_DATABASE = database
DB_USERNAME = username
DB_PASSWORD = password
DB_PORT = port

JWT_KEY = your_jwt_key
JWT_ISSUER = your_jwt_issuer
JWT_AUDIENCE = your_jwt_audience
JWT_EXPIRES_IN = time_in_minutes
```
## Project Setup
### Clone the repository:

```bash
git clone https://github.com/jtorova5/MedSched.git
```
```bash
cd HotelAPI
```

### Restore NuGet packages:

Run the following command in the project directory to restore necessary packages:

```bash
dotnet restore
```

### Set environment variables:

Before running the application, ensure that the environment variables for the database and JWT are set up as shown above.

### Apply database migrations:

Run the following command to apply migrations and set up the database tables:

```bash
dotnet ef database update
```

###  Run the API:

Start the API using the following command:

```bash
dotnet run
```

###  Access Swagger UI:

After running the API, Swagger will be available at https://localhost:5001/swagger or http://localhost:5033, where you can explore and test the API directly.

## JWT Authentication
To access protected endpoints, you first need to authenticate by sending a POST request to /api/v1/auth/login with your user credentials. The server will return a JWT token, which you must include in the headers of subsequent requests:

```bash
Authorization: Bearer {your-jwt-token}
```

## Technologies Used
+ ASP.NET Core 8
+ Entity Framework Core
+ JWT (JSON Web Tokens)
+ MySQL Database
+ Swagger (for testing and API documentation)

## License

© 2024 Riwi. All rights reserved.

The content of this project, including but not limited to text, images, graphics, and code, is the property of Riwi.