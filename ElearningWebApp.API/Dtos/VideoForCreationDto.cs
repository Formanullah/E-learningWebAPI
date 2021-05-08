using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace ElearningWebApp.API.Dtos
{
    public class VideoForCreationDto
    {
        [Required]
        public bool Isfree { get; set; }
        public DateTime? CreatedDate { get; set; }

        [Required]
        public int TopicId { get; set; }

        [Required]
        public IFormFile File { get; set; }
        public VideoForCreationDto()
        {
            this.CreatedDate = DateTime.Now;
        }
    }
}