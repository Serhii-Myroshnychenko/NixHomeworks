namespace Catalog.Host.Data;

public class GroupedEntities<T>
{
    public IEnumerable<T> Data { get; init; } = null!;
}
