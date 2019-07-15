using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RESTful.API.Models
{
    public class Response<T> : ResponseBase
    {
        public T Body { get; set; }
    }
}