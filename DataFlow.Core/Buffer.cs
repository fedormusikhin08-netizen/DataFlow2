namespace DataFlow.Core;

public class Buffer<T>
{
    // protected, чтобы наследники могли читать список, но снаружи он был закрыт
    protected readonly List<T> items = new();

    public int Count => items.Count;

    public virtual bool TryAdd(T item)
    {
        items.Add(item);
        return true;
    }
}
