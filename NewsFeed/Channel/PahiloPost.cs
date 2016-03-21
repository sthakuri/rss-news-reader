using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewsFeed.Channel
{
    public class PahiloPost : Model.Channel
    {
        public PahiloPost()
        {
            Name = "Pahilopost";
            WebURL = "http://pahilopost.com/";
            FeedURL = "http://www.pahilopost.com/rss/";
        }
    }
}