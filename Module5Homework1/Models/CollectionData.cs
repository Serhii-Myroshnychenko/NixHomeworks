namespace Module5Homework1.Models;

public class CollectionData<T> : Validation
{
    public IReadOnlyCollection<T>? Data { get; init; }
}