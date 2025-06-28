# Clean Architecture Course Project

This repository contains the source code developed during the Clean Architecture course by Taner Saydam on Udemy.  
The project demonstrates how to build a modular, maintainable .NET application using Clean Architecture principles.

## ✨ Features

- ASP.NET Core Web API
- Entity Framework Core for data access
- Repository and Unit of Work patterns
- Dependency Injection
- Separation of Concerns
- Layered architecture
  - Core
    - Domain
    - Application
  - External
    - Infrastructure
    - Persistence
    - Presentation
  - WebApi
- Basic CRUD operations

## 🛠️ Technologies

- .NET 9
- ASP.NET Core Web Api
- Entity Framework Core

## 🚀 Getting Started

1. Clone the repository:

```bash
git clone https://github.com/taberkkaya/CleanArchitecture.git
```

2. Navigate into the project folder:

```bash
cd CleanArchitecture
```

3. Restore dependencies:

```bash
dotnet restore
```

4. Update the database (if using EF Core migrations):

```bash
dotnet ef database update
```

5. Run the project:

```bash
dotnet run
```

6. The API will be available at:

```bash
https://localhost:7296/swagger
```

## 📚 Learning Resources

- _[Taner Saydam's Udemy profile](https://www.udemy.com/user/taner-saydam/?kw=taner+saydam&src=sac)_ ⭐⭐⭐⭐⭐ <br>
- [Clean Architecture Öğrenelim - Udemy@TanerSaydam](https://www.udemy.com/course/clean-architecture-ile-sifirdan-uygulama-gelistirelim)
