using DataFlow.Core;

var labels = new LabeledBuffer();
labels.TryAdd("датчик температуры");
labels.TryAdd("датчик влажности");
labels.TryAdd("датчик давления");
labels.PrintAllUpper();
Console.WriteLine($"LabeledBuffer.Count = {labels.Count}");
