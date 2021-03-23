using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace ElearningWebApp.API.Dtos
{
    public class SubjectForClassCreationDto
    {
        [Required]
        public int SubjectId { get; set; }
        [Required]
        public int ClassId { get; set; }
        [Required]
        public IFormFile SubjectImage { get; set; }
        public DateTime? CreatedDate { get; set; }
        public SubjectForClassCreationDto()
        {
            this.CreatedDate = DateTime.Now;
        }
    }
}