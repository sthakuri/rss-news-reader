﻿namespace NewsFeed.Channel
{
    public class AakarPost : Model.Channel
    {
        public AakarPost()
        {
            Name = "Aakar Post";
            WebURL = "http://www.aakarpost.com/";
            FeedURL = "http://feeds.feedburner.com/AakarPost?format=xml";
        }
    }
}