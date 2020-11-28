using PersonalTechBlog.Server.Models.Database.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

namespace PersonalTechBlog.Server.Models.Database
{
    public class ArticleEntity : BaseEntity
    {
        public string Title { get; init; }

        public string Content { get; init; }

        [NotMapped]
        public List<AuthorEntity> Authors
        {
            get => JsonSerializer.Deserialize<List<AuthorEntity>>(AuthorsSerialized);
            init => AuthorsSerialized = JsonSerializer.Serialize(value);
        }

        public string AuthorsSerialized { get; set; }

        [NotMapped]
        public List<PostTagEntity> Tags
        {
            get => JsonSerializer.Deserialize<List<PostTagEntity>>(TagsSerialized);
            init => TagsSerialized = JsonSerializer.Serialize(value);
        }

        public string TagsSerialized { get; set; }
    }
}