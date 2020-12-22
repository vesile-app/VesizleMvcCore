using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using VesizleMvcCore.Constants;
using VesizleMvcCore.Helpers;
using VesizleMvcCore.NodejsApi.Api.Abstract;
using VesizleMvcCore.NodejsApi.ApiResults.Results;
using VesizleMvcCore.NodejsApi.Dtos;

namespace VesizleMvcCore.NodejsApi.Api
{
    public class AuthApi : IAuthService
    {
        private static string ApiUrl = "auth/";
        private HttpClient _httpClient;
        public AuthApi(IHttpClientFactory clientFactory)
        {
            _httpClient = clientFactory.CreateClient(AppConstants.HttpClientKey);
        }
        public async Task<IResult> LoginAsync(UserForLoginDto loginDto)
        {
            var url = ApiUrl + "login";
            var loginDtoJson = new StringContent(
                JsonHelper.Serialize<UserForLoginDto>(loginDto),
                Encoding.UTF8,
                "application/json");
            var responseMessage = await _httpClient.PostAsync(url, loginDtoJson);
            if (responseMessage.IsSuccessStatusCode)
            {
                return new SuccessResult();
            }

            var res = await responseMessage.Content.ReadAsStringAsync();
            return new ErrorResult(res);
        }
    }
}
