# MediaFilesBox

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