<h2>Commands VsCode:</h2> 

O Mediator é um padrão de projeto Comportamental criado pelo GoF, que nos ajuda a garantir um baixo acoplamento entre os objetos de nossa aplicação. Ele permite que um objeto se comunique com outros sem saber suas estruturas. Para isso devemos definir um ponto central que irá encapsular como os objetos irão se comunicar uns com os outros.

> dotnet new webapi -n "Solution" -f netcoreapp3.0

> dotnet add package FluentValidation

> dotnet add package FluentValidation.DependencyInjectionExtensions

> dotnet add package MediatR

> dotnet add package MediatR.Extensions.Microsoft.DependencyInjection

> dotnet add package Swashbuckle.AspNetCore.Annotations

> dotnet add package Swashbuckle.AspNetCore.SwaggerGen

> dotnet add package Swashbuckle.AspNetCore.SwaggerUi

<h2>Configuration Swagger:</h2>

> Method Startup.cs - ConfigureServices

```javascript
    // Add Swagger
    services.AddSwaggerGen(options =>
    {
        options.SwaggerDoc("v1", new OpenApiInfo{ Version = "v1", Title = "App", Description = "My app" });
        options.EnableAnnotations();
        options.DescribeAllParametersInCamelCase();
    });
```

> Method Startup.cs - Configure

```javascript
    // Use swagger
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Test");
    });
```

> Method launchSettings.json - modify properties "launchUrl": "swagger"

```javascript
  "profiles": {
    "IIS Express": {
      "commandName": "IISExpress",
      "launchBrowser": true,
      "launchUrl": "swagger",
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development"
      }
    },
    "Solution": {
      "commandName": "Project",
      "launchBrowser": true,
      "launchUrl": "swagger",
      "applicationUrl": "https://localhost:5001;http://localhost:5000",
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development"
      }
    }
  }
```

> Annotation on controller

```javascript
[SwaggerOperation(Summary = "summary....", Description = "description....")]
[SwaggerResponse((int)HttpStatusCode.OK, Swagger.Success, typeof(Notification))]
```

<h2>Tests Xunit:</h2>

> dotnet new xunit -o "Solution.Tests"

> dotnet add package MediatR

> dotnet add package Moq

<h2>Solution for Visual Studio:</h2>

> dotnet new sln

> dotnet sln add src\Solution.csproj

> dotnet sln add tests\Solution.UnitTests.csproj

<h2>Papers reference:</h2>

[Clean ASP.NET Core API using MediatR and CQRS | Setup](https://www.youtube.com/watch?v=YzOBrVlthMk)

[Validation using MediatR's Pipeline Behaviors and FluentValidation | Clean .NET Core](https://www.youtube.com/watch?v=2JzQuIvxIqk&t=632s)

[MediatR com ASP.Net Core](https://www.wellingtonjhn.com/posts/mediatr-com-asp.net-core/)

[Unit Testing in ASP.NET Core Web API](https://code-maze.com/unit-testing-aspnetcore-web-api/)

[CQRS WITH MEDIATR AND ASP.NET CORE](https://www.stevejgordon.co.uk/cqrs-using-mediatr-asp-net-core)