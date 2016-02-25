using RssFeedReader.Channel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RssFeedReader
{
    class Program
    {
        static void Main(string[] args)
        {
            RssFeedReader.Model.FeedReader reader = new Model.FeedReader();
            reader.Add(new OnlineKhabar());
            Console.WriteLine(reader.ToString());
            Console.ReadLine();            
        }
    }
}
