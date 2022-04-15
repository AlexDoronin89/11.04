using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameworkHomework2.Model
{
    public class Performer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public DateTime Birthday { get; set; }
    }
}
