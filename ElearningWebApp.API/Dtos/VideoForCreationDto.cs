using System;
using Microsoft.AspNetCore.Http;

namespace ElearningWebApp.API.Dtos
{
    public class VideoForCreationDto
    {
        public bool Isfree { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int SubjectIdInClass { get; set; }
        public int ChapterId { get; set; }
        public int TopicId { get; set; }
        public int ClassId { get; set; }
        public IFormFile File { get; set; }
        public VideoForCreationDto()
        {
            this.CreatedDate = DateTime.Now;
        }
    }
}