using System;
using System.Collections.Generic;

namespace BonkCrud.Models
{
    public partial class Item
    {
        
        public int ItemID { get; }
        public string ItemName { get; set; } = null!;

        public string Detail { get; set; } = null!;

        public int Quantity { get; set; } 

        public int UserID { get; set; }

    }
}
