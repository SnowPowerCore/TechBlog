using System.ComponentModel.DataAnnotations;

namespace PersonalTechBlog.Shared.Models
{
    public class MediaLink
    {
        /// <summary>
        /// Media link title
        /// </summary>
        [Required]
        public string DisplayName { get; set; }

        /// <summary>
        /// Url for specific link
        /// </summary>
        [Required]
        public string Url { get; set; }

        /// <summary>
        /// Url to specific link's icon
        /// </summary>
        public string IconUrl { get; set; }
    }
}
