using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewsFeed.Channel
{
    public class SetoPati : Model.Channel
    {
        public SetoPati()
        {
            Name = "Setopati";
            WebURL = "http://www.setopati.com/";
            FeedURL = "http://setopati.com/rss/";
        }
    }
}