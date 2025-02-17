---

# Library System API

The **Library System API** is a RESTful web service built with **ASP.NET Core** and **Entity Framework Core**. It provides endpoints for managing books, users, and book borrowing/returning operations. This API is designed to be scalable, secure, and easy to use.

---

## Features

- **Book Management**:
  - Add, update, delete, and retrieve books.
  - Paginated listing of books.
- **User Management**:
  - Add, update, delete, and retrieve users.
  - Paginated listing of users.
- **Borrow/Return Operations**:
  - Allow users to borrow and return books.
  - Track borrowing history.
- **Authentication**:
  - Secure API endpoints using **JWT (JSON Web Tokens)**.
- **Validation**:
  - Input validation for all requests.
- **Pagination**:
  - Paginated responses for large datasets.
- **Error Handling**:
  - Consistent error responses with meaningful messages.

---

## Technologies Used

- **Backend**: ASP.NET Core
- **Database**: Entity Framework Core (SQL Server, PostgreSQL, or any supported database)
- **Authentication**: JWT (JSON Web Tokens)
- **Validation**: Data Annotations and FluentValidation
- **Logging**: Built-in ILogger
- **Testing**: xUnit, Postman, Swagger

---

## Getting Started

### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download) (version 6.0 or later)
- A database server (e.g., SQL Server, PostgreSQL, SQLite)
- [Visual Studio](https://visualstudio.microsoft.com/) or [Visual Studio Code](https://code.visualstudio.com/)

---

### Installation

1. **Clone the Repository**:
   ```bash
   git clone https://github.com/your-username/library-system-api.git
   cd library-system-api
   ```

2. **Configure the Database**:
   - Update the connection string in `appsettings.json`:
     ```json
     "ConnectionStrings": {
       "DefaultConnection": "Server=your_server;Database=LibrarySystemDb;Trusted_Connection=True;TrustServerCertificate=True;"
     }
     ```

3. **Apply Database Migrations**:
   ```bash
   dotnet ef migrations add InitialCreate
   dotnet ef database update
   ```

4. **Run the Application**:
   ```bash
   dotnet run
   ```

5. **Access the API**:
   - The API will be available at `http://localhost:5000` or `https://localhost:5001`.
   - Use **Swagger** for interactive API documentation: `http://localhost:5000/swagger`.

---

## API Endpoints

### Books
- **GET /api/books**: Retrieve a paginated list of books.
- **GET /api/books/{id}**: Retrieve a specific book by ID.
- **POST /api/books**: Add a new book.
- **PUT /api/books/{id}**: Update an existing book.
- **DELETE /api/books/{id}**: Delete a book.

### Users
- **GET /api/users**: Retrieve a paginated list of users.
- **GET /api/users/{id}**: Retrieve a specific user by ID.
- **POST /api/users**: Add a new user.
- **PUT /api/users/{id}**: Update an existing user.
- **DELETE /api/users/{id}**: Delete a user.

### Borrow/Return
- **POST /api/borrow**: Allow a user to borrow a book.
- **POST /api/return**: Allow a user to return a book.

### Authentication
- **POST /api/auth/register**: Register a new user.
- **POST /api/auth/login**: Authenticate a user and return a JWT token.

---

## Example Requests

### Add a Book
**Request**:
```http
POST /api/books
Content-Type: application/json

{
  "title": "The Great Gatsby",
  "author": "F. Scott Fitzgerald",
  "isbn": "9780743273565"
}
```

**Response**:
```json
{
  "id": 1,
  "title": "The Great Gatsby",
  "author": "F. Scott Fitzgerald",
  "isbn": "9780743273565"
}
```

### Borrow a Book
**Request**:
```http
POST /api/borrow
Content-Type: application/json

{
  "bookId": 1,
  "userId": 1
}
```

**Response**:
```json
{
  "id": 1,
  "bookId": 1,
  "userId": 1,
  "borrowDate": "2023-10-01T12:00:00Z",
  "returnDate": null
}
```

---

## Authentication

To access protected endpoints, include the JWT token in the `Authorization` header:
```http
Authorization: Bearer <your-jwt-token>
```

---

## Testing

### Using Swagger
- Open `http://localhost:5000/swagger` in your browser.
- Use the interactive UI to test all endpoints.

### Using Postman
- Import the provided Postman collection (if available).
- Test endpoints by sending requests to `http://localhost:5000/api`.

---

## Contributing

Contributions are welcome! Please follow these steps:
1. Fork the repository.
2. Create a new branch (`git checkout -b feature/YourFeature`).
3. Commit your changes (`git commit -m 'Add some feature'`).
4. Push to the branch (`git push origin feature/YourFeature`).
5. Open a pull request.

---

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

---

## Contact

For questions or feedback, please contact:
- Davide Deidda 
- **Email**: deiddadavideau@gmail.com


---
