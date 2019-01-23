# selenium-dotnet-core
A test automation project built on xunit framework using .NET Core and C#.

## Zola Sample Test
This repository contains a sample test automation project built on xunit framework using .NET Core and C#.
The test is supposed to:
- Navigate to Zola career's page
- Click on the "Apply" button for one of the available roles (6th on  the list - Quality Assurance Engineer at the time of testing)
- Fill up all fields in the application form then submit the form - (submit button is commented out in this test)

## Prerequisites:
- .NET Core SDK v2.0 or higher

## Development Environment:
On any terminal (I used Git Bash) move to the "Rafa.Tests" folder (the folder containing the "Rafa.Tests.csproj" file),
and execute the following commands:
- dotnet restore
- dotnet test

Alternatively, you can open the project in Visual Studio or VS Code IDE, build the project then execute the test.
