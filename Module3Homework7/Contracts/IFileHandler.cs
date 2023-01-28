namespace Module3Homework7.Contracts
{
    public interface IFileHandler
    {
        Task WriteDataToFileAsync(string path,string[] data);
    }
}
