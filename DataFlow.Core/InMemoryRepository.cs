namespace DataFlow.Core;

public class InMemoryRepository<T> : IRepository<T> where T : IEntity
{
    private readonly List<T> items = new();

    public int Count => items.Count;

    public void Add(T item) => items.Add(item);

    public T? GetById(int id)
    {
        foreach (var entity in items)
        {
            if (entity.Id == id)
            {
                return entity;
            }
        }

        return default;
    }
}
