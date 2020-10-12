using PersonalTechBlog.Server.Models.Database.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

namespace PersonalTechBlog.Server.Models.Database
{
    public class AuthorEntity : BaseEntity
    {
        public string AvatarUrl { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string DisplayName =>
            $"{FirstName} {LastName}";

        public string Motto { get; set; }

        public string AboutMe { get; set; }

        [NotMapped]
        public List<MediaLinkEntity> MediaLinks
        {
            get => JsonSerializer.Deserialize<List<MediaLinkEntity>>(MediaLinksSerialized);
            set => MediaLinksSerialized = JsonSerializer.Serialize(value);
        }

        public string MediaLinksSerialized { get; set; }
    }
}
