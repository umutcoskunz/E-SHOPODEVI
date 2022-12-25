using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EntityLayer.Entities
{
   public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Boş Geçilemez")]
        [Display(Name = "Ad")]
        [StringLength(50, ErrorMessage = "Max 50 karakter olmalıdır. ")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Boş Geçilemez")]
        [Display(Name = "Soyad")]
        [StringLength(50, ErrorMessage = "Max 50 karakter olmalıdır. ")]
        public string Surname { get; set; }

        //[Required(ErrorMessage = "Boş Geçilemez")]
        //[Display(Name = "E-mail")]
        //[StringLength(50, ErrorMessage = "Max 50 karakter olmalıdır. ")]
        //[EmailAddress(ErrorMessage ="E-mail formatı şeklinde giriniz.") ]
        public string Email { get; set; }

        [Required(ErrorMessage = "Boş Geçilemez")]
        [Display(Name = "Kullanıcı Adı")]
        [StringLength(50, ErrorMessage = "Max 50 karakter olmalıdır. ")]
        public string Username { get; set; }

        //[Required(ErrorMessage = "Boş Geçilemez")]
        //[Display(Name = "Şifre")]
        //[StringLength(15, ErrorMessage = "Max 15 karakter olmalıdır. ")]
        //[DataType(DataType.Password)]
        public string Password { get; set; }

        //[Required(ErrorMessage = "Boş Geçilemez")]
        //[Display(Name = "Şifre Tekrar")]
        //[StringLength(15, ErrorMessage = "Max 15 karakter olmalıdır. ")]
        //[DataType(DataType.Password)]
        //[Compare("Password",ErrorMessage ="Şifreler Uyuşmuyor!")]
        public string repassword { get; set; }
        
        [StringLength(15, ErrorMessage = "Max 15 karakter olmalıdır. ")]

        public string Role { get; set; }
    }
}
