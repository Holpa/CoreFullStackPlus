 **CoreFullStackPlus** This Application is a full package to start a full fledge website

# Purpose/Why:

    Solves the issue to start a full stack websites including background services via using simple commands

# TechStack:

    Language: C#
    Frameworks: Core .NET 8, WEB API, Worker Service, Static Front end

# Dependencies

    Runtime: .NET 8 SDK https://dotnet.microsoft.com/en-us/download
    IDE: Visual Studio (Preferred)
        ms-dotnettools.vscode-dotnet-pack
        ms-dotnettools.vscode-dotnet-runtime
        ms-dotnettools.csharp
        ms-dotnettools.csdevkit
        ms-dotnettools.vscodeintellicode-csharp

# Build:

    Full Build (WebAPI,FrontEnd,Background worker):
        dotnet build
        dotnet run

    Build (WebAPI, Frontend):
        dotnet build
        dotnet run -- no-background-worker

    Build (Background worker):
        dotnet build

    for the DB connection you can simply have the DB connection in appsettings.json OR
    store it locally in the machine as secret (Recommended)
    more insight about Dependency Injection: https://learn.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection?view=aspnetcore-8.0

    dotnet user-secrets init

    dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Data Source=YOURPC;Initial Catalog=YOURDB;Persist Security Info=True;User ID=YOURID;Password=YOURPW;TrustServerCertificate=True;"

    Site port: can be addressed in folder Property launchSettings.json

# How To Use:

    Completion of dotnet run
    App will run on localhost port 5173
    access: http://localhost:5173

# Contributions:
