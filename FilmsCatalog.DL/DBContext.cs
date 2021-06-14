using FilmsCatalog.DL.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FilmsCatalog.DL
{
    public class DBContext : IdentityDbContext<User>
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Film> Films { get; set; }

        public DBContext(DbContextOptions<DBContext> options) : base(options) { }
    }
}
