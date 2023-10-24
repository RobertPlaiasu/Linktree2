using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Entites
{
    public class User
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(AllowEmptyStrings = false)]
        [MaxLength(30)]
        public string Name { get; set; }
        [Required(AllowEmptyStrings = false)]
        [EmailAddress]
        [MaxLength(250)]
        public string Email { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Password { get; set; }
        
    }
}
