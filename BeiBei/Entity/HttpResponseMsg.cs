using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BeiBei.Models;

namespace BeiBei.Entity
{
    public class HttpResponseMsg
    {
        public int StatusCode { get; set; }
        public object Data { get; set; }
        public string Info { get; set; }
    }

    public class ProductResultMsg<T> : HttpResponseMsg
    {
        public List<T> Result
        {
            get
            {
                if (StatusCode == 200)
                {
                    return JsonConvert.DeserializeObject<List<T>>(Data.ToString());
                }
                return null;
            }
        }
    }
    public class TokenResultMsg : HttpResponseMsg
    {
        public Token Result
        {
            get
            {
                if (StatusCode == 200)
                {
                    return JsonConvert.DeserializeObject<Token>(Data.ToString());
                }
                return null;
            }
        }
    }
}