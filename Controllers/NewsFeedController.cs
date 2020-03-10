using System.Collections.Generic;
using System.Threading.Tasks;
using Hacker_News_Feed.Models;
using Hacker_News_Feed.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Hacker_News_Feed.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NewsFeedController : ControllerBase
    {
        private readonly ILogger<NewsFeedController> _logger;
        private readonly INewsFeed _newsFeedService;
        public NewsFeedController(ILogger<NewsFeedController> logger, INewsFeed newsFeed)
        {
            _logger = logger;
            _newsFeedService = newsFeed;
        }

        [HttpGet]
        public async Task<List<StoryItemModel>> Get(int limit=50)
        {
            var response = await _newsFeedService.GetLatestNews(limit);
            return response;
        }
    }
}