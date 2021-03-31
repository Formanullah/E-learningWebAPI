using System;
using System.Collections.Generic;

namespace ELearningWebApp.API.Models
{
    public partial class Students
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ClassName { get; set; }
        public string MobileNo { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int RoleId { get; set; }
        public int ClassId { get; set; }

        public virtual Class Class { get; set; }
        public virtual Role Role { get; set; }
    }
}
