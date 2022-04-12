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
        public DateTime Create_Time { get; set; }
        public int Perfomer_Id { get; set; }
        public int Song_Id { get; set; }
        public Performer Performer { get; set; }
        public Song Song { get; set; }
    }
}
