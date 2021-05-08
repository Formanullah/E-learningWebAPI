using ELearningWebApp.API.Models;

namespace ElearningWebApp.API.Dtos
{
    public class StudentForReturnDto
    {
         public int Id { get; set; }
        public string Name { get; set; }
        public int ClassId { get; set; }
        public string ClassName { get; set; }
        public string MobileNo { get; set; }
        public string RoleName { get; set; }

    }
}