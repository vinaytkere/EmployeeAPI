namespace EmployeeAPI.Models
{
    public class Departments
    {
        public int Id { get; set; }
        public string DName { get; set; }
        public string Location { get; set; }
        public DateTime CreatedDate { get; set; }
        public ICollection<Employees> Employees { get; set; }
    }
}
