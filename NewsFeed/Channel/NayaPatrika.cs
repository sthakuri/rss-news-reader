using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewsFeed.Channel
{
    public class NayaPatrika : Model.Channel
    {
        public NayaPatrika()
        {
            Name = "Naya Patrika";
            WebURL = "http://www.enayapatrika.com/";
            FeedURL = "http://www.enayapatrika.com/feed";
        }
    }
}