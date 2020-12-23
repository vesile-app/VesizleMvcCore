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
using VesizleMvcCore.NodejsApi.ApiResults.Results;

namespace VesizleMvcCore.NodejsApi.Api
{
    public class MoviesApi : IMovieService
    {

        private static string ApiPath = "movies/";
        private HttpClient _httpClient;
        public MoviesApi(IHttpClientFactory clientFactory)
        {
            _httpClient = clientFactory.CreateClient(AppConstants.HttpClientKey);
        }
        public async Task<ApiPopularResult> GetPopularAsync()
        {
            var popularUrl = ApiPath + "popular";
            var populaRes = await _httpClient.GetAsync(popularUrl);

            if (populaRes.IsSuccessStatusCode)
            {
                var result = await populaRes.Content.ReadAsStringAsync();
                var jsonDeserialize = JsonHelper.Deserialize<ApiPopularResult>(result);
                return jsonDeserialize;
            }

            return new ApiPopularResult();
        }
        public async Task<ApiDiscoverResult> GetDiscoverAsync()
        {
            var discoverUrl = ApiPath + "discover";
            var discoverRes = await _httpClient.GetAsync(discoverUrl);

            if (discoverRes.IsSuccessStatusCode)
            {
                var result = await discoverRes.Content.ReadAsStringAsync();
                var jsonDeserialize = JsonHelper.Deserialize<ApiDiscoverResult>(result);
                return jsonDeserialize;
            }

            return new ApiDiscoverResult();
        }
        public async Task<IDataResult<ApiMovieDetailsResult>> GetDetailsAsync(int id)
        {
            var url = ApiPath + id.ToString();
            var res = await _httpClient.GetAsync(url);

            if (res.IsSuccessStatusCode)
            {
                var result = await res.Content.ReadAsStringAsync();
                var jsonDeserialize = JsonHelper.Deserialize<ApiMovieDetailsResult>(result);
                return new SuccessDataResult<ApiMovieDetailsResult>(jsonDeserialize);
            }

            return new ErrorDataResult<ApiMovieDetailsResult>();
        }
    }
}