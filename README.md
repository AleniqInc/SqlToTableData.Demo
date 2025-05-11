# SqlToTableData Example

This project is a demo of using the SqlToTableData package, showcasing how to use SqlToTableData to get SQL query results shown in an Angular front-end app.
While SqlToTableData has support for both SQL Server and SQLite, this demo is using the SQLite version.

Demo is a Visual Studio 2022 solution using *Angular and ASP.NET Core* template.

### SqlToTableData 

- [NUGET packages]( https://www.nuget.org/profiles/Aleniq)
- [Source code](https://github.com/AleniqInc/SqlToTableData)

## How to use

First create demo database by updating connection string and running migration scripts, for example:

```
dotnet ef migrations add InitialCreate
dotnet ef database update

```

Make sure that the solution is configured with multiple startup projects, both client and server.

Demo database has 2 tables that will be populated with sample data during migrations.
- Table **City** contains a list of cities with their elevations. 
- Table **Query** contains SQL queries that back-end will retrieve, replace parameters if needed and pass raw SQL to SqlToTableData package to get query results as 2D array.

Angular front-end demo provides 3 components:

1. Classic using API Controller and Entity Framework (what you would get by scaffolding)
2. SqlToTableData demo where client calls API with Query ID   
3. SqlToTableData demo where client calls API with Query ID and parameters

As this is just an example, these are not real parameterized queries, just a simple seach and replace to simulate parameterization. There is no validation or sanitization of the parameters.
 


