using System.ComponentModel.DataAnnotations;

namespace FirstWebAppRwad.ViewModels
{
    public class UserRegisterViewModel
    {
        [Required]
        [MinLength(3)]
        [MaxLength(350)]
        public string  Name { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(password),ErrorMessage ="password not the same ya 3m el 7ag")]
        public string confirmPassword { get; set; }
        [Required]
        [MaxLength(350)]
        public string  Address { get; set; }
    }
}
