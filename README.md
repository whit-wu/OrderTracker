# OrderTracker

## Description
OrderTracker is a RESTful ASP.NET Core Web API application meant to simulate a backend for online grocery shopping applications.  It is used to teach C# Programming II (CIS 229) students at Grand Rapids Community College on how an ASP.NET Core Web API works.  This is accomplished by building on previous concepts taught to them earlier in the class.  It also serves as an introduction to REST, data annotations, Fluent API, unit testing with a mocked in-memory db, and dependency injection.  Since this is a C#-focused class, students will not be tasked with writing a front end for the app.  

## Concepts Built Upon
Concepts that would have been taught to the class prior to using this app include:

1. Separation of Concerns
1. Interfaces and Unit Testing
1. Initial Setup of EF Core
1. EF Core Migrations
1. Querying with LINQ

Prior to reaching this application, students have been creating console apps and/or class libraries to study these concepts.  Now that they have a firm understanding of the material it is time for them to apply what they've learned to a practical application.

## Objectives
Students will be asked to download the application so we can go over it as a class.  Once lecture is completed, they will be asked to further enhance the application by doing the following:
1. Add Data Annotations to their models.
1. Add model constraints via Fluent API.
1. Use TDD to write tests for their methods.
1. Write new methods in the UnitOfWork.
1. Perform manual testing by sending requests via SwaggerUI.

The goal is to simulate a business environment where developers are tasked with adding features to existing applications.  The instructor is to play the role of Business Analyst and will be responsible for presenting requirements to the students as a set of work items.    

## Entity Framework Core and SQL Lite
This application uses EF Core to interact with a SQL Lite database (which will be included in version control).  This database can be accessed via web calls using Swagger UI.  SQL Lite is also used when executing unit tests, but instead creates an in-memory database that is purged after execution.  The goal is to allow students to focus on studying EF Core without adding the extra complexity of installing a full-fleged database.  


