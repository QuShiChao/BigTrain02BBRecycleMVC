using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeiBei.Common;
using Newtonsoft.Json;
using BeiBei.Models;
using BeiBei.Entity;
using System.Web;

namespace BeiBei.Controllers
{
    public class CommonList<T>
    {
        public static List<T> GetList()
        {
            Type type = typeof(T);
            int staffId = int.Parse(AppSettingsConfig.StaffId);
            var tokenResult = WebApiHelper.GetSignToken(staffId);
            string json = JsonConvert.SerializeObject(tokenResult.Data);
            Token token = JsonConvert.DeserializeObject<Token>(json);
            var d = token.SignToken;
            HttpCookie cookie = new HttpCookie("token");
            cookie["guid"] = d.ToString();
            HttpContext.Current.Response.Cookies.Add(cookie);
            string url = "";
            switch (type.Name)
            {
                case "AdminInfo":
                    url = "BBRecyleAPI/GetAdmin";
                    break;
                case "UserInfo":
                    url = "BBRecyleAPI/GetUser";
                    break;
                case "BookInfo":
                    url = "http://localhost:57004/api/BBRecyleAPI/GetBook";
                    break;
                case "CollectorInfo":
                    url = "http://localhost:57004/api/BBRecyleAPI/GetCollector";
                    break;
                case "Recycles":
                    url = "http://localhost:57004/api/BBRecyleAPI/GetRec";
                    break;
                case "OrderInfo":
                    url = "http://localhost:57004/api/BBRecyleAPI/GetOrder";
                    break;
                case "DealRecord":
                    url = "http://localhost:57004/api/BBRecyleAPI/GetDeal";
                    break;
            }
            var obj = WebApiHelper.Get<ProductResultMsg<T>>(url, null, null, staffId);
            //string json = HttpClientHelper.SendRequest(url,"get");
            List<T> list = JsonConvert.DeserializeObject<List<T>>(obj.Data.ToString());
            return list;
        }
    }
}
