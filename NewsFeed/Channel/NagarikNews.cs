using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewsFeed.Channel
{
    public class NagarikNews : Model.Channel
    {
        public NagarikNews()
        {
            Name = "Nagarik News";
            WebURL = "http://www.nagariknews.com";
            FeedURL = "http://www.nagariknews.com/main-story.feed";
        }
    }
}