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
            int userChoose;
            
            bool isWork = true;
            while (isWork)
            {
                Console.WriteLine("1 C 2 R 3 U 4D");
                userChoose = int.Parse(Console.ReadLine());
                switch (userChoose)
                {
                    case 1:
                        #region Insert


                        using (GroupDbContext db = new GroupDbContext())
                        {

                            Performer performer = new Performer { Name = "Моргенштерн", Birthday = DateTime.Parse("1580-03-01") };
                            Song song = new Song { Title = "Селяви", Create_Time = DateTime.Parse("2022-04-02") };
                            db.Song.Add(song);
                            db.Performer.Add(performer);
                            db.SaveChanges();


                            db.Group.Add(new Group { Title = "Мастер и Маргарита", Create_Time = DateTime.Parse("1900-01-12"), Performer = performer, Perfomer_Id = performer.Id, Genre = "Хип-хоп", Song = song, Song_Id = song.Id });


                            db.SaveChanges();
                            List<Group> groups = db.Group.Include(g => g.Performer).Include(s => s.Song).ToList();

                            Console.WriteLine($"Group {groups[0].Title},{groups[0].Genre} ID {groups[0].Id} CreateTime {groups[0].Create_Time} Performer {groups[0].Perfomer_Id} Song {groups[0].Song_Id}");
                        }
                        #endregion
                        break;
                    case 2:
                        #region Select
                        using (GroupDbContext db = new GroupDbContext())
                        {
                            List<Group> groups = db.Group.ToList();

                            foreach (var item in groups)
                            {
                                Console.WriteLine($"Group {item.Title},{item.Genre} ID {item.Id} CreateTime {item.Create_Time} Performer {item.Perfomer_Id} Song {item.Song_Id}");
                            }
                        }
                        #endregion
                        break;
                    case 3:
                        #region Update
                        using (GroupDbContext db = new GroupDbContext())
                        {
                            Group group = db.Group.FirstOrDefault(i => i.Id == 1);

                            if (group != null)
                            {
                                group.Create_Time = DateTime.Parse("1900-01-12");
                                db.Group.Update(group);
                                db.SaveChanges();

                                List<Group> groups = db.Group.ToList();

                                Console.WriteLine("\nПосле обновления:");
                                foreach (var item in groups)
                                {
                                    Console.WriteLine($"Group {item.Title},{item.Genre} ID {item.Id} CreateTime {item.Create_Time} Performer {item.Perfomer_Id} Song {item.Song_Id}");
                                }
                            }
                        }
                        #endregion
                        break;
                    case 4:
                        #region Delete
                        using (GroupDbContext db = new GroupDbContext())
                        {
                            Group group = db.Group.FirstOrDefault(i => i.Id == 2);

                            if (group != null)
                            {
                                db.Group.Remove(group);
                                db.SaveChanges();

                                List<Group> groups = db.Group.ToList();

                                Console.WriteLine("\nПосле удаления:");
                                foreach (var item in groups)
                                {
                                    Console.WriteLine($"Group {item.Title} ID {item.Id} CreateTime {item.Create_Time} Performer {item.Perfomer_Id} Song {item.Song_Id}");
                                }
                            }
                        }
                        #endregion
                        break;
                    default:
                        break;
                }

            }


        }



    }
}
