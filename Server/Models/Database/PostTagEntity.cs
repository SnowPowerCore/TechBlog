using PersonalTechBlog.Server.Models.Database.Base;

namespace PersonalTechBlog.Server.Models.Database
{
    public class PostTagEntity : BaseEntity
    {
        public string Name { get; init; }

        public string Url { get; init; }
    }
}