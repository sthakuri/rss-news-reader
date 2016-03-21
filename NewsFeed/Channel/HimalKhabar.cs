using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewsFeed.Channel
{
    public class HimalKhabar : Model.Channel
    {
        public HimalKhabar()
        {
            Name = "Himalkhabar";
            WebURL = "http://himalkhabar.com/";
            FeedURL = "http://www.himalkhabar.com/feed";
        }
    }
}