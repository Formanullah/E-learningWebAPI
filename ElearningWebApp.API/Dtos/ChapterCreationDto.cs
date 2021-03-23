using System;
using System.ComponentModel.DataAnnotations;

namespace ElearningWebApp.API.Dtos
{
    public class ChapterCreationDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int SubjectForClassId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public ChapterCreationDto()
        {
            this.CreatedDate = DateTime.Now;
        }
    }
}