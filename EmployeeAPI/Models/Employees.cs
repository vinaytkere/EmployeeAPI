using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeAPI.Models
{
    public class Employees
    {
        public int Id { get; set; }
        public string EName { get; set; }
        public string Job { get; set; }
        public int Manager { get; set; }
        public DateTime HireDate { get; set; }
        public double Salary { get; set; }
        public double Comm { get; set; }
        [ForeignKey("Departments")]
        public int DeptNo { get; set; }
        public Departments Departments { get; set; }
    }
}
