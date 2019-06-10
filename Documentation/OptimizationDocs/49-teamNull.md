# Итерационный алгоритм для задачи распространения констант.

## Постановка задачи
Создать класс, реализующий итерационный алгоритм для задачи распостронения
констант

## Команда — исполнитель
Null

## Зависимости
Зависит от:
- Обобщенный итерационный алгоритм
- Передаточная функция для задачи распостронения констант
- Генерация множеств gen и kill
- Разбиение на базовые блоки

## Теория

Введем полурешетку вида:

![](../images/48-teamNull-1.png)

Каждая переменная в некоторой таблице имеет одно из значений в
полурешетке - UNDEF (undefigned), const , NAC (not a const). Таблица
является декартовым произведением полурешеток, и следовательно,
сама полурешетка.

![](../images/48-teamNull-2.png)

Таким образом, элементом данных будет отображение m на
соответствующее значение полурешетки.

![](../images/48-teamNull-3.png)

Функция монотонна, потому итерационный процесс решает
поставленную задачу.

## Реализация

```
public class ConstDistributionITA: IterationAlgorithm<SemilatticeStreamValue>
{

public ConstDistributionITA(ControlFlowGraph cfg)
	:base(cfg, new ConstDistribFunction(), new ConstDistribOperator())
{
	InitilizationSet = new HashSet<SemilatticeStreamValue>();
	Execute();
}

}
```

## Тесты

INPUT:
```
a = 4;
b = 4;
c = a + b;
if 1
	a = 3;
else
	b = 2;
```
OUTPUT:
```
["a"] == "4"
["b"] == "4"
["t0"] == "8" 
["c"] == "8"

["a"] == "3" 
["b"] == "4" 
["t0"] == "8" 
["c"] == "8"

["a"] == "4" 
["b"] == "2" 
["t0"] == "8" 
["c"] == "8"

["a"] == "NAC"
["b"] == "NAC" 
["t0"] == "8" 
["c"] == "8"
```

## Вывод
Используя метод, описанные выше, мы смогли реализовать итерационный алгоритм для задачи распостронения
констант