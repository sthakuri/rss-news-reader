using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace NewsFeed.Extension
{
    public class ePailaExt
    {
        public static bool IsURLActive(string url)
        {
            WebRequest request = WebRequest.Create(url);
            bool chk = false;
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                chk = (response != null && response.StatusCode == HttpStatusCode.OK);
            }
            return chk;
        }
    }
}