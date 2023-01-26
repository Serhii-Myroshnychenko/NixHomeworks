using Module5Homework1.Contracts;
using Module5Homework1.Dtos.Responses;
using Module5Homework1.Exceptions;
using Module5Homework1.Utils;
using Newtonsoft.Json;
using System.Text;

namespace Module5Homework1.Services
{
    public class InternalHttpClientService : IInternalHttpClientService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public InternalHttpClientService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task SendAsync(string url, HttpMethod method, object? content = null)
        {
            var httpMessage = new HttpRequestMessage
            {
                RequestUri = new Uri(url),
                Method = method
            };
            if (content != null)
            {
                httpMessage.Content = new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, ContentTypes.JSON);
            }

            HttpResponseMessage result;

            try
            {
                var httpClient = _httpClientFactory.CreateClient();
                result = await httpClient.SendAsync(httpMessage);
            }
            catch (Exception ex)
            {
                throw new BusinessException(ex.Message);
            }

            throw new BusinessException(null!, result.StatusCode.ToString());
        }

        public async Task<TResponse> SendAsync<TResponse>(string url, HttpMethod method, object? content = null)
        {
            var httpMessage = new HttpRequestMessage
            {
                RequestUri = new Uri(url),
                Method = method
            };
            if (content != null)
            {
                httpMessage.Content = new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, ContentTypes.JSON);
            }

            HttpResponseMessage result;

            try
            {
                var httpClient = _httpClientFactory.CreateClient();
                result = await httpClient.SendAsync(httpMessage);
            }
            catch (Exception ex)
            {
                throw new BusinessException(ex.Message);
            }

            var resultContent = await result.Content.ReadAsStringAsync();

            if (result.IsSuccessStatusCode)
            {
                var response = JsonConvert.DeserializeObject<TResponse>(resultContent);

                if (response is ErrorTextDto error && !string.IsNullOrEmpty(error.ErrorBody))
                {
                    throw new BusinessException(error.ErrorBody, ErrorCodes.Validation);
                }

                return response!;
            }

            throw new BusinessException(resultContent, result.StatusCode.ToString());
        }
    }
}
