namespace User.Models
{
    public class Users
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int Age { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; } = null!;
        public Address Address { get; set; } = null!;

    }
}
