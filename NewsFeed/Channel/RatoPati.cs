using System.IO;
using System.Net;
using System.Xml;
using NewsFeed.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NewsFeed.Extension;
using System.Threading.Tasks;

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

        public async override Task<List<FeedItem>> Fetch()
        {
            List<FeedItem> items = new List<FeedItem>();
            XmlDocument rssXmlDoc = new XmlDocument();
            try
            {
                try
                {
                    WebClient wc = new WebClient();
                    Stream st = wc.OpenRead(this.FeedURL);
                    string rss = "";
                    using (StreamReader sr = new StreamReader(st))
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
                        items.Add(new FeedItem() { Channel = this, HeadLine = title, Description = description, Link = link, PublishedDate = pubDate });
                }

            }
            catch (Exception ex)
            {

            }
            return items.ToList();
        }
    }
}