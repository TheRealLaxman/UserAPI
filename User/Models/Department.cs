namespace User.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string DepartmentName { get; set; } = string.Empty;
        public ICollection<Users> Users { get; set; } = new List<Users>();
    }
}