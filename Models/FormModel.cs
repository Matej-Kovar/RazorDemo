using System.ComponentModel.DataAnnotations;

namespace RazorPages25P3A.Models
{
    public class FormModel
    {
        public int FormModelId { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
}
