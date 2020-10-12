using PersonalTechBlog.Server.Data.Context;
using PersonalTechBlog.Server.Data.Repository.Database.Base;
using PersonalTechBlog.Server.Models.Database;

namespace PersonalTechBlog.Server.Data.Repository.Database.Article
{
    public class ArticlesRepository : BaseDbRepository<ArticleEntity>, IArticlesRepository
    {
        public ArticlesRepository(BlogDbContext dbContext) : base(dbContext) { }
    }
}