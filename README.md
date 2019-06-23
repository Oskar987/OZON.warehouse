# OZON.Warehouse

Test exercise for OZON

Prerequsitions:
- Windows OS
- Visual Studio 2017-2019
- MS SQL Server 

1. For running this solution you need to modify connection strings in files appsettings.json of projects
 - Warehouse.Persistence
 - Warehouse.API

2. Start cmd, and go to the folder of project Warehouse.Persistence and run this command:
 - dotnet ef database update

3. Open solution in Visual Studio, go to TestExplorer view and click "Run All Tests".

Also, you can run the Test App Warehouse.API in visual studio as is. Swagger installed by URL localhost:5000/swagger
