using System;
using System.Collections.Generic;
using System.Text;

namespace VesizleMvcCore.NodejsApi.ApiResults.Results
{
    public interface IDataResult<T> : IResult
    {
        T Data { get; }
    }
}
