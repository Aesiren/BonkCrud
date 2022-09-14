namespace BonkCrud.Model
{
    public class Item
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; } = null!;
        public string Detail { get; set; } = null!;
        public int Quantity { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; } = null!;
    }
}
