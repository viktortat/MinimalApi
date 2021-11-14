```sh
# Запуск docker
docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=Aa!123456' \
  -p 1435:1433 --name sql1 \
  -h sql1 \
  -d mcr.microsoft.com/mssql/server:2019-latest
  
docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=Aa!123456' -p 1435:1433 --name sql1 -d mcr.microsoft.com/mssql/server:2019-latest

```

---

```sh
dotnet ef
dotnet ef migrations add M3
dotnet ef migrations remove
# формирование миграционного bundle
dotnet ef migrations bundle -f
```
