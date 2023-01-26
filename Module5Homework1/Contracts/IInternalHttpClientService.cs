namespace Module5Homework1.Contracts
{
    public interface IInternalHttpClientService
    {
        Task<TResponse> SendAsync<TResponse>(string url, HttpMethod method, object? content = null);
        Task SendAsync(string url, HttpMethod method, object? content = null);
    }
}
