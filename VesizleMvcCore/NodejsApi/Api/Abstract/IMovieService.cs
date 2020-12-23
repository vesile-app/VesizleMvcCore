using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VesizleMvcCore.NodejsApi.ApiResults;
using VesizleMvcCore.NodejsApi.ApiResults.Results;

namespace VesizleMvcCore.NodejsApi.Api.Abstract
{
    public interface IMovieService
    {
        Task<ApiPopularResult> GetPopularAsync();
        Task<IDataResult<ApiMovieDetailsResult>> GetDetailsAsync(int id);
        Task<ApiDiscoverResult> GetDiscoverAsync();

    }
}
