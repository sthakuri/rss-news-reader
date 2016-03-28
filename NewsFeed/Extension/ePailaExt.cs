using System;
using System.Net;

namespace NewsFeed.Extension
{
    public class ePailaExt
    {
        public static bool IsURLActive(string url)
        {
            WebRequest request = WebRequest.Create(url);
            request.Timeout = 1000;
            bool chk = false;
            try
            {
                using (var response = (HttpWebResponse) request.GetResponse())
                {
                    chk = (response != null && response.StatusCode == HttpStatusCode.OK);
                }
            }
            catch (Exception)
            {
                chk = false;
            }
            return chk;
        }
    }
}