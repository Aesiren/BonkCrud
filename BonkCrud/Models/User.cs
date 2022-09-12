using System;
using System.Collections.Generic;

namespace BonkCrud.Models
{
    public partial class User
    {
        public int UserId { get; set; }
        public string Username { get; set; } = null!;
        public string userFName { get; set; } = null!;
        public string userLName { get; set; } = null!;  
        public string Password { get; set; } = null!;   
    }
}
