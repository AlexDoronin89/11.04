using EntityFrameworkLesson.model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EntityFrameworkLesson
{
    class Program
    {
        static void Main(string[] args)
        {

            #region Insert
            using (GroupDbContext db = new GroupDbContext())
            {
                Performer performer = new Performer { Name = "Моргенштерн", Birthday = DateTime.Parse("1580-03-01") };
                Song song = new Song {Title="Селяви", CreateTime=DateTime.Parse("2022-04-02") };
                db.Songs.Add(song);
                db.Performers.Add(performer);
                db.SaveChanges();

                List<Group> groups = db.Groups.Include(g=>g.Performer).Include(s=>s.Song).ToList();
                {
                    new Group { Title = "Мастер и Маргарита", CreateTime = DateTime.Parse("1900-01-12"), PerfomerId = performer.Id, Genre = "Хип-хоп", SongId = song.Id };
                };

                db.Groups.AddRange(groups);
                db.SaveChanges();

                Console.WriteLine($"Group {groups[0].Title},{groups[0].Genre} ID {groups[0].Id} CreateTime {groups[0].CreateTime} Performer {groups[0].Performer.Name} Song {groups[0].Song.Title}");
            }
            #endregion


            #region Select
            using (GroupDbContext db = new GroupDbContext())
            {
                List<Group> groups = db.Groups.ToList();

                foreach (var item in groups)
                {
                    Console.WriteLine($"Group {item.Title},{item.Genre} ID {item.Id} CreateTime {item.CreateTime} Performer {item.PerfomerId} Song {item.SongId}");
                }
            }
            #endregion

            #region Update
            using (GroupDbContext db = new GroupDbContext())
            {
                Group group = db.Groups.FirstOrDefault(i => i.Id == 1);

                if (group != null)
                {
                    group.CreateTime = DateTime.Parse("1900-01-12");
                    db.Groups.Update(group);
                    db.SaveChanges();

                    List<Group> groups = db.Groups.ToList();

                    Console.WriteLine("\nПосле обновления:");
                    foreach (var item in groups)
                    {
                        Console.WriteLine($"Group {item.Title},{item.Genre} ID {item.Id} CreateTime {item.CreateTime} Performer {item.PerfomerId} Song {item.SongId}");
                    }
                }
            }
            #endregion

            #region Delete
            using (GroupDbContext db = new GroupDbContext())
            {
                Group group = db.Groups.FirstOrDefault(i => i.Id == 2);

                if (group != null)
                {
                    db.Groups.Remove(group);
                    db.SaveChanges();

                    List<Group> groups = db.Groups.ToList();

                    Console.WriteLine("\nПосле удаления:");
                    foreach (var item in groups)
                    {
                        Console.WriteLine($"Group {item.Title} ID {item.Id} CreateTime {item.CreateTime} Performer {item.PerfomerId} Song {item.SongId}");
                    }
                }
            }
            #endregion

        }
    }
}
