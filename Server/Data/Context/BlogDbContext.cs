using Microsoft.EntityFrameworkCore;
using PersonalTechBlog.Server.Models.Database;

namespace PersonalTechBlog.Server.Data.Context
{
    public class BlogDbContext : DbContext
    {
        public BlogDbContext(DbContextOptions<BlogDbContext> options)
          : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ArticleEntity>()
                .Property(p => p.Title).IsRequired();
            modelBuilder.Entity<ArticleEntity>()
                .Property(p => p.Content).IsRequired();
            modelBuilder.Entity<ArticleEntity>()
                .Property(p => p.AuthorsSerialized).IsRequired();

            modelBuilder.Entity<AuthorEntity>()
                .Property(p => p.FirstName).IsRequired();
            modelBuilder.Entity<AuthorEntity>()
                .Property(p => p.LastName).IsRequired();
            modelBuilder.Entity<AuthorEntity>()
                .Property(p => p.AboutMe).IsRequired();

            // Indexes
            modelBuilder.Entity<ArticleEntity>()
                .HasIndex(idx => idx.Title);

            modelBuilder.Entity<AuthorEntity>()
                .HasIndex(idx => idx.FirstName);

            modelBuilder.Entity<AuthorEntity>()
                .HasIndex(idx => idx.LastName);

            modelBuilder.Entity<ArticleEntity>().ToTable("Articles");

            modelBuilder.Entity<AuthorEntity>().ToTable("Authors");

            base.OnModelCreating(modelBuilder);
        }
    }
}