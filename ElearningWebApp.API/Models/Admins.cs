using System;
using System.Collections.Generic;

namespace ELearningWebApp.API.Models
{
    public partial class Admins
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}
