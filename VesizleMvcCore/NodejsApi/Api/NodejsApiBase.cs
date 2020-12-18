using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;

namespace VesizleMvcCore.NodejsApi.Api
{
    public abstract class NodejsApiBase
    {
        public HttpClient HttpClient { get; }
        public static string BaseApiUrl = "http://localhost:3000/";
        private IHttpClientFactory _clientFactory;
        public NodejsApiBase(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
            HttpClient = _clientFactory.CreateClient();
            HttpClient.BaseAddress = new Uri(BaseApiUrl);
            HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

    }
}