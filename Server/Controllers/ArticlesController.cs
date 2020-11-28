using Microsoft.AspNetCore.Mvc;
using PersonalTechBlog.Server.Services.Articles;
using PersonalTechBlog.Shared.Models;
using System.Threading.Tasks;

namespace PersonalTechBlog.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private readonly IArticlesService _articles;

        public ArticlesController(IArticlesService articles)
        {
            _articles = articles;
        }

        [HttpGet]
        public async Task<IActionResult> GetArticlesAsync()
        {
            var data = await _articles.GetArticlesAsync();
            if (null != data)
                return new OkObjectResult(data);
            return new NotFoundResult();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetArticleByIdAsync(uint id)
        {
            var data = await _articles.GetSpecificArticle(id);
            if (null != data)
                return new OkObjectResult(data);
            return new NotFoundResult();
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] Article article)
        {
            if (null == article)
                return new BadRequestResult();

            await _articles.SaveArticleAsync(article);

            return new OkResult();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(uint id, [FromBody] Article article)
        {
            if (null == article)
                return new BadRequestResult();

            await _articles.UpdateArticleAsync(id, article);

            return new OkResult();
        }
    }
}
