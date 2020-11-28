using PersonalTechBlog.Server.Models.Database.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

namespace PersonalTechBlog.Server.Models.Database
{
    public class AuthorEntity : BaseEntity
    {
        public string AvatarUrl { get; init; }

        public string FirstName { get; init; }

        public string LastName { get; init; }

        public string DisplayName =>
            $"{FirstName} {LastName}";

        public string Motto { get; init; }

        public string AboutMe { get; init; }

        [NotMapped]
        public List<MediaLinkEntity> MediaLinks
        {
            get => JsonSerializer.Deserialize<List<MediaLinkEntity>>(MediaLinksSerialized);
            init => MediaLinksSerialized = JsonSerializer.Serialize(value);
        }

        public string MediaLinksSerialized { get; set; }
    }
}
