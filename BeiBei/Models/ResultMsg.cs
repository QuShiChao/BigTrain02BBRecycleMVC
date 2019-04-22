using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeiBei.Models
{
    public class ResultMsg
    {
        public int StatusCode { get; set; }
        public string Info { get; set; }
        public object Data { get; set; }
    }
}