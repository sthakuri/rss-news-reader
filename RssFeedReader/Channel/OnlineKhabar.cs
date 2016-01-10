using RssFeedReader.Interface;
using RssFeedReader.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RssFeedReader.Channel
{
    class OnlineKhabar : Model.Channel
    {
        public OnlineKhabar()
        {
            FeedURL = "https://news.google.com/news?cf=all&hl=en&pz=1&ned=us&q=Nepal&output=rss";
            Name = "Google News";
            WebURL = "www.news.google.com";
        }
    }
}
