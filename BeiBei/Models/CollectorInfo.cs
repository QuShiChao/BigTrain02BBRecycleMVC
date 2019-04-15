using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeiBei.Models
{
    public class CollectorInfo
    {
        public int Id { get; set; }
        //员工编号 201901140001
        public string CID { get; set; }
        //员工名称
        public string Cname { get; set; }
        //密码
        public string Cpwd { get; set; }
        //工作位置
        public string Clocation { get; set; }
        //头像
        public string Cimage { get; set; }
    }
}