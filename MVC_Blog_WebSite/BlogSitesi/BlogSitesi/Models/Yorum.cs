using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogSitesi.Models
{
    public class Yorum
    {
        public int ID { get; set; }
        public string Aciklama { get; set; }
        public string KullaniciID { get; set; }
        public DateTime Tarih { get; set; }
        public float Puan { get; set; }
        public int MakaleID { get; set; }
        public virtual Makale Makale { get; set; }

    }
}