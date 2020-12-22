using System;
using System.Collections.Generic;
using System.Text;

namespace VesizleMvcCore.NodejsApi.ApiResults.Results
{
    public class SuccessResult : ResultBase
    {
        public SuccessResult(string message) : base(true, message) { }
        public SuccessResult() : base(true) { }
    }
}
