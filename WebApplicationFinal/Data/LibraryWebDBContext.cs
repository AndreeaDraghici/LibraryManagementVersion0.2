using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApplicationFinal.Models;

namespace WebApplicationFinal.Data
{
    public class LibraryWebDBContext : IdentityDbContext<IdentityUser>
    {
        public LibraryWebDBContext(DbContextOptions<LibraryWebDBContext> dbContextOptions) : base(dbContextOptions) { }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<AuthorBook> AuthorBooks { get; set; }
        public DbSet<Library> Library { get; set; }
        public DbSet<Message> Messages { get; set; }

    }
}
