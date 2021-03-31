using System;
using System.ComponentModel.DataAnnotations;

namespace ElearningWebApp.API.Dtos
{
    public class StudentForRegisterDto
    {
        [Required]
        public string Name { get; set; }
        public int ClassId { get; set; }
        public string MobileNo { get; set; }
        public string Password { get; set; }
        public DateTime? CreatedDate { get; set; }
        public StudentForRegisterDto()
        {
            this.CreatedDate = DateTime.Now;
        }
    }
}