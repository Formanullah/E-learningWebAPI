using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace ElearningWebApp.API.Dtos
{
    public class SubjectForClassUpdateDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int SubjectId { get; set; }
        [Required]
        public int ClassId { get; set; }
        public IFormFile SubjectImage { get; set; }
        public DateTime? UpdateDate { get; set; }
        public SubjectForClassUpdateDto()
        {
            UpdateDate = DateTime.Now;
        }

    }
}