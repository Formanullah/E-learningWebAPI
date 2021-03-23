using System;
using System.ComponentModel.DataAnnotations;

namespace ElearningWebApp.API.Dtos
{
    public class SubjectForClassCreationDto
    {
        [Required]
        public string SubjectName { get; set; }
        [Required]
        public int SubjectId { get; set; }
        [Required]
        public int ClassId { get; set; }
        public DateTime CreatedDate { get; set; }
        public SubjectForClassCreationDto()
        {
            this.CreatedDate = DateTime.Now;
        }
    }
}