using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RESTful.API.Models
{
    public enum Ops
    {
        replace = 1,
        delete = 2,
    }

    public class PartialUpdate
    {
        public string MyProperty { get; set; }
    }
}