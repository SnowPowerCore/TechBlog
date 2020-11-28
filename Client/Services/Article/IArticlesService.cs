using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersonalTechBlog.Client.Services.Article
{
    public interface IArticlesService
    {
        Task<List<PersonalTechBlog.Shared.Models.Article>> GetArticlesAsync();
    }
}