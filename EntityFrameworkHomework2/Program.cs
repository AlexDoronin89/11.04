using EntityFrameworkHomework2.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EntityFrameworkHomework2
{
    class Program
    {
        static void Main(string[] args)
        {
            int userInput = 0;
            bool isExit = false;

            while (isExit == false)
            {
                Console.WriteLine("Select 1\n" +
                    "Isert 2\n" +
                    "Remove 3\n" +
                    "Update 4\n" +
                    "Exit 5\n");
                userInput = int.Parse(Console.ReadLine());

                switch (userInput)
                {
                    case 1:
                        using (GroupDbContext db = new GroupDbContext())
                        {
                            List<Group> groups = db.Groups.ToList();
                            List<Song> songs = db.Songs.ToList();
                            List<Performer> performers = db.Performers.ToList();

                            Console.WriteLine("Группы");
                            foreach (var item in groups)
                            {
                                Console.WriteLine($"Group {item.Title} ID {item.Id}");
                            }
                            Console.WriteLine();

                            Console.WriteLine("Исполнители");
                            foreach (var item in performers)
                            {
                                Console.WriteLine($"Performer {item.Name} Genre {item.Genre} Birthday {item.Birthday} Id {item.Id}");
                            }
                            Console.WriteLine();

                            Console.WriteLine("Песни");
                            foreach (var item in songs)
                            {
                                Console.WriteLine($"Song {item.Title} Length {item.Length} ReleaseDate {item.ReleaseDate} Id {item.Id}");
                            }
                            Console.WriteLine();
                        }
                        break;
                    case 2:
                        using (GroupDbContext db = new GroupDbContext())
                        {
                            Performer performer = new Performer { Name = "Кипелов", Genre = "Хард-н-хеви",  Birthday = DateTime.Parse("2002-01-01") };
                            db.Performers.Add(performer);
                            db.SaveChanges();

                            Group group = new Group { Title = "Ария" };
                            db.Groups.Add(group);

                            List<Song> songs = new List<Song>
                            {
                               new Song { Title ="Я свободен", Length = 330, ReleaseDate =  DateTime.Parse("2003-01-01")},
                               new Song { Title ="Улица роз", Length = 197, ReleaseDate =  DateTime.Parse("2004-01-01")}
                            };
                            db.Songs.AddRange(songs);

                            foreach (Song item in songs)
                            {
                                group.Songs.Add(item);
                            }

                            db.SaveChanges();
                        }
                        break;
                    case 3:
                        using (GroupDbContext db = new GroupDbContext())
                        {
                            Group group = db.Groups.FirstOrDefault(i => i.Id == int.Parse(Console.ReadLine()));

                            if (group != null)
                            {
                                db.Groups.Remove(group);
                                db.SaveChanges();
                            }
                        }
                            break;
                    case 4:
                        using (GroupDbContext db = new GroupDbContext())
                        {
                            Group group = db.Groups.FirstOrDefault(i => i.Id == int.Parse(Console.ReadLine()));

                            if (group != null)
                            {
                                group.Title = Console.ReadLine();
                                db.Groups.Update(group);
                                db.SaveChanges();
                            }
                        }
                        break;
                    case 5:
                        isExit = true;
                        break;
                }

                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
