﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkLesson.model
{
    internal class Song
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
