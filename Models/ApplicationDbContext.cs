using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace PrelloStarter2.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            //Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=./ProjectManager.sqlite");
        }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Client> Clients { get; set; }
    }
}
