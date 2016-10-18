using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Philosophers_v3.Models.Entities
{
    public class Book
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public int PhilosopherID { get; set; }
        public int AreaID { get; set; }

        public virtual Philosopher Philosopher { get; set; }
        public virtual Area Area { get; set; }
    }
}