using System;
using System.Collections.Generic;
using System.Text;

namespace VesizleMvcCore.NodejsApi.ApiResults.Results
{
    public interface IResult
    {
        bool IsSuccessful { get; }
        string Message { get; }
    }
}
