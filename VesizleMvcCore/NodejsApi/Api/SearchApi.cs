using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using VesizleMvcCore.Constants;
using VesizleMvcCore.Helpers;
using VesizleMvcCore.NodejsApi.Api;
using VesizleMvcCore.NodejsApi.Api.Abstract;
using VesizleMvcCore.NodejsApi.ApiResults;

namespace VesizleMvcCore.NodejsApi.Api
{
    public class SearchApi :  ISearchService
    {

        private static string ApiUrl = "search/";
        private HttpClient _httpClient;
        public SearchApi(IHttpClientFactory clientFactory)
        {
            _httpClient = clientFactory.CreateClient(AppConstants.HttpClientKey);
        }
        public async Task<ApiSearchResult> SearchAsync(string query, int page = 1)
        {
            var url = ApiUrl + $"movie?query={query}&page={page}";
            var res = await _httpClient.GetAsync(url);
            if (res.IsSuccessStatusCode)
            {
                var result = await res.Content.ReadAsStringAsync();
                var jsonDeserialize = JsonHelper.Deserialize<ApiSearchResult>(result);
                return jsonDeserialize;
            }

            return new ApiSearchResult();
        }

    }
}