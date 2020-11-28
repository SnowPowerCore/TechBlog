using Refit;
using System.Threading.Tasks;

namespace PersonalTechBlog.Client.Services.Api.Article
{
    public interface IArticlesApi
    {
        [Get("/api/articles")]
        public Task<TResult> GetArticlesAsync<TResult>();
    }
}