using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewsFeed.Channel
{
    public class SwasthyaKhabar: Model.Channel
    {
        public SwasthyaKhabar()
        {
            Name = "Swasthya Khabar";
            WebURL = "http://swasthyakhabar.com";
            FeedURL = "http://swasthyakhabar.com/feed";
        }
    }
}