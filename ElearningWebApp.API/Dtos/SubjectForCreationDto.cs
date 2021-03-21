using Microsoft.AspNetCore.Http;

namespace ElearningWebApp.API.Dtos
{
    public class SubjectForCreationDto
    {
        public string Name { get; set; }
        public IFormFile File { get; set; }
    }
}