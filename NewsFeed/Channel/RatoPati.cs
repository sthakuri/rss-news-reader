using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Xml;
using NewsFeed.Extension;
using NewsFeed.Model;

namespace NewsFeed.Channel
{
    public class RatoPati : Model.Channel
    {
        public RatoPati()
        {
            Name = "Ratopati";
            WebURL = "http://ratopati.com/";
            FeedURL = "http://www.ratopati.com/newsfeed/";
        }

        public virtual List<FeedItem> Fetch()
        {
            var items = new List<FeedItem>();
            var rssXmlDoc = new XmlDocument();
            try
            {
                try
                {
                    var wc = new WebClient();
                    Stream st = wc.OpenRead(FeedURL);
                    string rss = "";
                    using (var sr = new StreamReader(st))
                    {
                        rss = sr.ReadToEnd();
                    }
                    int index = rss.IndexOf('<');
                    rss = rss.Remove(0, index);
                    rssXmlDoc.LoadXml(rss);
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
    }
}