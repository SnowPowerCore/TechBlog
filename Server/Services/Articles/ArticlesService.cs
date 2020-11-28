using PersonalTechBlog.Server.Data.Repository.Database.Article;
using PersonalTechBlog.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalTechBlog.Server.Services.Articles
{
    public class ArticlesService : IArticlesService
    {
        private readonly IArticlesRepository _articlesRepository;

        public ArticlesService(IArticlesRepository articlesRepository)
        {
            _articlesRepository = articlesRepository;
        }

        public async Task<List<Article>> GetArticlesAsync()
        {
            var articles = await _articlesRepository.GetAllAsync();
            if (null != articles)
                return articles
                    .Select(x => new Article
                    {
                        Authors = x.Authors
                            .Select(a => new Author
                            {
                                FirstName = a.FirstName,
                                LastName = a.LastName,
                                Motto = a.Motto,
                                AvatarUrl = a.AvatarUrl,
                                AboutMe = a.AboutMe,
                                MediaLinks = a.MediaLinks
                                    .Select(m => new MediaLink
                                    {
                                        DisplayName = m.DisplayName,
                                        IconUrl = m.IconUrl,
                                        Url = m.Url
                                    })
                                    .ToList()
                            })
                            .ToList(),
                        Content = x.Content,
                        Tags = x.Tags
                            .Select(t => new PostTag
                            {
                                Name = t.Name,
                                Url = t.Url
                            })
                            .ToList(),
                        Title = x.Title
                    })
                    .ToList();
            return new List<Article>();
        }

        public async Task<Article> GetSpecificArticle(uint id)
        {
            var article = await _articlesRepository.GetByIdAsync((int)id);
            if (null != article)
                return new Article
                {
                    Authors = article.Authors
                        .Select(a => new Author
                        {
                            FirstName = a.FirstName,
                            LastName = a.LastName,
                            Motto = a.Motto,
                            AvatarUrl = a.AvatarUrl,
                            AboutMe = a.AboutMe,
                            MediaLinks = a.MediaLinks
                                .Select(m => new MediaLink
                                {
                                    DisplayName = m.DisplayName,
                                    IconUrl = m.IconUrl,
                                    Url = m.Url
                                })
                                .ToList()
                        })
                        .ToList(),
                    Content = article.Content,
                    Tags = article.Tags
                        .Select(t => new PostTag
                        {
                            Name = t.Name,
                            Url = t.Url
                        })
                        .ToList(),
                    Title = article.Title
                };
            return new Article();
        }

        public Task SaveArticleAsync(Article article) =>
            _articlesRepository.AddOrUpdateAsync(new Models.Database.ArticleEntity
            {
                Title = article.Title,
                Content = article.Content,
                Authors = article.Authors
                    .Select(a => new Models.Database.AuthorEntity
                    {
                        FirstName = a.FirstName,
                        LastName = a.LastName,
                        Motto = a.Motto,
                        AboutMe = a.AboutMe,
                        AvatarUrl = a.AvatarUrl,
                        MediaLinks = a.MediaLinks
                            .Select(m => new Models.Database.MediaLinkEntity
                            {
                                DisplayName = m.DisplayName,
                                IconUrl = m.IconUrl,
                                Url = m.Url
                            })
                            .ToList()
                    })
                    .ToList(),
                Tags = article.Tags
                    .Select(t => new Models.Database.PostTagEntity
                    {
                        Name = t.Name,
                        Url = t.Url
                    })
                    .ToList()
            });

        public Task UpdateArticleAsync(uint id, Article article) =>
            _articlesRepository.AddOrUpdateAsync(new Models.Database.ArticleEntity
            {
                Id = id,
                Title = article.Title,
                Content = article.Content,
                Authors = article.Authors
                    .Select(a => new Models.Database.AuthorEntity
                    {
                        FirstName = a.FirstName,
                        LastName = a.LastName,
                        Motto = a.Motto,
                        AboutMe = a.AboutMe,
                        AvatarUrl = a.AvatarUrl,
                        MediaLinks = a.MediaLinks
                            .Select(m => new Models.Database.MediaLinkEntity
                            {
                                DisplayName = m.DisplayName,
                                IconUrl = m.IconUrl,
                                Url = m.Url
                            })
                            .ToList()
                    })
                    .ToList(),
                Tags = article.Tags
                    .Select(t => new Models.Database.PostTagEntity
                    {
                        Name = t.Name,
                        Url = t.Url
                    })
                    .ToList()
            }, id);
    }
}