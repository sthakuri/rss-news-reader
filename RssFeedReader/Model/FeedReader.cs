using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RssFeedReader.Model
{
    public class FeedReader
    {
        List<Channel> channels;
        List<FeedItem> items;

        public FeedReader()
        {
            channels = new List<Channel>();
            items = new List<FeedItem>();
        }

        public void Add(Channel channel)
        {
            channels.Add(channel);
            items.AddRange(channel.Fetch());
        }

        public Channel Get(int index)
        {
            if (channels.Count > index)
                return null;
            return channels[index];            
        }

        public List<FeedItem> Feeds()
        {
            return items;
        }

        public override string ToString()
        {
            StringBuilder bld = new StringBuilder();
            foreach (var item in items)
            {
                bld.Append("####################################");
                bld.AppendLine();
                bld.Append(item.ToString());
                bld.AppendLine();
                bld.Append("####################################");
            }
            return bld.ToString();
        }


    }
}
