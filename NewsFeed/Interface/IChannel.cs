using System.Collections.Generic;
using NewsFeed.Model;

namespace NewsFeed.Interface
{
    public interface IChannel
    {
        string Name { get; set; }
        string WebURL { get; set; }
        string FeedURL { get; set; }

        List<FeedItem> Fetch();
    }
}