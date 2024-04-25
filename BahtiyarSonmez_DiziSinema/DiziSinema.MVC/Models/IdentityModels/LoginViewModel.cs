using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace DiziSinema.MVC.Models.IdentityModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Boş bırakılamaz")]
        [DisplayName("Kullanıcı Adı")]
        public string UserName { get; set; }


        [Required(ErrorMessage = "Boş bırakılamaz")]
        [DisplayName("Parola")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
