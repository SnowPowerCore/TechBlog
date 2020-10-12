using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PersonalTechBlog.Shared.Models
{
    /// <summary>
    /// Author is a writer which blogs its way forward
    /// </summary>
    public class Author
    {
        /// <summary>
        /// Url to author's avatar
        /// </summary>
        public string AvatarUrl { get; set; }

        /// <summary>
        /// Author should have first name
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "You should have first name set.")]
        [RegularExpression("^\\S*$", ErrorMessage = "First name cannot contain spaces.")]
        public string FirstName { get; set; }

        /// <summary>
        /// Author should have last name
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "You should have last name set.")]
        [RegularExpression("^\\S*$", ErrorMessage = "Last name cannot contain spaces.")]
        public string LastName { get; set; }

        /// <summary>
        /// This is for easy full name formatting
        /// </summary>
        public string DisplayName =>
            $"{FirstName} {LastName}";

        /// <summary>
        /// Author might have an inspiring motto
        /// </summary>
        [StringLength(64, MinimumLength = 4, ErrorMessage = "Motto should be less than 64 chars.")]
        public string Motto { get; set; }

        /// <summary>
        /// Author can share his biography (a little)
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "You should describe yourself at least short.")]
        [StringLength(1024, MinimumLength = 8, ErrorMessage = "About Me section should not exceed 1024 chars.")]
        public string AboutMe { get; set; }

        /// <summary>
        /// Author can have media links
        /// </summary>
        public List<MediaLink> MediaLinks { get; set; } =
            new List<MediaLink>();
    }
}
