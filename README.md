# Asp.Net Core API & Angular.js

### Entity Framework

- Packages

```sh
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet tool install --global dotnet-ef
dotnet add package Microsoft.EntityFrameworkCore.Design
```

- Add migrations and update database

```sh
dotnet ef migrations add InitialCreate
dotnet ef database update
```
