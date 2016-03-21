using NewsFeed.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsFeed.Interface
{
    public interface IChannel
    {
        string Name { get; set; }
        string WebURL { get; set; }
        string FeedURL { get; set; }

        Task<List<FeedItem>> Fetch();
    }
}
