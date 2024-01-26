# Rillion Expense Tracker

The Expense Tracker is a `net8.0` ASP.NET Core Web API, secured with ASP.NET Core Identity token based authentication. It implements a simple CQRS pattern driven by [MediatR](https://github.com/jbogard/MediatR) and uses [FluentValidations](https://docs.fluentvalidation.net/en/latest) and Entity Framework Core for model validation and data access respectively.

## Requirements

The project requires a running, empty MSSQL database. LocalDB should work, but I couldn't verify that on my machine (LocalDB does not have native Linux support).

The [REST Client](https://marketplace.visualstudio.com/items?itemName=humao.rest-client) extension for Visual Studio Code (or similar) is required to execute API calls from an `.http` file.

## Installation

Configure the connection string for the MSSQL database in `Rillion.AspNet/appsettings.json`.

All the commands are run from the root of the repository

Build the project.

```
dotnet build rillion.sln
```

Apply the Entity Framework migrations.

```
dotnet ef --project=Rillion.Infrastructure --startup-project=Rillion.AspNet database update
```

## Usage

The project was developed using Visual Studio Code and this guide will focus on the dotnet CLI. It should work as is with Visual Studio or Rider. Again, all commands are run from the root of the repository.

Run the unit tests

```
dotnet test
```

Run the Web API

```
dotnet run --project=Rillion.AspNet
```

## Calling the endpoints

The project includes an HTTP file at `Rillion.AspNet/rillion.http` for calling the API.

Start by creating a user with the `/register` endpoint. The password requirements are
- must be at least 6 characters long
- must have at least one non alphanumeric character
- must have at least one digit ('0'-'9')
- must have at least one lowercase ('a'-'z')
- must have at least one uppercase ('A'-'Z')
- must use at least 1 different character

Use the `/login` endpoint to fetch the `accessToken` for the user. Append the access token the Authorization header as a Bearer token before calling those endpoints, e.g.

```
GET {{rillion_HostAddress}}/manage/info
Accept: application/json
Authorization: Bearer **access token goes here**
```

Alternatively you may follow these steps using another tool such as cURL of Postman.