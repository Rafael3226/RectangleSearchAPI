# RectangleSearchAPI

RectangleSearchAPI is an API developed using C# .NET Core, SQL Server, and Entity Framework. The main purpose of this project is to determine whether a given coordinate falls within the boundaries of a quadrilateral. The Barycentric Coordinates equation is employed to perform this calculation.

## **Configuration**

Before running the project, ensure that you configure the connection string for the SQL Server database in the **`appsettings.json`** file. To update the database, execute the following command in the Package Manager Console: **`Update-Database`**.

## **Authentication**

Authentication for the API is implemented using an API key, which must be included in the header of the HTTP request. Add the following header to your request: 

**`{ "X-Api-Key": "5efeb53f20d64bb68d5322d02c5fd867"}`** 

By default, authentication is disabled. To enable it, modify the **`appsettings.json`** file and set **`"Authentication:On"`**.

## **Design Pattern**

The API implementation utilizes the DTO (Data Transfer Object) design pattern.

## **Data Model**

The data model consists of two tables: **`Coordinates`** and **`Rectangles`**. The relationship between these tables is one-to-many.

## **Database Seeding**

If the database is empty, the project will automatically seed it with initial data.

Please let me know if there is anything else you would like to add or if you have any further questions!
