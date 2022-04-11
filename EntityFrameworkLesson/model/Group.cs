using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkLesson.model
{
    internal class Group
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public DateTime CreateTime { get; set; }
        public int PerfomerId { get; set; }
        public int SongId { get; set; }
        public Performer Performer { get; set; }
        public Song Song { get; set; }
    }
}
