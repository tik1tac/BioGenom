Сделано максимально просто, без паттернов и подобного
Файл со схемой БД разместил в корне проекта

Использовал 7 сущностей:
1)Products - специализированный набор по итогам контроля питания
2)User - пользователь (по условию больше вспомогательный)
3)Meal - Еда. Для расширения, если понадобится еще функционал
4)Elements - витамины и вещества
5)NewDailyIntake - для 2 раздела, новое суточное потребление с учетом персонализированного набора
6)RecommendedDietary - рекомендованное питание для пользователя
7)MealElements - таблица для отношения многие ко многим (Meal<->Elements), а также для хранения значения текущего содержания веществ и витаминов.

Возможно где-то можно было и оптимизировать базу данных
Создана 1 API с 2 методами - 1. отдает текущее суточное потребление 2. новое суточное потребление с учетом персонализированного набора
