namespace BonkCrud.Model
{
    public partial class User
    {
        public User()
        {
            Items = new HashSet<Item>();
        }

        public int UserId { get; set; }
        public string UserFname { get; set; } = null!;
        public string UserLname { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;

        public virtual ICollection<Item> Items { get; set; }
    }
}
