using System;
using System.Net.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;

namespace SpeakOps.Api.AcceptanceTests.Helpers
{
    public sealed class ApiClientSingleton
    {
        private static readonly Lazy<ApiClientSingleton> Lazy =
            new Lazy<ApiClientSingleton>(() => new ApiClientSingleton());

        private static ApiClientSingleton Instance => Lazy.Value;

        private readonly HttpClient _client;
        public static HttpClient Client => Instance._client;

        private ApiClientSingleton()
        {
            var server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>());
            _client = server.CreateClient();
        }
    }
}