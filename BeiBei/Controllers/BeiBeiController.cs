using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BeiBei.Common;
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
        List<UserInfo> userList = CommonList<UserInfo>.GetList();
        //用户登录
        public int LoginUser(string tel = "", string pwd = "")
        {
            UserInfo user = userList.FirstOrDefault(u => u.Utel.Equals(tel) && u.Upwd.Equals(pwd));
            if (user == null)
            {
                //登录失败
                return 0;
            }
            else
            {
                //登录成功
                HttpCookie cookie = Request.Cookies.Get("token");
                string guid = "";
                if (cookie != null)
                {
                     guid= cookie.Values["guid"];
                }
                return user.Id;
            }
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
        public string GetUser(int uid=0)
        {
            if (uid > 0)
            {
                UserInfo user = userList.FirstOrDefault(u => u.Id.Equals(uid));
                return JsonConvert.SerializeObject(user);
            }
            else
            {
                return null;
            }
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
            return View(recyclesList);
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
            List<OrderInfo> list = CommonList<OrderInfo>.GetList().Where(o => o.Ostatus >= 3).ToList();
            return View(list);
        }
        //删除订单
        public void DelOrder(string Oid)
        {
            string str = HttpClientHelper.SendRequest("BBRecyleAPI/DelOrder?id='" + Oid + "'", "delete");
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
            List<OrderInfo> list = CommonList<OrderInfo>.GetList().Where(o => o.Ostatus >= 3).ToList();
            OrderInfo order = list.Where(s => s.Oid.Equals(Oid)).FirstOrDefault();
            order.Ostatus = 4;//已结账
            string content = JsonConvert.SerializeObject(order);
            string str = HttpClientHelper.SendRequest("BBRecyleAPI/UpdOrder","put",content);
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
            List<DealRecord> dealList = CommonList<DealRecord>.GetList();
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