using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Dto
{
    public class GetUserDto
    {
        [Required(ErrorMessage = "Utilizatorul nu are id!")]
        public int Id { get; set; }
        [Required(AllowEmptyStrings =false,ErrorMessage = "Utilizatorul nu are nume!")]
        [MaxLength(30, ErrorMessage = "Dimensiunea numelui este mai mare de 30 !")]
        [MinLength(4,ErrorMessage ="Dimensiunea numelui este mai mica de 4 !")]
        public string Name { get; set; }
        [Required(AllowEmptyStrings = false,ErrorMessage = "Utilizatorul nu are email!")]
        [EmailAddress(ErrorMessage = "Adresa de email este invalida!")]
        [MaxLength(250)]
        public string Email { get; set; }
    }
}
