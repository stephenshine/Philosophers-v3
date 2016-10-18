using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Philosophers_v3.Models.Entities
{
    public class Philosopher
    {
        // will be primary key
        public int ID { get; set; }
        public string FistName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateOfDeath { get; set; }
        public Boolean IsAlive { get; set; }
        // NationalityID and AreaID will be foreign keys
        public int NationalityID { get; set; }
        public int AreaID { get; set; }
        public string Description { get; set; }
        
        // Navigation properties
        // hold other related entities
        // defined as virtual to take advantage of lazy loading
        public virtual Nationality Nationality { get; set; }
        public virtual Area Area { get; set; }
        public virtual ICollection<Book> Books { get; set; }

    }
}