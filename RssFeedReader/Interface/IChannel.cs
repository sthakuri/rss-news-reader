using RssFeedReader.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RssFeedReader.Interface
{
    public interface Channel
    {
        string Name { get; set; }
        string WebURL { get; set; }
        string FeedURL { get; set; }

        List<FeedItem> Fetch();
    }
}
