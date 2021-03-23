using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace ElearningWebApp.API.Dtos
{
    public class SubjectForCreationDto
    {
        [Required]
        public string Name { get; set; }
        // public IFormFile File { get; set; }
        public DateTime? CreatedDate { get; set; }
        public SubjectForCreationDto()
        {
            this.CreatedDate = DateTime.Now;
        }
    }
}