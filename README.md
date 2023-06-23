# Skylight

Skylight is a web application for viewing, tracking, and cataloging weather events.

## Getting Started
### Prerequisites
- Visual Studio 2022 with .NET 7.0+
- Node.js v16.16.0+
- Angular CLI v14.0.6+

### Project Setup
1) Right-click on the Skylight-API project and select `Manage User Secrets...` to add a local configuration that is not checked into version control. Add the following string, configured to be your local connection string for SQL Server.
```
"ConnectionStrings": {
    "Default": "your connection string here"
}
```