using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Philosophers_v3.Models.Entities
{
    public class Area
    {
        public int ID { get; set; }
        public string AreaName { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}