using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeAPI.Models.DTO
{
    public class EmployeesUpdateDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string EName { get; set; }
        public string Job { get; set; }
        public int Manager { get; set; }
        public DateTime HireDate { get; set; }
        [Required]
        public double Salary { get; set; }
        public double Comm { get; set; }
        [Required]
        public int DeptNo { get; set; }
    }
}
