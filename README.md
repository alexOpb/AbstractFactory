# AbstractFactory

The factory design pattern is used to enable selecting one of the databases (MSSQL, PosgreSQL, SQLite) by changing the configuration file.
Classes in the folder `TestHelpers` are used to initialize databases by creating tables and inserting sample values.
Dapper is used to make queries.

To run:

1. Open terminal in solution folder.
2. Run `docker-compose up -d` to start the `MSSQL` and `PostgreSQL` servers in Docker.
3. Set `DatabaseType` in `appsettings.Development.json` to either `MSSQL`, `PostgreSQL`, or `SQLite`.
4. Run app, open Swagger UI, and use GET method to get users.

The output should be:
```json
[
  {
    "id": 1,
    "firstName": "John",
    "lastName": "Doe"
  },
  {
    "id": 2,
    "firstName": "Jane",
    "lastName": "Doe"
  },
  {
    "id": 3,
    "firstName": "Alice",
    "lastName": "Johnson"
  }
]
```

Todos:
1. Separate controllers can be created for each database type, with the appropriate initializer used in each controller.
2. Consider the practicality of using multiple database systems, including their impact on maintainability, performance, and scalability.
3. Make sure that it is a correct implementation of the factory design pattern.
