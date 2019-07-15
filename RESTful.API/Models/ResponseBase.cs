using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RESTful.API.Models
{
    public enum Status
    {
        Success = 100,
        Error = 121,
        Warning = 131,
    }

    public class ResponseBase
    {
        public Status Code { get; set; }
        public string ErrorMessage { get; set; }
    }
}