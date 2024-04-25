using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SalesUp.Shared.ViewModels.IdentityModels;

public class RegisterViewModel
{
    [DisplayName("Ad")]
    [Required(ErrorMessage ="Lütfen ad alanını boş bırakmayınız.")]
    public string FirstName { get; set; }

    [DisplayName("Soyad")]
    [Required(ErrorMessage = "Lütfen soyad alanını boş bırakmayınız.")]
    public string LastName { get; set; }

    [DisplayName("Kullanıcı Adı")]
    [Required(ErrorMessage = "Lütfen Kullanıcı adı alanını boş bırakmayınız.")]
    public string UserName { get; set; }

    [DisplayName("Email")]
    [Required(ErrorMessage = "Lütfen email alanını boş bırakmayınız.")]
    [DataType(DataType.EmailAddress,ErrorMessage ="Lütfen geçerli bir email adresi giriniz.")]
    public string Email { get; set; }
        
    [DisplayName("Adres")]
    [Required(ErrorMessage = "{0} alanı boş bırakılamaz!")]
    public string Address { get; set; }
    
    [DisplayName("Cinsiyet")]
    [Required(ErrorMessage = "{0} alanı boş bırakılamaz!")]
    public string Gender { get; set; }

    [DisplayName("Parola")]
    [Required(ErrorMessage = "Lütfen parola alanını boş bırakmayınız.")]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [DisplayName("Parola Tekrar")]
    [Required(ErrorMessage = "Lütfen parola tekrar alanını boş bırakmayınız.")]
    [DataType(DataType.Password)]
    [Compare("Password",ErrorMessage ="Parolalar eşleşmiyor, kontrol ediniz.")]
    public string RePassword { get; set; }

    [DisplayName("Şehir")]
    [Required(ErrorMessage = "Lütfen şehir alanını boş bırakmayınız.")]
    public string City { get; set; }

    [DisplayName("Doğum Tarihi")]
    [Required(ErrorMessage = "Lütfen tarih alanını boş bırakmayınız.")]
    public DateTime? DateofBirth { get; set; }
}