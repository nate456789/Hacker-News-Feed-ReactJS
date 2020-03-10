using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Hacker_News_Feed.Models;
using Hacker_News_Feed.Utility;
using Newtonsoft.Json;

namespace Hacker_News_Feed.Services
{
    public interface INewsFeed
    {
        public Task<List<StoryItemModel>> GetLatestNews(int limit);
        public List<FeedItemModel> SearchFeed(string searchTerm);
    }

    public class NewsFeed : INewsFeed
    {
        public async Task<List<StoryItemModel>> GetLatestNews(int limit)
        {
            try
            {
                using var httpClient = new HttpClient();
                using var feedItemResponse =
                    await httpClient.GetAsync("https://hacker-news.firebaseio.com/v0/newstories.json");
                string apiFeedResponse = await feedItemResponse.Content.ReadAsStringAsync();
                var articleList = JsonConvert.DeserializeObject<List<int>>(apiFeedResponse);

                var response = new List<StoryItemModel>();

                foreach (var articleId in articleList)
                {
                    if (limit == 0)
                    {
                        break;
                    }

                    limit--;
                    using var storyItemResponse =
                        await httpClient.GetAsync(
                            $"https://hacker-news.firebaseio.com/v0/item/{articleId}.json?print=pretty");
                    string apiStoryResponse = await storyItemResponse.Content.ReadAsStringAsync();
                    var articleDetails = JsonConvert.DeserializeObject<StoryResponseModel>(apiStoryResponse);
                    if (articleDetails.type == "story")
                    {
                        response.Add(new StoryItemModel()
                        {
                            Author = articleDetails.by,
                            Published = DateTimeOffset.FromUnixTimeSeconds(articleDetails.time).ToLocalTime()
                                .FindElapseTime(),
                            CommentCount = articleDetails.kids?.Count ?? 0,
                            Title = articleDetails.title,
                            Url = articleDetails.url,
                            BaseUrl = FindDomain(articleDetails.url),
                            Id = articleDetails.id
                        });
                    }
                }

                return response;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public List<FeedItemModel> SearchFeed(string searchTerm)
        {
            return null;
        }

        private string FindDomain(string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                return string.Empty;
            }

            var uri = new Uri(url);
            var host = uri.Host.Substring(uri.Host.LastIndexOf('/') + 1);
            if (host.Contains("www."))
            {
                host = host.Remove(host.IndexOf("www", StringComparison.Ordinal), 4);
            }

            return host;
        }
    }
}