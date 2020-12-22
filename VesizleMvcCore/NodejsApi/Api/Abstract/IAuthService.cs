using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VesizleMvcCore.NodejsApi.ApiResults.Results;
using VesizleMvcCore.NodejsApi.Dtos;

namespace VesizleMvcCore.NodejsApi.Api.Abstract
{
    public interface IAuthService
    {
        Task<IResult> LoginAsync(UserForLoginDto loginDto);
    }
}
