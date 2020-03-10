using System.Collections.Generic;

namespace Hacker_News_Feed.Models
{
    public class FeedItemModel
    {
        public int Id { get; set; }
        public string By { get; set; }
        public int Parent { get; set; }
        public int Descendants { get; set; }
        public List<int> Kids { get; set; }
        public int Score { get; set; }
        public int Time { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string Type { get; set; }
        public string Url { get; set; }
    }
}