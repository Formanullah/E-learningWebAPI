using System;
using System.ComponentModel.DataAnnotations;

namespace ElearningWebApp.API.Dtos
{
    public class SubjectForUpdateDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime? UpdateDate { get; set; }
        public SubjectForUpdateDto()
        {
            this.UpdateDate = DateTime.Now;
        }
    }
}