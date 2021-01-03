using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VesizleMvcCore.NodejsApi.ApiResults;

namespace VesizleMvcCore.NodejsApi.Api.Abstract
{
    public interface ISearchService
    {
        Task<ApiSearchResult> SearchAsync(string query, int page );
    }
}
