using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Philosophers_v3.Models.Entities;

namespace Philosophers_v3.Models.DataAccess
{
    public class PhilosopherLibraryContext : DbContext
    {
        public PhilosopherLibraryContext() : base("PhilosopherLibraryContext") { }

        // Entity set corresponds to table in DB
        // Row in table is an entity
        public DbSet<Philosopher> Philosophers { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<Nationality> Nationalities { get; set; }
        public DbSet<Book> Books { get; set; }
    }
}