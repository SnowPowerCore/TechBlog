using PersonalTechBlog.Server.Models.Database.Base;

namespace PersonalTechBlog.Server.Models.Database
{
    public class MediaLinkEntity : BaseEntity
    {
        public string DisplayName { get; set; }

        public string Url { get; set; }

        public string IconUrl { get; set; }
    }
}