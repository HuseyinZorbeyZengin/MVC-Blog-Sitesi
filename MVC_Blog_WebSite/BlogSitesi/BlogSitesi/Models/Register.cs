using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogSitesi.Models
{
    public class Register
    {
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
        [DisplayName("E-mail Adresiniz")]
        [EmailAddress(ErrorMessage = "Geçersiz e-posta adresi...")]
        public string Email { get; set; }
        [Required]
        [DisplayName("Şifreniz")]
        [StringLength(10, MinimumLength = 5, ErrorMessage = "Şifreniz en fazla 10 en az 5 karakter olmalıdır...")]
        public string Password { get; set; }
        [Required]
        [DisplayName("Şifre Tekrar")]
        [Compare("Password", ErrorMessage = "Şifre tekrarı, şifreniz ile aynı olmalıdır...")]
        public string RePassword { get; set; }
    }
}