using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameworkHomework2.Model
{
    public class GroupDbContext : DbContext
    {
        public DbSet<Group> Groups { get; set; }
        public DbSet<Performer> Performers { get; set; }
        public DbSet<Song> Songs { get; set; }

        public GroupDbContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("Server=localhost;User=root;Password=1234;Database=group_homework;", new MySqlServerVersion(new Version()));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Group>()
                .HasMany(c => c.Songs)
                .WithMany(s => s.Groups)
                .UsingEntity<GroupSong>(
                   j => j
                    .HasOne(pt => pt.Song)
                    .WithMany(t => t.GroupSongs)
                    .HasForeignKey(pt => pt.SongId),
                j => j
                    .HasOne(pt => pt.Group)
                    .WithMany(p => p.GroupSongs)
                    .HasForeignKey(pt => pt.GroupId),
                j =>
                {
                    j.HasKey(t => new { t.SongId, t.GroupId });
                    j.ToTable("GroupSongs");
                });
        }
    }
}
