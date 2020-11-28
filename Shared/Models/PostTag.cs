using System.ComponentModel.DataAnnotations;

namespace PersonalTechBlog.Shared.Models
{
    public class PostTag
    {
        /// <summary>
        /// Name of the category
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Url to filter category on a particular one
        /// </summary>
        [Required]
        public string Url { get; set; }
    }
}
