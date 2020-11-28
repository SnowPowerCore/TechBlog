using PersonalTechBlog.Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersonalTechBlog.Server.Services.Articles
{
    public interface IArticlesService
    {
        Task<List<Article>> GetArticlesAsync();

        Task<Article> GetSpecificArticle(uint id);

        Task SaveArticleAsync(Article article);

        Task UpdateArticleAsync(uint id, Article article);
    }
}