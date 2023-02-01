using System.ComponentModel.DataAnnotations;

namespace TraversalProject.Models
{
    public class UserRegisterViewModel
    {
        [Required(ErrorMessage ="Lütfen Ad ve Soyadınızı giriniz.* ")]
        public string NameSurname { get; set; }

        [Required(ErrorMessage = "Lütfen Kullanıcı adınızı giriniz.* ")]
        public string UserName { get; set; }

         [Required(ErrorMessage ="Lütfen Mail adresinizi giriniz.* ")]
        public string Mail { get; set; }

        //[Required(ErrorMessage = "Lütfen Telefon numaranızı giriniz. ")]
        //public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Lütfen şifrenizi giriniz.* ")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Lütfen şifrenizi tekrar giriniz.*")]
        [Compare("Password",ErrorMessage ="*-- Şifreler birbiriyle uyuşmuyor tekrar giriniz.! --*")]
        public string ComfirmPassword { get; set; }
    }
}
