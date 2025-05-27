# Skylight

https://www.skylight-weather.app

Skylight is a web application for monitoring, tracking, and viewing weather information.

- Collect statistics, measurements, and other products about current and historical weather events.
- Receive alerts and information regarding immediate weather threats.
- Customize a dashboard to organize all required information.

## Getting Started
### Tools
Skylight uses .NET Aspire to simplify the local development experience and requires the following tools to run locally:
- Docker & Docker Desktop
- .NET Core
- Node.js

### System Design
Refer to the `docs` directory to review architectural information and system design considerations.

Skylight is designed to be a practical playground for learning about and experimenting with modern technologies and development practices.
It follows the Clean Architecture paradigm to organize code around dependencies, with business logic implemented as CQRS use cases, or features.

High-level examples include:

- .NET Aspire: tooling to orchestrate and observe services locally
- OpenTelemetry: observability framework for measuring traces and spans
- Entity Framework Core: ORM to manage database access
- Dapper: lightweight ORM for simplified database access
- .NET Identity: user authentication and authorization provider
- Mediator Pattern: an abstraction over business logic handler routing
- Fluent Validation: validation library providing helpers and injectable services for performing request/response validation
- Hangfire: schedule and execute asynchronous background jobs on the web server
- SignalR: send "push" updates to web clients over a websocket connection for real-time notifications
- Scalar: OpenAPI UI for exploring and executing HTTP requests locally
- NSwag: OpenAPI client generation utility
- Vue: frontend library for building responsive web interfaces
- Vite: frontend build tool for hosting development servers and bundling web artifacts
- Nuxt: frontend framework providing full-stack capabilities, such as routing, data fetching, server-side rendering, and SEO
- Tailwind: CSS framework providing utility classes for structuring and styling web interfaces
- xUnit: .NET testing framework
- Moq: mocking library for unit tests
