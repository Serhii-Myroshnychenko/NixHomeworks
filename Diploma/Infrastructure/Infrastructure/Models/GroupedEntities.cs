namespace Infrastructure.Models
{
    public class GroupedEntities<T>
    {
        public IEnumerable<T> Data { get; init; } = null!;
    }
}
