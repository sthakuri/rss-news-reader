using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using NewsFeed.Extension;
using NewsFeed.Interface;

namespace NewsFeed.Model
{
    public class Channel : IChannel
    {
        public string Name { get; set; }
        public string WebURL { get; set; }
        public string FeedURL { get; set; }

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
                    string link = ReadNodeElement(rssNode, "link");
                    string description = ReadNodeElement(rssNode, "description");
                    DateTime pubDate = DateTimeExt.ToDateTime(ReadNodeElement(rssNode, "pubDate"));
                    if (pubDate > DateTime.Now.AddDays(-1))
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

        protected string ReadNodeElement(XmlNode rssNode, string element)
        {
            XmlNode rssSubNode = rssNode.SelectSingleNode(element);
            return rssSubNode != null ? rssSubNode.InnerText : "";
        }
    }
}