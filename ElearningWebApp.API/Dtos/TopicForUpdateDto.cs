using System;
using System.ComponentModel.DataAnnotations;

namespace ElearningWebApp.API.Dtos
{
    public class TopicForUpdateDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int ChapterId { get; set; }
        public DateTime? UpdateDate { get; set; }
        public TopicForUpdateDto()
        {
            this.UpdateDate = DateTime.Now;
        }
    }
}