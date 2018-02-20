using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SpeakOps.Api.AcceptanceTests.Helpers
{
    //https://docs.microsoft.com/en-us/dotnet/standard/threading/managed-threading-best-practices
    public class ApiFixture : IDisposable
    {
        private readonly string _url;
        private volatile Lazy<Task<HttpResponseMessage>> _httpResponseMessage;
        private readonly object _lock = new object();

        public ApiFixture(string url)
        {
            _url = url;
        }

        private Task<HttpResponseMessage> GetResponseOrPerformHttpRequest()
        {
            if (_httpResponseMessage != null) return _httpResponseMessage.Value;

            lock (_lock)
            {
                if (_httpResponseMessage == null)
                {
                    _httpResponseMessage = new Lazy<Task<HttpResponseMessage>>(() => ApiClientSingleton.Client.GetAsync(_url), true);
                }
            }
            return _httpResponseMessage.Value;
        }

        public Task<HttpResponseMessage> Response => GetAsync();

        protected async Task<HttpResponseMessage> GetAsync()
        {
            return await GetResponseOrPerformHttpRequest();
        }

        public async Task<T> Content<T>()
        {
            var response = await GetResponseOrPerformHttpRequest();
            return await response.Content.ReadAsAsync<T>();
        }

        public virtual void Dispose()
        {
        }
    }
}