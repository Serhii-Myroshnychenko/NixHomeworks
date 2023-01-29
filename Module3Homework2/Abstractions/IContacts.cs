namespace Module3Homework2.Abstractions
{
    public interface IContacts<T>
        where T : IRecord
    {
        void AddRecordToContacts(IRecord record);
        Dictionary<string, List<T>> GetAllContacts();
        void PrintAllContacts();
    }
}
