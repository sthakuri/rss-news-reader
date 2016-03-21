using NewsFeed.Interface;
using NewsFeed.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsFeed.Channel
{
    class OnlineKhabar : Model.Channel
    {
        public OnlineKhabar()
        {
            FeedURL = "http://www.onlinekhabar.com/feed/";
            Name = "OnlineKhabar";
            WebURL = "http://www.onlinekhabar.com/";
        }
    }
}
