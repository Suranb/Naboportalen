# NaboPortalen

## Setup

##### Docker
1. Run ``docker compose up`` from **root**.
2. Copy Paste this into `appsettings.Json` (Naboportalen.Api).
```  
    "ConnectionStrings": {
        "DefaultConnection": "Host=localhost;Port=5432;Database=Naboportalen;Username=user;Password=secret"
    },
```

### Migration Instructions
Assume your'e in root:
`C:\..\Naboportalen> |`
##### Add Migration
`dotnet ef migrations add initalMigration --project .\src\Naboportalen.Infrastructure\ --startup-project .\src\Naboportalen.Api\`

##### Update database
`dotnet ef database update --project .\src\Naboportalen.Infrastructure\ --startup-project .\src\Naboportalen.Api\`