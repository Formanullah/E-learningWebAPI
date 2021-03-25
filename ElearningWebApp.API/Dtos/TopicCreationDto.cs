using System;
using System.ComponentModel.DataAnnotations;

namespace ElearningWebApp.API.Dtos
{
    public class TopicCreationDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int ChapterId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public TopicCreationDto()
        {
            this.CreatedDate = DateTime.Now;
        }
    }
}