using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PrelloStarter3.Models
{
    public class IdentifyDbContext : IdentityDbContext<IdentityUser>
    {
        public IdentifyDbContext(DbContextOptions<IdentifyDbContext> options) : base(options)
        {
            Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=./Users.sqlite");
        }
    }
}
