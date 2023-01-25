namespace Module4Homework1.Models;

public class CollectionData<T> : Validation
{
    public IReadOnlyCollection<T>? Data { get; init; }
}