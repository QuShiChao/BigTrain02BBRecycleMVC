using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeiBei.Models
{
    //交易记录
    public class DealRecord
    {
        public int Did { get; set; }
        //交易时间
        public DateTime Dtime { get; set; }
        //交易金额
        public decimal Dmoney { get; set; }
        //订单号
        public string Oid { get; set; }
        //回收员
        public int Cid { get; set; }
        //员工号
        public string Cnum { get; set; }
        //用户ID
        public int Uid { get; set; }
        public string Uname { get; set; }

        public string Cname { get; set; }

        public string Oname { get; set; }
    }
}