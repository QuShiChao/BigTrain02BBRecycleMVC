using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeiBei.Models
{
    public class Recycles
    {
        public int Rid { get; set; }
        //回收物品名称
        public string Rname { get; set; }
        //回收类型
        public int Cid { get; set; }
        public string Cname { get; set; }
        //物品描述
        public string Rdescribe { get; set; }
        //物品库存
        public int Rinventory { get; set; }
    }
}