namespace Order.Host.Models.Response;

public class GroupedEntitiesResponse<T>
{
    public IEnumerable<T> Data { get; init; } = null!;
}
