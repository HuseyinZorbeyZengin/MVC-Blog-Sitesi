using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogSitesi.Models
{
    public class Makale
    {
        public int ID { get; set; }
        public string KullaniciAdi { get; set; }
        public string Baslik { get; set; }
        public string Aciklama { get; set; }
        public string Resim { get; set; }
        public int GoruntulenmeSayisi { get; set; }
        public DateTime YayinTarihi { get; set; }
        public bool Onay { get; set; }
        public int KategoriID { get; set; }
        public Kategori Kategori { get; set; }
        public virtual ICollection<Yorum> Yorum { get; set; }
    }
}