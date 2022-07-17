# Skylight

Skylight is a web application for viewing, tracking, and cataloging weather events.

## Getting Started
### Prerequisites
- Visual Studio 2022
- Node.js v16.16.0+
- Angular CLI v14.0.6+
- MySQL Workbench v8.0+

### Project Setup
1) Open the Solution file in Visual Studio.
2) Right-click on the Skylight-API project and select `Properties`. Navigate to `Debug > General` and click `Open debug launch profiles UI`. Uncheck the `Launch browser` option. Close the Properties menus.
3) Right-click on the Skylight solution and select `Set Startup Projects...` to configure the project startup.
4) Select `Multiple startup projects` and ensure that the API project is before the Web UI project in the list. Set the actions of both projects to `Start`. Click OK.
5) Right-click on the Skylight-API project and select `Manage User Secrets...` to add a local configuration that is not checked into version control.
6) Add the following string, configured to be your local connection string for MySQL.
```
"ConnectionStrings": {
    "Default": "your connection string here"
}
```
7) Click Start to run the program. Two command prompts should open and the webpage should be displayed and connected to the ASP.NET backend API.