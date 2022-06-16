# MakeupStore

## Project Structere

```
/src
- ApplicationCore
- Infrastructure
- Web

/tests
- UnitTests
```
## Packages

```
/ApplicationCore
Install-Package Ardalis.Specification -v 5.2.0

/Infrastructure
Install-Package Microsoft.EntityFrameworkCore -v 5.0.17
Install-Package Npgsql.EntityFrameworkCore.PostgreSQL -v 5.0.10
Install-Package Ardalis.Specification.EntityFrameworkCore -v 5.2.0
Install-Package Microsoft.AspNetCore.Identity.EntityFrameworkCore -v 5.0.17

```
## Migrations
```
/Infrastructure
Add-Migration InitialCreate -Context StoreContext -OutputDir Data/Migrations
Update-Database -Context StoreContext

Add-Migration InitialCreate -Context AppIdentityDbContext -OutputDir Identity/Migrations
Update-Database -Context AppIdentityDbContext

```

## Useful Links
https://www.connectionstrings.com/npgsql/

https://gist.github.com/yigith/c6f999788b833dc3d22ac6332a053dd1
