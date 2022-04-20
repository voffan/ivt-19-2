# ИВТ-19-2
## AAproject - система учёта достижений спортсменов. Описание проекта:
Программное обеспечение для автоматизации учёта достижений спортсменов. Система позволяет судьям соревнований вводить результаты, вводить новых спортсменов, добавлять достижения, а сотрудникам проводить анализ и распечатывать отчёты спортсменов с наибольшим количеством призовых мест по своему виду спорта, победителей соревнования по заданному виду спорта за выбранный период
------
[miro mind map](https://miro.com/app/board/o9J_ly_HA3E=/)
------

### Требуемое ПО, инструменты, расширения для разработки:
- [Git](https://git-scm.com/)
- [Visual Studio 2022](https://visualstudio.microsoft.com/ru/vs/)
- [Figma](https://www.figma.com/file/hjKjceJW8k7CIGEPYxc1no/Common-Interface?node-id=70%3A9)
- [.NET 6](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)
- [MySQL Workbench](https://www.mysql.com/products/workbench/)
- [DB Browser for SQLite](https://sqlitebrowser.org/dl/)
- NuGet пакеты Microsoft.EntityFrameworkCore.Sqlite & Microsoft.EntityFrameworkCore.Tools & Pomelo.EntityFrameworkCore.MySql

### Требуемое ПО для запуска проекта:
- [Git](https://git-scm.com/)
- [Visual Studio 2022](https://visualstudio.microsoft.com/ru/vs/)
- [.NET 6](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)

### Инструкция по запуску:
- Открыть Git Bash в произвольной папке и ввести след. команды `git clone https://github.com/voffan/ivt-19-2.git`
- `cd ivt-19-2`
- `git checkout AAproject`
- В загруженном проекте открыть папку `AchieveNow`
- Запустить файл `AchieveNow.sln` через Visual Studio 2022
- Нажать `Start Debugging` или нажать клавишу `F5`
- Подождать, пока откроется программа (Visual Studio будет загружать необходимые пакеты)
- Закрыть запущенную программу
- Из папки `Resources` скопировать файл `AchieveNowDB.db`
- Из корневой директории перейти по папкам `bin`->`Debug`->`net6.0-windows`
- Заменить там скопированный файл
- Перейти обратно в проект Visual Studio и нажать `F5`

## RoadMap:
### MVP
- Главное окно приложения со страницами соревнований, достижений, спортсменов, локаций, видов спорта и стран ✅
- Соединение с базой данных (локально или удалённо) ✅
- Возможность добавления записи соревнований, достижений, спортсменов, локаций, видов спорта и стран ✅
- Возможность поиска записи соревнований, достижений, спортсменов, локаций, видов спорта и стран ✅
- Возможность удаления записи соревнований, достижений(❌), спортсменов, локаций(❌), видов спорта и стран ✅
- Возможность редактирования записи соревнований, достижений(❌), спортсменов, локаций(❌), видов спорта и стран ✅

### Авторизация
- Окно авторизации ❌
- Возможность регистрации сотрудников для администратора ❌
- Назначение соответствующих прав для сотрудников и судей ❌

### Права и логика для сотрудников и судей
- Окно для судей с редактированием достижений и спортсменов ❌
- Окно для администратора с регистрацией сотрудников и судей ❌

### Отчёты
- Возможность вывода отчёта спортсменов с наибольшим количеством призовых мест по своему виду спорта ❌
- Возможность вывода отчёта победителей соревнования по заданному виду спорта за выбранный период ❌
