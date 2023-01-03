using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
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
            using HttpClient client = new HttpClient();
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            string requestUrl = _baseUrl + endPoint;

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.BaseAddress = new Uri(requestUrl);
            client.Timeout = TimeSpan.FromSeconds(30);

            return await client.GetAsync(requestUrl);
        }
    }
}
