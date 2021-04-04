using System.ComponentModel.DataAnnotations;

namespace ElearningWebApp.API.Dtos
{
    public class AdminAddDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }
    }
}