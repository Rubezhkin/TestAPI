Веб-сервис, который получает от пользователя адрес, 
запросом к сервису DaData (https://dadata.ru/api/clean/address/) выполняет его стандартизацию, 
затем возвращает полученный ответ пользователю в виде модели с определенным набором полей

Сервис обладает 1 get запросом, принимающая стоку, возращая полный адрес, страну, индекс, округ и регион
пример запроса можно увидеть в swagger

Для разработки использовался ASP.NET Core WebApi, Automapper, через IOptions передается токены, есть логирование через serilog,
введена cors политика