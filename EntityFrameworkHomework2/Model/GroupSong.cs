using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameworkHomework2.Model
{
    public class GroupSong
    {
        public int GroupId { get; set; }
        public int SongId { get; set; }
        public Group Group { get; set; }
        public Song Song { get; set; }
    }
}
