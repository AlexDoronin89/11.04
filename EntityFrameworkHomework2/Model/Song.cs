using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameworkHomework2.Model
{
    public class Song
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int Length { get; set; }
        public virtual ICollection<Group> Groups { get; set; } = new List<Group>();
        public virtual ICollection<GroupSong> GroupSongs { get; set; }
    }
}
