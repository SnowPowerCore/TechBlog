using PersonalTechBlog.Client.Services.Api.Article;
using Refit;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace PersonalTechBlog.Client.Services.Article
{
    public class ArticlesService : IArticlesService
    {
        private IArticlesApi _articles;

        public ArticlesService(IHttpClientFactory clientFactory)
        {
            var client = clientFactory.CreateClient("localClient");
            _articles = RestService.For<IArticlesApi>(client);
        }

        public Task<List<PersonalTechBlog.Shared.Models.Article>> GetArticlesAsync() =>
            _articles.GetArticlesAsync<List<PersonalTechBlog.Shared.Models.Article>>();
    }
}