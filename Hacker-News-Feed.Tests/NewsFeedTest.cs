using Hacker_News_Feed.Services;
using Xunit;


namespace Hacker_News_Feed.Tests
{
    public class NewsFeedTest
    {
        private readonly INewsFeed _feed;
        public NewsFeedTest()
        {
            _feed = new NewsFeed();
        }
        
        [Theory]
        [InlineData(10)]
        public async void Correct_Number_Of_Returned_Rows(int limit)
        {
            var apiResult = await _feed.GetLatestNews(limit);
            Assert.True(apiResult.Count == limit);
        }
    }
}