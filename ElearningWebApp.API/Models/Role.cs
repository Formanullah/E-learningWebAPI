using System;
using System.Collections.Generic;

namespace ELearningWebApp.API.Models
{
    public partial class Role
    {
        public Role()
        {
            Admins = new HashSet<Admins>();
            Students = new HashSet<Students>();
        }

        public int Id { get; set; }
        public string RoleName { get; set; }

        public virtual ICollection<Admins> Admins { get; set; }
        public virtual ICollection<Students> Students { get; set; }
    }
}
