using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FirstWebAppRwad.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [DisplayName("Emp Name")]
        [Required]
        public string? Name { get; set; }
        public int Age { get; set; }
        public int Salary { get; set; }
        public string? Address { get; set; }

        //navigation property 

        public virtual Department? Department { get; set; }
        [ForeignKey("Department")]
        public int? DeptId { get; set; }
    }
}
