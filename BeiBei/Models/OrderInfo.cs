using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace BeiBei.Models
{
    //订单
    public class OrderInfo
    {
        //订单号201904140001
        public string Oid { get; set; }
        //物品名称
        public string Oname { get; set; }
        //类型ID
        public int Cid { get; set; }
        public string Cname { get; set; }
        //物品单位描述
        public string Onum { get; set; }
        //用户ID
        public int Uid { get; set; }
        public string Uname { get; set; }
        //回收员ID 
        public int Collector_Id { get; set; }
        public string Collector_Name { get; set; }
        //收钱方式
        public int Owithdraw { get; set; }
        //收钱金额
        public decimal Omoney { get; set; }
        //订单描述
        public string Odesription { get; set; }
        //订单时间
        public DateTime Otime { get; set; }
        //状态  0 待审核 1 审核中 2 待结账 3已结账
        public int Ostatus { get; set; }
    }
}