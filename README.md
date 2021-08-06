# Unity Developer тестовое задание

## Краткое описание проекта

Демо-проект выполненный по всем требованиям тестового задания от AmayaSoft. Ниже перечислены некоторые механики воплощенные в проекте

### Grid

Динамическая таблица GameObject-ов разбитая на три компонента
- GridHandler - отвечает за сетку CellSegment-ов;
- GridData - отвечает за заполнение CellSegment-ов данными из CellData;
- GridCreator - создаёт сетку CellSegment-ов на основе уровня из LevelData.

### DataSets

Наборы данных в основе которых лежат два поля:
- Identifier;
- Sprite.
На основе этого набора данных дизайнер может создать любой набор без участия программиста.

### Levels

Динамическая система создания уровней, благодаря ей, дизайнер может создать свой набор данных об уровне, настроив в нём сложность уровня и набор данных.
