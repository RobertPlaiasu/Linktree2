using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Dto
{
    public class UpdateUserDto
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Utilizatorul nu are nume!")]
        [MaxLength(30, ErrorMessage = "Dimensiunea numelui este mai mare de 30 !")]
        [MinLength(4, ErrorMessage = "Dimensiunea numelui este mai mica de 4 !")]
        public string Name { get; set; }
    }
}
