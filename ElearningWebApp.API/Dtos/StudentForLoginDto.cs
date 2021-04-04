using System.ComponentModel.DataAnnotations;

namespace ElearningWebApp.API.Dtos
{
    public class StudentForLoginDto
    {
        [Required]
        public string MobileNo { get; set; }
        [Required]
        public string Password { get; set; }
    }
}