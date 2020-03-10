namespace Hacker_News_Feed.Models
{

    public class StoryItemModel
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public int CommentCount { get; set; }
        public string Url { get; set; }
        public string BaseUrl { get; set; }
        public string Published { get; set; }
    }
}