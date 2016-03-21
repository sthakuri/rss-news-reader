﻿using NewsFeed.Extension;
using NewsFeed.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace NewsFeed.Channel
{
    class BBCNepali : Model.Channel
    {
        public BBCNepali()
        {
            Name = "BBC Nepali";
            WebURL = "http://www.bbcnepali.com";
            FeedURL = "http://www.bbc.com/nepali/index.xml";
        }

        public virtual List<FeedItem> Fetch()
        {
            List<FeedItem> items = new List<FeedItem>();
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
                XmlNamespaceManager nsmgr = new XmlNamespaceManager(rssXmlDoc.NameTable);
                nsmgr.AddNamespace("bbc", "http://www.w3.org/2005/Atom");
                XmlNodeList rssNodes = rssXmlDoc.SelectNodes("//bbc:entry", nsmgr);

                // Iterate through the items in the RSS file
                foreach (XmlNode rssNode in rssNodes)
                {
                    string title = rssNode["title"].InnerText;
                    string link = "http://www.bbc.com" + rssNode["dc:identifier"].InnerText;
                    string description = rssNode["summary"].InnerText;
                    DateTime pubDate = DateTimeExt.ToDateTime(rssNode["updated"].InnerText);
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
