using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsFeed.Model
{
    public class ViewModel
    {
        List<Channel> channels;

        private List<FeedItem> topItems;
        List<FeedItem> items;

        public ViewModel()
        {
            channels = new List<Channel>();
            items = new List<FeedItem>();
            topItems=new List<FeedItem>();
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

        public List<FeedItem> TopFeeds()
        {
            //Parallel.ForEach(channels, c => { topItems.AddRange(c.Fetch()); });
            return items.OrderByDescending(x => x.PublishedDate).Take(5).ToList();
        }

        //public List<FeedItem> Feeds()
        //{
        //    Parallel.ForEach(channels, c => { items.AddRange(c.Fetch()); });
        //    return items.OrderByDescending(x => x.PublishedDate).ToList();
        //}

        public async Task<List<FeedItem>> Feeds()
        {
            //Parallel.ForEach(channels, c =>
            //{
            //    var data = c.Fetch();
            //    items.AddRange(data.Result);
            //});
            foreach (var c in channels)
            {
                var data = await c.Fetch();
                items.AddRange(data);
            }
            return items.OrderByDescending(x => x.PublishedDate).ToList();
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
