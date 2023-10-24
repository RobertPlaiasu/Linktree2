using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Dto
{
    public class CreateUserDto
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Utilizatorul nu are email!")]
        [EmailAddress(ErrorMessage = "Adresa de email este invalida!")]
        [MaxLength(250,ErrorMessage ="Adresa de email depaseste 250 caractere!")]
        public string Email { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Utilizatorul nu are parola!")]
        [MaxLength(50, ErrorMessage = "Dimensiunea parolei este mai mare de 50 !")]
        [MinLength(8, ErrorMessage = "Dimensiunea parolei este mai mica de 8 !")]
        public string Password { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Utilizatorul nu are nume!")]
        [MaxLength(30, ErrorMessage = "Dimensiunea numelui este mai mare de 30 !")]
        [MinLength(4, ErrorMessage = "Dimensiunea numelui este mai mica de 4 !")]
        public string Name { get; set; }
    }
}
