# Template Dotnet Core Projesi

# OVERVIEW

[ASPNET MANUAL](https://github.com/blitzkrieg0000/NETCORE_Template01/tree/main/WebAppOnion)

[DOCKER-CLOUD](https://github.com/blitzkrieg0000/NETCORE_Template01/tree/main/Docker)


# .NetCore Web Application Template

This repository provides a **ready-to-use project template** for building web applications following **Onion Architecture** principles.  
It is a fully structured template including Docker setup, database integration, core layers, infrastructure, and presentation layers.

---

### Docker Environment
- `docker-compose` setup for easy deployment  
- Nginx reverse proxy configuration with SSL support  
- PostgreSQL service with persistent volumes  

### Tools
- SSH and SSL key management scripts  
- Self-signed SSL generation utilities  

### Onion Architecture Layers
1. **Core**
   - Application, Domain, and Common projects  
   - Structured with DTOs, Entities, Features, Interfaces, Validators, etc.  
2. **Infrastructure**
   - Data persistence, repository pattern, migrations  
   - Service registration and supporting utilities  
3. **Presentation**
   - UI layer with MVC / Razor Pages  
   - Controllers, Views, Middleware, Filters, and TagHelpers  

### WebApp Scaffold
- Preconfigured solution and projects ready for extension  
- Scripts for project scaffolding and environment setup  

### Purpose
This template is not tied to any specific business logic. It serves as a foundation for new web applications, providing:
- Organized folder structure
- Ready-to-use layers following Onion Architecture
- Preconfigured Docker environment and SSL setup

You can extend this template by adding your own domain entities, services, UI pages, and API endpoints.
