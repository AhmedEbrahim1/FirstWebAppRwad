using System.ComponentModel.DataAnnotations;

namespace FirstWebAppRwad.ViewModels
{
    public class UserLoginViewModel
    {
        [Required]
        [MinLength(3)]
        [MaxLength(300)]
        public string Name { get; set; }
        [DataType(DataType.Password)]
        [Required]
        public string Password{ get; set; }
        public bool  RemeberMe { get; set; }
    }
}
