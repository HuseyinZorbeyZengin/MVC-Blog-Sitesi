using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogSitesi.Models
{
    public class ProfilGüncelleme
    {
        public string ID { get; set; }

        [Required]
        [DisplayName("Adınız")]
        public string Name { get; set; }
        [Required]
        [DisplayName("Soyadınız")]
        public string SurName { get; set; }
        [Required]
        [DisplayName("Kullanıcı Adınız")]
        public string UserName { get; set; }
        [Required]
        [DisplayName("Adınız")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-mail adresi giriniz...")]
        public string Email { get; set; }

    }
}