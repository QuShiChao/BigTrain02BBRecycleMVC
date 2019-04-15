using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeiBei.Models
{
    public class UserInfo
    {
        public int Id { get; set; }
        //用户名
        public string Uname { get; set; }
        //密码
        public string Upwd { get; set; }
        //性别
        public string Usex { get; set; }
        //年龄
        public int Uage { get; set; }
        //电话
        public string Utel { get; set; }
        //头像
        public string Uimage { get; set; }
        //地址
        public string Uaddr { get; set; }
        //交易总金额
        public double Udealmoney { get; set; }
        //银行卡号
        public string Ubankcard { get; set; }
        //支付宝二维码
        public string UalipayCode { get; set; }
        //微信二维码
        public string UwechatCode { get; set; }
    }
}