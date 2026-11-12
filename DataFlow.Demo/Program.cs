using DataFlow.Core;

var temp = new Record<double>(21.5, "Температура");
Console.WriteLine($"Исходная запись: {temp}");
var fahrenheit = RecordMapper.Map(temp, (double c) => c * 9 / 5 + 32, "По Фаренгейту");
Console.WriteLine($"double → double: {fahrenheit}");
var state = RecordMapper.Map(temp, (double c) => c >= 22 ? "тепло" : "прохладно", "Оценка");
Console.WriteLine($"double → string: {state}");

var level = new Record<int>(3, "Уровень");
Console.WriteLine($"Исходная запись: {level}");
Console.WriteLine($"int → int: {RecordMapper.Map(level, (int x) => x * 10, "В процентах")}");
Console.WriteLine($"int → bool: {RecordMapper.Map(level, (int x) => x >= 3, "Тревога")}");
