using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkLesson.model
{
    internal class GroupDbContext : DbContext
    {
        public DbSet<Group> Group { get; set; }
        public DbSet<Performer> Performer { get; set; }
        public DbSet<Song> Song { get; set; }

        public GroupDbContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("Server=localhost;User=root;Password=1234;Database=zxc", new MySqlServerVersion(new Version()));
        }
            
    }
}
