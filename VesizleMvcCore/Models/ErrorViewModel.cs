using System;

namespace VesizleMvcCore.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        public string MessageTitle { get; set; }
        public string MessageBody { get; set; }
    }
}
