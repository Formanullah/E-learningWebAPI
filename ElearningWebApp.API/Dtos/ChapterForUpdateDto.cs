using System;
using System.ComponentModel.DataAnnotations;

namespace ElearningWebApp.API.Dtos
{
    public class ChapterForUpdateDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int SubjectForClassId { get; set; }
        public DateTime? UpdateDate { get; set; }

        public ChapterForUpdateDto()
        {
            this.UpdateDate = DateTime.Now;
        }
    }
}