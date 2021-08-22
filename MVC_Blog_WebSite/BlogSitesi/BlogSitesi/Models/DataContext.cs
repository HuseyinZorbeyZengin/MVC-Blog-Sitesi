using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BlogSitesi.Models
{
    public class DataContext : DbContext
    {
        public DataContext() : base("dataConnection")
        {
            Database.SetInitializer(new DataInitializer());
        }
        public DbSet<Makale> Makales { get; set; }
        public DbSet<Kategori> Kategoris { get; set; }
        public DbSet<Yorum> Yorums { get; set; }
    }
}