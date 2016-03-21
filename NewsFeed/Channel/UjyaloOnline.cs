using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewsFeed.Channel
{
    public class UjyaloOnline : Model.Channel
    {
        public UjyaloOnline()
        {
            Name = "Ujyaaloonline";
            WebURL = "http://ujyaaloonline.com/";
            FeedURL = "http://ujyaaloonline.com/rss";
        }
    }
}