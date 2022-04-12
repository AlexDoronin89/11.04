using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkLesson.model
{
    internal class Song
    {
        public int Id { get; set; }
        public int Group_Id { get; set; }
        public string Title { get; set; }
        public virtual ICollection<Group> Groups{ get; set; }
        public DateTime Create_Time { get; set; }
    }
}
