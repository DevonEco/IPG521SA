using IPG521_SA.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace IPG521_SA.Data
{
    public class PapersDbContext : DbContext
    {
        public PapersDbContext()
            : base("PaperConnection")
        { }
        public DbSet<Papers> Papers { get; set; }
        public DbSet<Topics> Topics { get; set; }
    }
}