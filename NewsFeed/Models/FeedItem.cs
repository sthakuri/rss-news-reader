using System;
using NewsFeed.Extension;

namespace NewsFeed.Model
{
    public class FeedItem
    {
        public string HeadLine { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }
        public DateTime PublishedDate { get; set; }
        public Channel Channel { get; set; }

        public override string ToString()
        {
            string str = string.Format("{0} | Posted On: {1}", HeadLine, DateTimeExt.ToLovelyTime(PublishedDate));
            //str += Environment.NewLine;
            //str += Description;
            return str;
        }
    }
}