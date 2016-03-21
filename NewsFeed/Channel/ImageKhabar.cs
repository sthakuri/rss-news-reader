using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewsFeed.Channel
{
    public class ImageKhabar : Model.Channel
    {
        public ImageKhabar()
        {
            Name = "Imagekhabar";
            WebURL = "http://imagekhabar.com/";
            FeedURL = "http://www.imagekhabar.com/feed/";
        }
    }
}