using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace UserManager.WPF.Services
{
    /// <summary>
    /// Service for interacting with a REST WebAPI.
    /// </summary>
    public class WebApi
    {
        private readonly string _baseUrl;

        public WebApi(string baseUrl)
        {
            _baseUrl = baseUrl;
        }


        public async Task<HttpResponseMessage> GetAsync(string endPoint)
        {
            string requestUrl = _baseUrl + endPoint;
            using var client = SetupRequest(requestUrl);

            return await client.GetAsync(requestUrl);
        }


        public async Task<HttpResponseMessage> PutAsync<TPayload>(string endPoint, TPayload payload)
        {
            string requestUrl = _baseUrl + endPoint;
            using var client = SetupRequest(requestUrl);

            return await client.PutAsync(requestUrl, JsonContent.Create(payload));
        }


        private static HttpClient SetupRequest(string requestUrl)
        {
            HttpClient client = new HttpClient();
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.BaseAddress = new Uri(requestUrl);
            client.Timeout = TimeSpan.FromSeconds(30);

            return client;
        }
    }
}
