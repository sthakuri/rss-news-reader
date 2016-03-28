using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsFeed.Extension;

namespace NewsFeed.Model
{
    public class ViewModel
    {
        private readonly List<Channel> channels;

        private readonly List<FeedItem> items;
        private List<FeedItem> topItems;

        public ViewModel()
        {
            channels = new List<Channel>();
            items = new List<FeedItem>();
            topItems = new List<FeedItem>();
        }

        public void Add(Channel channel)
        {
            channels.Add(channel);
        }

        public Channel Get(int index)
        {
            if (channels.Count > index)
                return null;
            return channels[index];
        }

        public List<FeedItem> Feeds()
        {
            Parallel.ForEach(channels, c => { if (ePailaExt.IsURLActive(c.FeedURL)) items.AddRange(c.Fetch()); });
            return items.OrderByDescending(x => x.PublishedDate).ToList();
        }

        public override string ToString()
        {
            var bld = new StringBuilder();
            foreach (FeedItem item in items)
            {
                bld.Append("####################################");
                bld.AppendLine();
                bld.Append(item);
                bld.AppendLine();
                bld.Append("####################################");
            }
            return bld.ToString();
        }
    }
}