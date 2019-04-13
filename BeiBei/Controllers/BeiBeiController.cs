using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BeiBei.Controllers
{
    public class BeiBeiController : Controller
    {
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
            return View();
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
        public ActionResult GetDeal()
        {
            return View();
        }
    }
}