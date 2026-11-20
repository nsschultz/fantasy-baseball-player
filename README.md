[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=nsschultz_fantasy-baseball-player&metric=alert_status)](https://sonarcloud.io/summary/new_code?id=nsschultz_fantasy-baseball-player)

# Fantasy Baseball Player Service

An ASP.NET Core Web API microservice that serves as the source of truth for player information in the fantasy baseball ecosystem. This service provides comprehensive player data including CRUD operations, CSV export capabilities, and projection data merge functionality.

## Overview

The Player Service is a foundational microservice used by multiple downstream services to retrieve and manage accurate, up-to-date player information. It focuses on **performance, reliability, and data consistency**.

### Key Characteristics
- **Full CRUD API**: Complete Create, Read, Update, Delete operations on player data
- **CSV Export**: Export player data in CSV format for external systems
- **Data Integration**: Merge projection data with player information
- **Foundation Service**: Used by other fantasy baseball microservices
- **Database-backed**: PostgreSQL provides the source of truth
- **Containerized**: Docker support for cloud deployment
- **Well-documented**: OpenAPI/Swagger integration for API exploration

---

## Prerequisites

- **.NET SDK**: .NET 10.0 or later
- **Docker**: For containerized development and runtime environments
- **PostgreSQL**: For database connectivity (when running outside containers)
- **VS Code**: Recommended IDE with DevContainer support

---

## Setup Instructions

### Local Development

1. **Clone the repository:**
   ```bash
   git clone https://github.com/nsschultz/fantasy-baseball-player.git
   cd fantasy-baseball-player
   ```

2. **Restore dependencies:**
   ```bash
   dotnet restore
   ```

3. **Build the solution:**
   ```bash
   dotnet build
   ```

4. **Run tests:**
   ```bash
   dotnet test
   ```

### Development Container

VS Code DevContainer setup is provided for consistent development environments:

1. In VS Code, use the **"Clone Repository into Container Volume..."** option
2. Or open the workspace folder and select **"Reopen in Container"** when prompted
3. Tasks are pre-configured in `tasks.json` for common operations

---

## Building and Running

### Build the Service

```bash
dotnet build
```

### Run Tests

```bash
# Run all tests
dotnet test

# Run specific test project
dotnet test FantasyBaseball.PlayerService.UnitTests
dotnet test FantasyBaseball.PlayerService.IntegrationTests
```

### Local Execution

```bash
# Run the service locally
cd FantasyBaseball.PlayerService
dotnet run
```

### Docker Image

The service uses a multi-stage Docker build based on:
- **Build Stage**: `nschultz/fantasy-baseball-common-backend:1.2.1` (includes .NET 10 SDK)
- **Runtime Stage**: `mcr.microsoft.com/dotnet/aspnet:10.0` (minimal ASP.NET Core runtime)
- **Database**: PostgreSQL 14.1-alpine

**Build:**
```bash
version=$(cat version.txt) && docker build -t nschultz/fantasy-baseball-player:$version .
```

Builds multi-platform images for amd64 and arm64 architectures, with automatic tag management via CI/CD.

**Development Containers:**
```bash
# Start containers
docker compose -f .docker-compose/docker-compose-dev.yaml -p fantasy-baseball-player up --build -d

# Stop containers
docker compose -f .docker-compose/docker-compose-dev.yaml -p fantasy-baseball-player down
```

**Runtime Containers:**
```bash
# Start containers
docker compose -f .docker-compose/docker-compose-runtime.yaml -p fantasy-baseball-player up --build -d

# Stop containers
docker compose -f .docker-compose/docker-compose-runtime.yaml -p fantasy-baseball-player down
```

---

## Architecture

### Project Structure

```
FantasyBaseball.PlayerService/
├── Controllers/           - ASP.NET Core API endpoints (V3)
├── Database/
│   ├── Entities/         - Domain models (Player, Projection)
│   ├── Repositories/     - Data access layer
│   ├── Migrations/       - EF Core schema migrations
│   └── PlayerContext      - Entity Framework DbContext
├── Services/             - Business logic layer
├── Maps/                 - AutoMapper profiles for DTO mapping
├── Program.cs            - DI configuration and middleware setup
└── appsettings.json      - Configuration

FantasyBaseball.PlayerService.UnitTests/
└── Services/             - Unit tests for services and utilities

FantasyBaseball.PlayerService.IntegrationTests/
└── PlayerIntegrationTests - End-to-end API tests
```

### Key Design Patterns

- **Dependency Injection**: Constructor-based DI via ASP.NET Core
- **Repository Pattern**: IPlayerRepository abstracts data access
- **Async/Await**: All I/O operations are async
- **Mapper Pattern**: AutoMapper handles Entity-to-DTO conversions
- **Health Checks**: Database and Position Service connectivity monitoring

---

## API Endpoints

### Get All Players

```
GET /api/v3/player
```

Returns a JSON array of all players with their current information.

### Get Single Player

```
GET /api/v3/player/{id}
```

Returns detailed information for a specific player.

### Create Player

```
POST /api/v3/player
```

Creates a new player record.

### Update Player

```
PUT /api/v3/player/{id}
```

Updates an existing player record.

### Delete Player

```
DELETE /api/v3/player/{id}
```

Removes a player record.

### Export as CSV

```
GET /api/v3/player/export/csv
```

Exports all player data in CSV format.

### Merge Projections

```
POST /api/v3/player/merge/projections
```

Merges projection data with player information.

### Health Check

```
GET /api/health
```

Returns the service health status. Fails if database or Position Service is inaccessible.

### API Documentation

```
GET /api/swagger/index.html
```

Interactive Swagger UI for exploring and testing API endpoints.

---

## Local Development Access

When running the service locally via Docker Compose:

| Service | URL |
|---------|-----|
| Player API / Swagger | http://localhost:8080/api/swagger/index.html |
| PgAdmin (Database GUI) | http://localhost:9000 |
| PostgreSQL Database | `database:5432` (container network only) |
| Mountebank (Mock Positions) | http://localhost:2525 |
| Positions API | http://mock-positions:5555 |

---

## Code Quality and Testing

### Test Framework

- **Framework**: xUnit
- **Assertion Library**: xUnit.Assert with FluentAssertions patterns
- **Coverage**: 148 tests covering unit and integration scenarios

### Test Structure

- **Unit Tests** (`FantasyBaseball.PlayerService.UnitTests`): Isolated tests for services, repositories, and entities
- **Integration Tests** (`FantasyBaseball.PlayerService.IntegrationTests`): End-to-end API testing with real database

### Running Tests with Coverage

```bash
# Install coverage tool (one-time)
dotnet tool install -g dotnet-coverage

# Generate coverage report
dotnet-coverage collect -f cobertura -o coverage.cobertura.xml dotnet test
```

### Build Status

- **Compilation**: 0 errors, 0 warnings
- **Tests**: All passing (148+ total)
- **Security**: No known vulnerabilities
- **Code Quality**: SonarCloud quality gate passing with ≥ 80% coverage

### CI/CD Workflows

This project uses GitHub Actions for automated quality assurance:

**PR Validation** (`.github/workflows/pr-validation.yml`):
- Triggers on every pull request (opened, synchronize, reopened)
- **Build & Test**: Compiles code and runs test suite with result reporting
- **SonarCloud Quality Gate**: Verifies code quality metrics and coverage ≥ 80%
- **Code Format**: Ensures consistent code style via `dotnet format`
- **Security Scan**: Scans with Trivy for vulnerabilities

**Release Build** (`.github/workflows/docker-image.yml`):
- Triggers on merge to main branch
- Builds multi-platform Docker images (amd64, arm64)
- Pushes both versioned and `latest` images to Docker Hub

---

## C# Best Practices

This project adheres to the C# best practices defined in [.github/agents/CSharpExpert.agent.md](.github/agents/CSharpExpert.agent.md), including:

- ✅ XML documentation for all public APIs
- ✅ Async/await throughout the stack
- ✅ Proper null-checking with ArgumentNullException
- ✅ Descriptive exception types and error handling
- ✅ Dependency injection for testability
- ✅ Comprehensive unit and integration tests
- ✅ SOLID principles and design patterns

---

## Configuration

### Environment Variables

Required environment variables for database connectivity:

- `PLAYER_DATABASE_HOST`: PostgreSQL server host
- `PLAYER_DATABASE`: Database name
- `PLAYER_DATABASE_USER`: Database user
- `PLAYER_DATABASE_PASSWORD`: Database password
- `POSITION_SERVICE_HOST`: Position Service host for integration
- `POSITION_SERVICE_PORT`: Position Service port (default: 5555)

See [.env.example](.env.example) for all available configuration options.

### Connection String

Default connection string in `appsettings.json`:
```
Server={PLAYER_DATABASE_HOST};Database={PLAYER_DATABASE};User Id={PLAYER_DATABASE_USER};Password={PLAYER_DATABASE_PASSWORD};
```

---

## Contributing Guidelines

For detailed contribution guidelines, please see [CONTRIBUTING.md](CONTRIBUTING.md).

When contributing to this project:

1. **Follow C# Best Practices**: Reference [.github/agents/CSharpExpert.agent.md](.github/agents/CSharpExpert.agent.md)
2. **Maintain Backward Compatibility**: This is a foundational service used by multiple consumers
3. **Add Tests**: All new public APIs must include corresponding unit and/or integration tests
4. **Document Changes**: Update this README and XML documentation as needed
5. **Run Full Test Suite**: Ensure all tests pass before submitting changes
6. **Code Review**: All changes require code review before merging

### Development Workflow

1. Create a feature branch: `git checkout -b feature/your-feature`
2. Make changes following best practices
3. Run tests: `dotnet test`
4. Commit with descriptive messages
5. Push to your fork and create a Pull Request

For the complete development workflow, see [CONTRIBUTING.md](CONTRIBUTING.md).

---

## Troubleshooting

### Database Connection Issues

If the service fails health checks:
1. Verify PostgreSQL is running and accessible
2. Check environment variables are set correctly
3. Verify database user has appropriate permissions
4. Check logs for specific connection error details

### Position Service Unreachable

If Position Service health check fails:
1. Verify Position Service is running
2. Check `POSITION_SERVICE_HOST` and `POSITION_SERVICE_PORT` are correct
3. Verify network connectivity between services
4. Check logs for specific error details

### Build Failures

1. Ensure .NET 10.0 SDK is installed: `dotnet --version`
2. Restore packages: `dotnet restore`
3. Clean build: `dotnet clean && dotnet build`

### Test Failures

1. Run tests individually to isolate issues: `dotnet test --filter NameOfTest`
2. Check for side effects or test ordering issues
3. Verify database state for integration tests

---

## DevOps Documentation

For deployment and operational guidance, see:

- **[DEPLOYMENT.md](./DEPLOYMENT.md)** - Release procedures and deployment strategies
- **[DEVOPS_RUNBOOK.md](./DEVOPS_RUNBOOK.md)** - Quick reference for operations and troubleshooting
- **[SLO_SLA.md](./SLO_SLA.md)** - Service level objectives and agreements
- **[.github/agents/DevOpsExpert.agent.md](.github/agents/DevOpsExpert.agent.md)** - DevOps principles and practices

---

## Additional Resources

- [Microsoft .NET Documentation](https://learn.microsoft.com/en-us/dotnet/)
- [ASP.NET Core Documentation](https://learn.microsoft.com/en-us/aspnet/core/)
- [Entity Framework Core](https://learn.microsoft.com/en-us/ef/core/)
- [AutoMapper Documentation](https://docs.automapper.org/)
- [xUnit Documentation](https://xunit.net/docs/getting-started)
- [SonarCloud Documentation](https://docs.sonarcloud.io/)

