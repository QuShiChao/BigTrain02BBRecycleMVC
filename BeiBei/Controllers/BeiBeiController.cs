using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BeiBei.Models;
using Newtonsoft.Json;

namespace BeiBei.Controllers
{
    public class BeiBeiController : Controller
    {
        //添加订单
        [HttpPost]
        public int AddOrder(OrderInfo order)
        {
            return 0;
        }
        public ActionResult ShowIndex()
        {
            return View();
        }
        // GET: BeiBei
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public void Login(string Name,string Pwd)
        {
            List<AdminInfo> adminList = CommonList<AdminInfo>.GetList();
            if (Pwd.Length<2 && Pwd.Length>16)
            {
                Response.Write("<script>alert('密码格式错误');</script>");
            }
            else
            {
                
                adminList = adminList.Where(s => s.Aname.Equals(Name) && s.Apwd.Equals(Pwd)).ToList();
                if (adminList.Count > 0)
                {
                    Response.Write("<script>alert('登录成功！');location.href='/BeiBei/Index'</script>");
                }
                else
                {
                    Response.Write("<script>alert('账号密码输入错误！');</script>");
                }
            }
        }
        //主界面
        public ActionResult Index()
        {
            return View();
        }
        //显示用户
        public ActionResult ShowUser()
        {
            return View();
        }
        //显示回收员
        public ActionResult ShowCollector()
        {
            List<UserInfo> usersList = CommonList<UserInfo>.GetList();
            List<CollectorInfo> list = CommonList<CollectorInfo>.GetList();
            ViewBag.user = usersList;
            return View(list);
        }
        //显示物品信息
        public ActionResult ShowRecycles()
        {
            List<Recycles> recyclesList = CommonList<Recycles>.GetList();
            List<Category> categoryList = JsonConvert.DeserializeObject<List<Category>>(HttpClientHelper.SendRequest("api/BBRecyleAPI/GetCategory", "get"));
            var result= from r in recyclesList
                        join c in categoryList on r.Cid equals c.Cid
                        select new
                        {
                            r.Rid,
                            r.Rname,
                            c.Cname,
                            r.Rdescribe,
                            r.Rinventory
                        };
            string str = JsonConvert.SerializeObject(result);
            List<Recycles> Recycleslist = JsonConvert.DeserializeObject<List<Recycles>>(str);
            return View(Recycleslist);
        }
        //添加回收员
        public ActionResult AddCollector()
        {
            return View();
        }
        //订单操作
        #region   订单操作
        //订单操作
        public ActionResult Ordering()
        {
            List<OrderInfo> list = NewMethod();
            return View(list);
        }
        public List<OrderInfo> NewMethod()
        {
            List<OrderInfo> olist = CommonList<OrderInfo>.GetList().Where(o => o.Ostatus >= 3).ToList();
            List<Category> catelist = JsonConvert.DeserializeObject<List<Category>>(HttpClientHelper.SendRequest("api/BBRecyleAPI/GetCategory", "get"));
            List<UserInfo> ulist = CommonList<UserInfo>.GetList();
            List<CollectorInfo> colllist = CommonList<CollectorInfo>.GetList();
            var result = from o in olist
                         join c in catelist on o.Cid equals c.Cid
                         join u in ulist on o.Uid equals u.Id
                         join co in colllist on o.Collector_Id equals co.Id
                         select new
                         {
                             o.Oid,
                             o.Oname,
                             c.Cid,
                             c.Cname,
                             o.Onum,
                             o.Uid,
                             u.Uname,
                             Collector_Id = co.Id,
                             Collector_Name = co.Cname,
                             o.Owithdraw,
                             o.Omoney,
                             o.Otime,
                             o.Ostatus
                         };
            string str = JsonConvert.SerializeObject(result);
            List<OrderInfo> list = JsonConvert.DeserializeObject<List<OrderInfo>>(str);
            return list;
        }
        //删除订单
        public void DelOrder(string Oid)
        {
            string str = HttpClientHelper.SendRequest("api/BBRecyleAPI/DelOrder?id='" + Oid + "'", "delete");
            if (str == "1")
            {
                Response.Write("<script>alert('删除成功');location.href='/BeiBei/Ordering';</script>");
            }
            else
            {
                Response.Write("<script>alert('删除失败');location.href='/BeiBei/Ordering';</script>");
            }
        }
        //修改订单状态
        public void UpdOStatus(string Oid)
        {
            var NewMethods = NewMethod();
            OrderInfo order = NewMethods.Where(s => s.Oid.Equals(Oid)).FirstOrDefault();
            order.Ostatus = 4;//已结账
            string content = JsonConvert.SerializeObject(order);
            string str = HttpClientHelper.SendRequest("api/BBRecyleAPI/UpdOrder", "put", content);
            if (str == "1")
            {
                Response.Write("<script>alert('审核成功');location.href='/BeiBei/Ordering';</script>");
            }
            else
            {
                Response.Write("<script>alert('审核失败');location.href='/BeiBei/Ordering';</script>");
            }
        }
        #endregion
        //交易记录
        public ActionResult GetDeal(string cid = "")
        {
            //交易记录表
            List<DealRecord> dealRecords = CommonList<DealRecord>.GetList();
            List<OrderInfo> orderInfos = CommonList<OrderInfo>.GetList();//订单表
            List<CollectorInfo> collectorInfos = CommonList<CollectorInfo>.GetList();//回收员表
            List<UserInfo> userInfos = CommonList<UserInfo>.GetList();//用户表
            //DealRecord deal = dealRecords.where(c => c.Cid.Equals(cid)).FirstOrDefault();
            //cid = deal.Cid.ToString();
            var dealList = from d in dealRecords
                           join o in orderInfos on d.Oid equals o.Oid
                           join c in collectorInfos on d.Cid equals c.Id //回收员
                           join u in userInfos on d.Uid equals u.Id
                           select new
                           {
                               Dtime = d.Dtime,
                               Dmoney = d.Dmoney,//金额s
                               Oid = o.Oid,//订单号
                               Cname = c.Cname,//回收员名
                               Uname = u.Uname,//用户名
                               Oname=o.Oname//物品名称
                           };  
            //string json= JsonConvert.SerializeObject(dealList);
            //List<DealRecord> list = JsonConvert.DeserializeObject<List<DealRecord>>(json);
            //根据员工编号获取该交易记录
            if (cid != "")
            {
                return View(JsonConvert.DeserializeObject<List<DealRecord>>(JsonConvert.SerializeObject(dealList)).Where(c=>c.Cid.Equals(cid)));
            }
            else
            {
                return View(JsonConvert.DeserializeObject<List<DealRecord>>(JsonConvert.SerializeObject(dealList)));
                //Response.Write("<script>alert('当前没有交易记录')</script>");
            }
          
        }
    }
}