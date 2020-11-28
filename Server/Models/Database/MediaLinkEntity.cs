using PersonalTechBlog.Server.Models.Database.Base;

namespace PersonalTechBlog.Server.Models.Database
{
    public class MediaLinkEntity : BaseEntity
    {
        public string DisplayName { get; init; }

        public string Url { get; init; }

        public string IconUrl { get; init; }
    }
}