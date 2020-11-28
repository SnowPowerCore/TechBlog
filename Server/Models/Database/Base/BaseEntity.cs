using System.ComponentModel.DataAnnotations;

namespace PersonalTechBlog.Server.Models.Database.Base
{
    public class BaseEntity
    {
        [Key]
        public uint Id { get; init; }

        protected BaseEntity() { }
    }
}