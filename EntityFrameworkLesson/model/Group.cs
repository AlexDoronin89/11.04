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
        public int PerformerId { get; set; }
        public int SongId { get; set; }
        public string Genre { get; set; }
    }
}
