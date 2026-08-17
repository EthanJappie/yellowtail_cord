# AGENTS.md - Model Development standards

## Project Identity

- **Name**: Yellowtail.Cord
- **Type**: RESTful Web API
- **Framework**: .Net 8.0 (LTS)
- **API Style**: Controllers
- **ORM**: Entity Framework Core
- **Database**: SQLite
- **Auth**: No Auth

---

## Architecture

Clean architecture. Dependancy flow: Api -> Application -> Domain

```
/src
    |-- Yellowtail.Cord
    |-- Yellowtail.Cord.Application
    |-- Yellowtail.Cord.Domain
    |-- Yellowtail.Cord.Infrastructure
/tests
    |-- Yellowtail.Cord.UnitTests
    |-- Yellowtail.Cord.IntegrationTests
```

- CQRS with Mediatr for command and query seperation of concerns
- Repository pattern: Intefaces in the Application layer and implementation in the Infrastructure layer
- DTO's for all API input and output data movement. Do not expose domain entities to api.
- Vertical slice within the Application: `Features/{Feature}/{Operation}/`.

---

## C# Coding standards

- PascalCase: classes, methods, properties and constants.
- camelCase: local variables and parameters.
- `_camelCase`: For private local fields.
- `I` prefix for interfaces: `IMember`.
- `Async` suffic for async method: `GetMembersAsync`
- Always use `async`/`await` for async calls and never make use of `.Result` or `Wait()` on async methods.
- Always pass the `CancellationToken` when dealing with async call chains.
- No `#region`.
- When dealing with collection return types, never return `null`, return an empty collection
- Register dependancy injection with extension methods and not directly in the Program.cs class
- EF Core: Make use of `AsNoTracking` when only doing a read.
- EF Core: Use `IEntityTypeCOnfiguration<T>` for entity configs

---

## Api Design

- Day one versioning: `/api/v1/`.
- Use RFC 9457 Problem Details for all errors.
- Api Pagination: `?page=1&pageSize=20`, include the pagingin metdata in the response body.
- OpenAPI 3.1 api spec at `/openapi/v1.json`

---

## Security (Non-negotiable)

### Auth

- There is currently no auth required for this POC

### Data Input

- FluentValidation on all incoming DTO's in the Application layer
- Max lengths, allowed pattersn and numeric ranges

### Data

- Never return the entities directly from the database, always map to the corresponding DTO
- Redact sensitive data in the applications structured ogs.

### Rate Limiting

- Fixed Window: Use 100 requests per minute as the default.

### Headers

- `X-Content-Type-Options: nosniff`, `X-Frame-Options: DENY`.
- Remove `Server` and `X-Powered-By`.

### Secrets

- Never hardcode. User Secrets locally, Key Vault when deploying in production.

## Testing

- xUnit + FluentAssertions + NSubstitute.
- Name: `MethodName_State_ExpectedBehaviour`.
- Unit tests: Domain + Application (80%+ coverage).
- Integration tests: `WebApplicationFactory` + Testcontainers.
- Security tests: verify 401, 403, 400, 429 responses.

---

## Agent Behaviour

- Plan before coding if change > 3 files.
- Generate complete, compilable code. No placeholders.
- Follow the project structure. Put files in the correct layer.
- Run `dotnet build` and `dotnet test` after changes.
- Never disable HTTPS, auth, or security for convenience.
- Never hardcode secrets.
- Preserve unrelated comments when modifying files.
- Report: files changed, patterns used, decisions made.
