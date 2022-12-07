namespace Module3Homework5.Contracts
{
    public interface IFileProvider
    {
        Task<string> GetHelloFromFileAsync();
        Task<string> GetWorldFromFileAsync();
    }
}
