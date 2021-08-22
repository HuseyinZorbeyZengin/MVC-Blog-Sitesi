using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogSitesi.Models
{
    public class Kategori
    {
        public int ID { get; set; }
        public string KategoriAdi { get; set; }
        public List<Makale> Makaleler { get; set; }
    }
}