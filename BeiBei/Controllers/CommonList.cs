using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BeiBei.Controllers
{
    public class CommonList<T>
    {
        public static List<T> GetList()
        {
            Type type = typeof(T);
            string url = "";
            switch (type.Name)
            {
                case "AdminInfo":
                    url = "api/BBRecyleAPI/GetAdmin";
                    break;
                case "UserInfo":
                    url = "api/BBRecyleAPI/GetUser";
                    break;
                case "BookInfo":
                    url = "api/BBRecyleAPI/GetBook";
                    break;
                case "CollectorInfo":
                    url = "api/BBRecyleAPI/GetCollector";
                    break;
                case "Recycles":
                    url = "api/BBRecyleAPI/GetRec";
                    break;
                case "OrderInfo":
                    url = "api/BBRecyleAPI/GetOrder";
                    break;
                case "DealRecord":
                    url = "api/BBRecyleAPI/GetDeal";
                    break;
            }
            string json = HttpClientHelper.SendRequest(url,"get");
            List<T> list = JsonConvert.DeserializeObject<List<T>>(json.ToString());
            return list;
        }
    }
}
