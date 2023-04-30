# OrderService

Сервис заказов предназначен для управления заказами в компании. Пользователи могут создавать заказы, редактировать их и удалять. 

## Требования

Перед началом использования сервиса заказов необходимо убедиться, что на компьютере установлены следующие программные компоненты:
*	Операционная система Windows 7 или выше
*	Среда выполнения .NET Framework 4.7.2
* 	СУБД PostgreSQL
## Установка и запуск

1.	Клонируйте репозиторий на свой компьютер:
https://github.com/nikysn/OrderService.git
2.	Откройте OrderService.API.sln в Visual Studio или другой среде разработки.
3. 	Настройте подключение к базе данных, изменив строку подключения в файле appsettings.json:
```
"ConnectionString": "Server=localhost;Port=5432;Database=OrderService;User Id=myusername;Password=mypassword;" 
```
4.	Создайте базу данных, выполнив следующие шаги:
 	1. Перейдите в директорию ```OrderService.DAL```
 	2. Выполните команду для создания миграции :
    ```
    dotnet ef -s ..\OrderService.API\ migrations add "название миграции" --project .\OrderService.DAL.csproj 
    ```
    3. Выполните команду для создания базы данных :
    ```
    dotnet ef -s ..\OrderService.API\ database update
    ```
5.	Запустите проект OrderService.API для запуска веб-сервиса



