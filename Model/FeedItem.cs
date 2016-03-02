using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RssFeedReader.Extension;

namespace RssFeedReader.Model
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
            string str = string.Format("{0} | Posted On: {1}", this.HeadLine, DateTimeExt.ToString(this.PublishedDate));
            //str += Environment.NewLine;
            //str += Description;
            return str;
        }
    }  
       
}
