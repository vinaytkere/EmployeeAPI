namespace EmployeeAPI.Models.DTO
{
    public class EmployeesDTO
    {
        public int Id { get; set; }
        public string EName { get; set; }
        public string Job { get; set; }
        public int Manager { get; set; }
        public DateTime HireDate { get; set; }
        public double Salary { get; set; }
        public double Comm { get; set; }
        public int DeptNo { get; set; }
    }
}
