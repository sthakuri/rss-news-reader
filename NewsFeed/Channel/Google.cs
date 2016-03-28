namespace NewsFeed.Channel
{
    public class Google : Model.Channel
    {
        public Google()
        {
            Name = "Google News";
            WebURL = "http://www.news.google.com";
            FeedURL =
                "https://news.google.com/news/section?cf=all&hl=en&pz=1&ned=us&output=rss&zx=9sc8igswsiqi&as_maxd=27&q=Nepal";
        }
    }
}