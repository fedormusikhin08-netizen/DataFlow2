using DataFlow.Core;
using DataFlow.Demo;

var readings = new List<Reading>
{
    new() { Id = 1, Value = 21.5, TakenAt = new DateTime(2026, 11, 13, 8, 0, 0) },
    new() { Id = 2, Value = 24.8, TakenAt = new DateTime(2026, 11, 13, 12, 0, 0) },
    new() { Id = 3, Value = 19.2, TakenAt = new DateTime(2026, 11, 13, 9, 0, 0) }
};

Console.WriteLine($"FindMax на List<Reading> = {readings.FindMax()!.Value}");
readings.PrintAll("Показание: ");
