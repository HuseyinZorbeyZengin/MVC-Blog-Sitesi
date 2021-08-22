using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogSitesi.Models
{
    public class SifreDegistirme
    {
        [Required]
        [DisplayName("Eski Şifreniz")]
        public string OldPassword { get; set; }
        [Required]
        [StringLength(10, MinimumLength = 5, ErrorMessage = "Şifreniz en az 5 en fazla 10 karakter olmalıdırr.")]
        [DisplayName("Yeni Şifre")]
        public string NewPassword { get; set; }
        [Required]
        [DisplayName("Şifre Tekrar")]
        [Compare("NewPassword",ErrorMessage ="Şifreler aynı değil...")]
        public string ConNewPassword { get; set; }
    }
}