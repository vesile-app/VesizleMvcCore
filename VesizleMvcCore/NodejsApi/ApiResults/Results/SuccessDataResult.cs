using System;
using System.Collections.Generic;
using System.Text;

namespace VesizleMvcCore.NodejsApi.ApiResults.Results
{
    public class SuccessDataResult<T> : DataResultBase<T> where T : class
    {
        public SuccessDataResult(string message, T data) : base(message, true, data) { }
        public SuccessDataResult(T data) : base(true, data) { }
        public SuccessDataResult() : base(null, true, null) { }
    }
}
