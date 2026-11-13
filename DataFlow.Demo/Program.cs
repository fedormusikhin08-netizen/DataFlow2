using DataFlow.Core;

var numbers = new List<int> { 5, 9, 2 };
Console.WriteLine($"FindMax на List<int> = {numbers.FindMax()}");
Console.WriteLine($"FindMax на пустом List<string> = {(new List<string>().FindMax() is null ? "null" : "ошибка")}");
Console.WriteLine($"FindMax на пустом List<int> = {new List<int>().FindMax()}");
numbers.PrintAll("Элемент: ");
new List<string>().PrintAll("Элемент: ");
