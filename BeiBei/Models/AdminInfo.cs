using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeiBei.Models
{
    public class AdminInfo
    {
        public int Id { get; set; }
        //用户名
        public string Aname { get; set; }
        //密码
        public string Apwd { get; set; }
        //头像
        public string Aimage { get; set; }
    }
}