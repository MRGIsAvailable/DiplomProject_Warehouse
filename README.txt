Перед запуском приложения необходимо создать базу данных.
Сделать это можно двумя способами:
1.Запустить Warehouse.sln;
На верхней панели найти "Средства" - "Диспетчер пакетов NuGet" - "Консоль диспетчера пакетов";
Откроется консоль в которой необходимо прописать "update-database";
Все тестовые данные хранятся в папке "Data" - "ApplicationDbContext";
Путь подключения находится в файле appsettings.json:
    "DefaultSQLConnection": "Server=.;Database=WarehouseAPI;TrustServerCertificate=True;Trusted_Connection=True;MultipleActiveResultSets=true";

2.Запустить скрипт "SqriptDB";
В скрипте сохранены тестовые данные.
Необходимо будет поменять путь в строчках с FILENAME.


После этого можно запустить приложение. В начальных проектах необходимо выбрать "ConstructionWarehouse_Web". Тогда появится страница с авторизацией.
Данные для авторизации:

Логин: vik@ya.ru
Пароль: 123

Логин: szh@gmail.com
Пароль: 321

Логин: min@ya.ru
Пароль: 231
