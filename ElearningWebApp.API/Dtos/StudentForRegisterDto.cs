using System;
using System.ComponentModel.DataAnnotations;

namespace ElearningWebApp.API.Dtos
{
    public class StudentForRegisterDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int ClassId { get; set; }
        [Required]
        public string MobileNo { get; set; }
        [Required]
        public string Password { get; set; }
        public DateTime? CreatedDate { get; set; }
        public StudentForRegisterDto()
        {
            this.CreatedDate = DateTime.Now;
        }
    }
}