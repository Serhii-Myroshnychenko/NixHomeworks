namespace MVC.Models.Responses
{
    public class GroupedEntitiesResponse<T>
    {
        public IEnumerable<T> Data { get; init; } = null!;
    }
}
