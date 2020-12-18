using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using VesizleMvcCore.Constants;
using VesizleMvcCore.Helpers;
using VesizleMvcCore.NodejsApi.Api.Abstract;
using VesizleMvcCore.NodejsApi.ApiResults;

namespace VesizleMvcCore.NodejsApi.Api
{
    public class MoviesApi :  IMovieService
    {

        private static string ApiPath = "movies/";
        private HttpClient _httpClient;
        public MoviesApi(IHttpClientFactory clientFactory)
        {
            _httpClient = clientFactory.CreateClient(AppConstants.HttpClientKey);
        }
        public async Task<ApiPopularResult> GetPopularAsync()
        {
            var url = ApiPath + "popular";
            var res = await _httpClient.GetAsync(url);
            
            if (res.IsSuccessStatusCode)
            {
                var result = await res.Content.ReadAsStringAsync();
                var jsonDeserialize = JsonHelper.Deserialize<ApiPopularResult>(result);
                return jsonDeserialize;
            }

            return new ApiPopularResult();
        }

       
    }
}