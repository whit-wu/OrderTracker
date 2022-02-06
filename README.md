# OrderTracker

## Description
OrderTracker is an ASP.NET Core Web API application meant to teach C# Programming II (CIS 229) at students Grand Rapids Community College how the repository pattern is implemented with Entity Framework Core.  The application does this by building on previous concepts taught to them earlier in the class.  Simply put, it takes all the concepts we've been studying thus far and consolidates them to a single application.  It also serves as an introduction to Web APIs, data annotations, Fluent API, unit testing with a mocked/in-memory db, and dependency injection.

## Concepts Built Upon
Concepts that would have been taught to the class prior to using this app include:

1. Separation of Concerns
1. Interfaces and Unit Testing
1. Intital Setup of EF Core
1. EF Core Migrations
1. Querying with LINQ

Prior to reaching this application, students have been creating console apps and/or class libraries to studey these concepts.  Now that they have a firm understanding of the material it is time for them to apply what they've learned to a practical application.

## Objectives
Students will be asked to download the application so we can go over it as a class.  Once lecture is completed, students will be asked to further enhance the application by doing the following:
1. Add Data Annotations to their models.
1. Add addtional contraints via Fluent API.
1. Use TDD to write tests for their methods.
1. Write new methods in the UnitOfWork.
1. Peform manual testing by sending requests via SwaggerUI.

## Enity Framework Core and SQL Lite
This application uses EF Core to interact with a SQL Lite database (which will be included in version control).  This database can be accessed via web calls using Swagger UI.  SQL Lite is also used when executing unit tests, but instead creates an in-memory database that is purged after execution.  The goal is to allow students to focus on studying EF Core without adding the extra complexitiy of installing a full-fleged database.  