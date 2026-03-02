using System.ComponentModel.DataAnnotations;

namespace RazorPages25P3A.Models
{
    public class FormIM
    {
        [EmailAddress]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Password is required.")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be between 6 and 100 characters.")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
    }
}
