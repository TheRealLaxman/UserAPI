namespace User.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public int UserId { get; set; }
        public Users User { get; set; } = null!;
    }
}