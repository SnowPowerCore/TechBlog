using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PersonalTechBlog.Shared.Models
{
    /// <summary>
    /// Article is a unit of content for particular topic
    /// </summary>
    public class Article
    {
        /// <summary>
        /// Article should have a title
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Title should be set.")]
        [StringLength(128)]
        public string Title { get; set; }

        /// <summary>
        /// Article should have a content
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Article should have content.")]
        public string Content { get; set; }

        /// <summary>
        /// Article should have an author or more than one
        /// </summary>
        [Required(ErrorMessage = "Article should have at least one author or publisher.")]
        public List<Author> Authors { get; set; } =
            new List<Author>();

        /// <summary>
        /// Article can have tags associated
        /// </summary>
        public List<PostTag> Tags { get; set; } =
            new List<PostTag>();
    }
}