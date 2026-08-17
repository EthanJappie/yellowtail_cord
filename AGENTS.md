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
