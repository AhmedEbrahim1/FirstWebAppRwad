using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FirstWebAppRwad.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [DisplayName("Emp Name")]
        [Required(ErrorMessage ="this filed is required ya hamada")]
        [MinLength(3,ErrorMessage ="name must be at least 3 character")]
        [MaxLength(20,ErrorMessage ="maximum lenght is 20 character")]
        public string? Name { get; set; }
        [Required]
        [Range(20,65)]
        public int Age { get; set; }
        [Required]
        [Range(5000,65000)]
        public int Salary { get; set; }
        //gharbia-mahalla
        [RegularExpression(@"\w+-\w+",ErrorMessage ="address should start with governerte name - city name for example cairo-nasrcity")]
        public string? Address { get; set; }

        //navigation property 

        public virtual Department? Department { get; set; }
        [ForeignKey("Department")]
        public int? DeptId { get; set; }
    }
}
