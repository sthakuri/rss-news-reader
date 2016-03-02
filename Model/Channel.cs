using RssFeedReader.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace RssFeedReader.Model
{
    public class Channel : Interface.Channel
    {
        public string Name { get; set; }
        public string WebURL { get; set; }
        public string FeedURL { get; set; }

        protected string ReadNodeElement(XmlNode rssNode, string element)
        {
            XmlNode rssSubNode = rssNode.SelectSingleNode(element);
            return rssSubNode != null ? rssSubNode.InnerText : "";
        }

        public List<FeedItem> Fetch()
        {
            var items = new List<FeedItem>();
            XmlDocument rssXmlDoc = new XmlDocument();
            try
            {
                try
                {
                    rssXmlDoc.Load(this.FeedURL);
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
                    DateTime pubDate = ToDateTime(ReadNodeElement(rssNode, "pubDate"));

                    items.Add(new FeedItem() {  HeadLine = title, Description = description, Link = link, PublishedDate = pubDate });
                }
            }
            catch (Exception ex)
            {
            }
            return items.ToList();
        }

        public DateTime ToDateTime(string strDateTime)
        {
            DateTime dt = DateTime.Now;
            try
            {
                dt = DateTime.Parse(strDateTime);
            }
            catch
            {
            }
            return dt;
        }
    }
}
