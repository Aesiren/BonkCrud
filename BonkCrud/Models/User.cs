﻿using System;
using System.Collections.Generic;

namespace BonkCrud.Models
{
    public partial class User
    {
        public int UserId { get; set; }
        public string Username { get; set; } = null!;
    }
}
