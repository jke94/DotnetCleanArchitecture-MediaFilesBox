[![master](https://github.com/jke94/DotnetCleanArchitecture-MediaFilesBox/actions/workflows/master.yml/badge.svg)](https://github.com/jke94/DotnetCleanArchitecture-MediaFilesBox/actions/workflows/master.yml)

# MediaFilesBox
A dotnet web api with a clean architecture design.

## Docker.

- From base repository folder as base directory: 

### 1. Docker-compose: Start MediaFilesBox.WebApi.

- Windows:

```
docker-compose.exe -f ./docker-compose.yml -p mediafilebox up --build
```

- Linux
```
sudo docker compose -f ./docker-compose.yml -p mediafilebox up --build
```
### 2. Open:

- http://localhost:5080/swagger/index.html

### 3. Add Migration

```
dotnet ef migrations add "MigrationV0" --project MediaFilesBox.Infrastructure --startup-project MediaFilesBox.WebApi --output-dir Persistence\Providers\SqlServer\Migrations --context AppSqlServerDbContext -- --environment Staging
```
