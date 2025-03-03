# UserAndRoleManagement- Noventiq

## Overview

This solution is built with **.NET 8** and follows a clean architecture pattern. It consists of multiple projects:

- **Web** (`Web.csproj`) - The main API/Web application.
- **Application** (`Application.csproj`) - Contains business logic and use cases.
- **Core** (`Core.csproj`) - Defines domain models, entities, and interfaces.
- **Infrastructure** (`Infrastructure.csproj`) - Handles database access, external services, and other implementations.

## 🏗️ Project Structure

UserAndRoleManagement.sln  
├── /src  
│   ├── /Application # [Business logic and service layer] (**Project| Library**)  
│   ├── /Core # [ Domain entities ] (**Project| Library**)  
│   ├── /Infrastructure # [Infra related code such as db] (**Project| Library**)  
│   └── /Web # [API  ]  (**Project| Library**)   
|           ├── Properties  
|           |     ├── launchsettings.json    
|           ├── application.Local.json  
|           ├── application.json  
|
├── /tests  # Unit and integration tests (**Project| Library**)   
├── UserAndRoleManagement.sln   
└── README.md
 





##  Getting Started

### Prerequisites

- **.NET 8 SDK** - Download from [dotnet.microsoft.com](https://dotnet.microsoft.com/)
- **SQL Server** (or any required database)



###  Setup & Installation
1. **Configuration settings in application.Local.json**
    ```
    { 
    "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }},
    "Auh0": {
    "Issuer": "https://dev-6px6shj7bfjwm0h8.us.auth0.com/",
    "Audience": "https://dev-6px6shj7bfjwm0h8.us.auth0.com/api/v2/"
    }, 
    "ConnectionStrings": {
    "DefaultConnection": ""}}
    ```

2. **Steps**
   
   ```git clone https://github.com/vijaypandeyy/UserAndRoleManagement-noventiq.git```
   
   ```cd UserAndRoleManagement ```

   ```cd src/Web ```

   ```dotnet restore ```

   ```dotnet build ```

   ```dotnet run ```


