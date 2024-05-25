# Skylight

Skylight is a web application for monitoring, tracking, and viewing weather events.

- Participate in an event in real-time by receiving critical alerts and information regarding immediate weather threats.
- Share alerts with others to keep everyone informed during a weather event.
- Review statistics, measurements, and other data about historical weather occurrences.

## Getting Started
### Tools
Skylight is developed with the following tools:
- Docker
- Visual Studio
- Node.js
- Angular CLI

### Project Configuration
1) Right-click on the Skylight-API project and select `Manage User Secrets...` to add a local configuration that is not checked into version control. Add the following string, configured to be your local connection string for SQL Server.
```
"ConnectionStrings": {
    "Default": "your connection string here"
}
```
