using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using NewsFeed.Extension;
using NewsFeed.Model;

namespace NewsFeed.Channel
{
    public class BizMandu : Model.Channel
    {
        public BizMandu()
        {
            Name = "Bizmandu";
            WebURL = "http://bizmandu.com/";
            FeedURL = "http://www.bizmandu.com/feed/news";
        }

        public virtual List<FeedItem> Fetch()
        {
            var items = new List<FeedItem>();
            var rssXmlDoc = new XmlDocument();
            try
            {
                try
                {
                    rssXmlDoc.Load(FeedURL);
                }
                catch (Exception ex1)
                {
                }
                // Parse the Items in the RSS file
                XmlNodeList rssNodes = rssXmlDoc.SelectNodes("rss/channel/item");

                // Iterate through the items in the RSS file
                foreach (XmlNode rssNode in rssNodes)
                {
                    string title = ReadNodeElement(rssNode, "title");
                    string link = ReadNodeElement(rssNode, "weblink");
                    string description = ReadNodeElement(rssNode, "description");
                    DateTime pubDate = DateTimeExt.ToDateTime(ReadNodeElement(rssNode, "pubDate"));

                    items.Add(new FeedItem
                        {
                            Channel = this,
                            HeadLine = title,
                            Description = description,
                            Link = link,
                            PublishedDate = pubDate
                        });
                }
            }
            catch (Exception ex)
            {
            }
            return items.ToList();
        }
    }
}