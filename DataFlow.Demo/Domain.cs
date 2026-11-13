using DataFlow.Core;

namespace DataFlow.Demo;

public sealed class Sensor : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Unit { get; set; } = "";

    public override string ToString() => $"{Name} ({Unit})";
}

public sealed class Reading : IEntity, IComparable<Reading>
{
    public int Id { get; set; }
    public double Value { get; set; }
    public DateTime TakenAt { get; set; }

    public int CompareTo(Reading? other)
    {
        if (other is null)
        {
            return 1;
        }

        return Value.CompareTo(other.Value);
    }

    public override string ToString() => $"{Value:0.0} в {TakenAt:HH:mm}";
}

public abstract class Animal
{
    public string Name { get; set; } = "";
    public override string ToString() => $"{GetType().Name} по имени {Name}";
}

public sealed class Dog : Animal
{
}
