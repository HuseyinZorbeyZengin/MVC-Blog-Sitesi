using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace BlogSitesi.Models
{
    public class DataInitializer : DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {

            var kategori = new List<Kategori>()
            {
                new Kategori(){KategoriAdi="Oyun"},
                new Kategori(){KategoriAdi="Sağlık"},
                new Kategori(){KategoriAdi="Teknoloji"}
            };
            foreach (var item in kategori)
            {
                context.Kategoris.Add(item);
            }
            context.SaveChanges();

            var makale = new List<Makale>()
            {
                    new Makale(){Baslik="10 yıl sonra bir kez daha: The Elder Scrolls V Skyrim Mod’lama",Aciklama="“O değil de bir Skyrim vardı, ona ne oldu?” diyen eski kandan mısınız?" +
                    " Veya belki de RPG furyasına çok geç giriş yaptınız, ve bu serinin belki de en popüler ürünü Skyrim’i deneyimlemediniz. " +
                    "Çıkışından bu yana da 10 yıl geçtiğine göre “Artık çok geç," +
                    " oynamam herhalde kötü grafiklerle” diye mi düşünüyorsunuz? O zaman bu yazı tam size göre.",Resim="Skyrim.jpg",
                        YayinTarihi=Convert.ToDateTime("2021-05-01"),GoruntulenmeSayisi=0,Onay=true,KategoriID=1,KullaniciAdi="Zorbey Zengin"},

                    new Makale(){Baslik="Çıkışına günler kala Cyberpunk 2077 hakkında tüm bildiklerimiz!",Aciklama="7 yıl önce duyurulduğundan bu yana gözlerimizi yollarda bırakan, " +
                    "son dönemde de defalarca tekrar ertelenen Cyberpunk 2077, en sonunda 10 Aralık 2020’de piyasaya sürülecek. Peki son yılların belki de en çok beklenen oyunu olan " +
                    "Cyberpunk 2077 hakkında neler biliyoruz?",Resim="CyberPunk.jpg",
                        YayinTarihi=Convert.ToDateTime("2021-03-18"),GoruntulenmeSayisi=0,Onay=true,KategoriID=1,KullaniciAdi="Hüseyin Zengin"},

                     new Makale(){Baslik="Sosyal Fobi",Aciklama="Gözlerinizi kapatın ve bir an için sınıfa girdiğinizi düşünün. " +
                     "İçeride arkadaşlarınız ve öğretmeniniz var. Herkes size şaşkın şaşkın bakıyor. Siz de ne olduğunu anlamadan " +
                     "kafanızı eğdiğinizde bir bakıyorsunuz pantolonunuzu giymeyi unutmuşsunuz. O an çok utanıyorsunuz, yüzünüz" +
                     " kızarıyor, terlemeye başlıyorsunuz, elleriniz titriyor, bir yandan da kalbiniz hızlı hızlı çarpıyor, ardından " +
                     "sanki nefes alamıyor ve ölecek gibi hissediyorsunuz. Hemen oradan uzaklaşmak istiyorsunuz. Tabi utandığınız için " +
                     "de diğer gün o sınıfa tekrar girmek istemiyorsunuz.” İşte sosyal fobisi olan insanların hissettiği" +
                     " ruh hali tam olarak da buna benziyor.",Resim="SosyalFobi.jpg",
                        YayinTarihi=Convert.ToDateTime("2021-01-12"),GoruntulenmeSayisi=0,Onay=true,KategoriID=2,KullaniciAdi="Samet Akbulut"},

                     new Makale(){Baslik="Phishing Saldırısı Nedir? Nasıl korunulur?",Aciklama="Bankanızın, e-postanızın, sosyal medya hesabınızın" +
                     " veya bunun gibi bilgi girmenizi gerektiren bir kuruluşun web sayfasının bir kopyasını oluşturarak kullanıcının hesap" +
                     " bilgilerini çalmayı hedefleyen bir İnternet dolandırıcılığı türüdür. İngilizce 'Balık tutma' anlamına gelen 'Fishing' sözcüğünün 'f' " +
                     "harfinin yerine 'ph' harflerinin konulmasıyla gelen terim, oltayı attığınız zaman en azından bir balık yakalayabileceğiniz " +
                     "düşüncesinden esinlenerek oluşturulmuş.",Resim="PhishingSaldırısı.png",
                        YayinTarihi=Convert.ToDateTime("2021-04-09"),GoruntulenmeSayisi=0,Onay=true,KategoriID=3,KullaniciAdi="Ahmet Çiçek"}
        };
            foreach (var item in makale)
            {
                context.Makales.Add(item);
            }
            context.SaveChanges();

            base.Seed(context);
        }
    }
}