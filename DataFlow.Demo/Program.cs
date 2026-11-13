using DataFlow.Core;
using DataFlow.Demo;

Console.OutputEncoding = System.Text.Encoding.UTF8;

Console.WriteLine("=== Блок A: иерархии обобщённых классов ===");

var labels = new LabeledBuffer();
labels.TryAdd("датчик температуры");
labels.TryAdd("датчик влажности");
labels.TryAdd("датчик давления");
labels.PrintAllUpper();
Console.WriteLine($"LabeledBuffer.Count = {labels.Count}");
Console.WriteLine();

Console.WriteLine("--- GuardedBuffer<Reading>: только неотрицательные показания ---");
var readings = new GuardedBuffer<Reading>(r => r.Value >= 0);
var morning = new Reading { Id = 1, Value = 21.5, TakenAt = new DateTime(2026, 11, 13, 8, 0, 0) };
var broken = new Reading { Id = 2, Value = -3.0, TakenAt = new DateTime(2026, 11, 13, 8, 5, 0) };
var noon = new Reading { Id = 3, Value = 24.8, TakenAt = new DateTime(2026, 11, 13, 12, 0, 0) };
Console.WriteLine($"TryAdd(21.5) = {readings.TryAdd(morning)}");
Console.WriteLine($"TryAdd(-3.0) = {readings.TryAdd(broken)}");
Console.WriteLine($"Count = {readings.Count}, AcceptedCount = {readings.AcceptedCount} — после отказа");
Console.WriteLine($"TryAdd(24.8) = {readings.TryAdd(noon)}");
Console.WriteLine($"Count = {readings.Count}, AcceptedCount = {readings.AcceptedCount}");
Console.WriteLine();

Console.WriteLine("--- GuardedBuffer<Sensor>: только с единицей измерения ---");
var sensors = new GuardedBuffer<Sensor>(s => !string.IsNullOrWhiteSpace(s.Unit));
Console.WriteLine($"TryAdd(T1) = {sensors.TryAdd(new Sensor { Id = 1, Name = "T1", Unit = "°C" })}");
Console.WriteLine($"TryAdd(T2) = {sensors.TryAdd(new Sensor { Id = 2, Name = "T2", Unit = " " })}");
Console.WriteLine($"Count = {sensors.Count}, AcceptedCount = {sensors.AcceptedCount}");
Console.WriteLine($"Счётчики независимы: readings.AcceptedCount = {readings.AcceptedCount}, sensors.AcceptedCount = {sensors.AcceptedCount}");
Console.WriteLine();

Console.WriteLine("=== Блок B: обобщённая структура, делегат и метод ===");

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
Console.WriteLine();

Console.WriteLine("=== Блок C: обобщённые интерфейсы ===");

var sensorsRepo = new InMemoryRepository<Sensor>();
var t1 = new Sensor { Id = 1, Name = "T1", Unit = "°C" };
var h1 = new Sensor { Id = 2, Name = "H1", Unit = "%" };
sensorsRepo.Add(t1);
sensorsRepo.Add(h1);
Console.WriteLine($"GetById(2) = {sensorsRepo.GetById(2)!.Name}");
Console.WriteLine($"GetById(99) = {(sensorsRepo.GetById(99) is null ? "null" : "ошибка")}");

var readingsRepo = new InMemoryRepository<Reading>();
readingsRepo.Add(morning);
Console.WriteLine($"GetById(1) у показаний = {readingsRepo.GetById(1)!.Value}");
Console.WriteLine($"Счётчики независимы: sensorsRepo.Count = {sensorsRepo.Count}, readingsRepo.Count = {readingsRepo.Count}");

var container = new Container<Dog>(new Dog { Name = "Рекс" });
IContainer<Animal> animal = container;
Console.WriteLine($"IContainer<Animal>.GetItem() = {animal.GetItem()}");
Console.WriteLine();

Console.WriteLine("=== Блок D: методы расширения ===");

var numbers = new List<int> { 5, 9, 2 };
Console.WriteLine($"FindMax на List<int> = {numbers.FindMax()}");
Console.WriteLine($"FindMax на пустом List<string> = {(new List<string>().FindMax() is null ? "null" : "ошибка")}");
Console.WriteLine($"FindMax на пустом List<int> = {new List<int>().FindMax()}");

var archive = new List<Reading>
{
    morning,
    noon,
    new Reading { Id = 4, Value = 19.2, TakenAt = new DateTime(2026, 11, 13, 9, 0, 0) }
};
Console.WriteLine($"FindMax на List<Reading> = {archive.FindMax()!.Value}");
numbers.PrintAll("Элемент: ");
archive.PrintAll("Показание: ");
new List<string>().PrintAll("Элемент: ");
Console.WriteLine("(пустой список ничего не напечатал)");
