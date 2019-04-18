using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BeiBei.Models;

namespace BeiBei.Controllers
{
    public class BeiBeiController : Controller
    {
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
            if (Pwd.Length>6 && Pwd.Length<16)
            {
                Console.WriteLine("<script>alert('密码格式错误');</script>");
            }
            else
            {
                List<AdminInfo> adminList = CommonList<AdminInfo>.GetList();
                adminList = adminList.Where(s => s.Aname.Equals(Name) && s.Apwd.Equals(Pwd)).ToList();
                if (adminList.Count > 0)
                {
                    Console.WriteLine("<script>alert('登录成功！');location.href='/BeiBei/Index'</script>");
                }
                else
                {
                    Console.WriteLine("<script>alert('账号密码输入错误！');</script>");
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
            ViewBag.user = usersList;
            List<CollectorInfo> list = CommonList<CollectorInfo>.GetList();
            return View(list);
        }
        //显示物品信息
        public ActionResult ShowCategory()
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
        public ActionResult Ordering()
        {
            return View();
        }
        //交易记录
        public ActionResult GetDeal(string cid="")
        {
            //根据员工编号获取该交易记录
            if (cid != "")
            {

            }
            return View();
        }
    }
}