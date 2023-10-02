using System.ComponentModel.DataAnnotations;

namespace EmployeeAPI.Models.DTO
{
    public class EmployeesCreateDTO
    {
        [Required]
        [MaxLength(30)]
        public string EName { get; set; }
        public string Job { get; set; }
        public int Manager { get; set; }
        public DateTime HireDate { get; set; }
        public double Salary { get; set; }
        public double Comm { get; set; }
        [Required]
        public int DeptNo { get; set; }
    }
}
