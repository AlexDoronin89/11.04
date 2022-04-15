using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameworkHomework2.Model
{
    public class Group
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public virtual ICollection<Performer> Performers { get; set; } = new List<Performer>();
        public virtual ICollection<Song> Songs { get; set; } = new List<Song>();
        public virtual ICollection<GroupSong> GroupSongs { get; set; }
    }
}
