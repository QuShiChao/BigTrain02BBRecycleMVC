using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using BeiBei.Common;

namespace BeiBei.Controllers
{
    public class HttpClientHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <param name="method"></param>
        /// <param name="data">json字符串格式数据</param>
        /// <returns></returns>
        public static string SendRequest(string url, string method, string data="")
        {
            int staffId = int.Parse(AppSettingsConfig.StaffId);
            var tokenResult = WebApiHelper.GetSignToken(staffId);
            string obj = WebApiHelper.PPD(url, data,method, staffId);
            return obj;
        }

    }
}