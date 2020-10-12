using PersonalTechBlog.Server.Models.Database.Base;

namespace PersonalTechBlog.Server.Models.Database
{
    public class PostTagEntity : BaseEntity
    {
        public string Name { get; set; }

        public string Url { get; set; }
    }
}