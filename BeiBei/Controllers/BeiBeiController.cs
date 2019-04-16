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
                return user.Id;
            }
        }
        //获取用户信息
        public string GetUser(int uid=0)
        {
            if (uid > 0)
            {
                UserInfo user = userList.FirstOrDefault(u => u.Id.Equals(uid));
                return JsonConvert.SerializeObject(user);
            }
            else
            {
                return JsonConvert.SerializeObject(userList);
            }
             
        }
        //用户修改
        [HttpPost]
        public int UpdUser(UserInfo user)
        {
            string json = JsonConvert.SerializeObject(user);
            string result = HttpClientHelper.SendRequest("api/BBRecyleAPI/UpdUser", "put", json);
            if (result != "")
            {
                return 1;

            }
            else
            {
                return 0;
            }
        }
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
            ViewBag.user = usersList;
            List<CollectorInfo> list = CommonList<CollectorInfo>.GetList();
            return View(list);
        }
        //显示物品信息
        public ActionResult ShowCategory()
        {
            return View();
        }
        //添加回收员
        public ActionResult AddCollector()
        {
            return View();
        }
        //订单操作
        public ActionResult Ordering()
        {
            return View();
        }
        //交易记录
        public ActionResult GetDeal(string cid = "")
        {
            //根据员工编号获取该交易记录
            if (cid != "")
            {

            }
            return View();
        }
    }
}