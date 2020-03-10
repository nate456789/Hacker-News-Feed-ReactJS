using System.Collections.Generic;

namespace Hacker_News_Feed.Models
{
    public class StoryResponseModel
    {
        public int id { get; set; }
        public string by { get; set; }
        public int descendants { get; set; }
        public List<int?> kids { get; set; }
        public int score { get; set; }
        public int time { get; set; }
        public string title { get; set; }
        public string type { get; set; }
        public string url { get; set; }
    }
}
