using Microsoft.EntityFrameworkCore;

namespace FirstWebAppRwad.Models
{
    public class Department
    {
        //identity  == auto increment
        public int Id { get; set; }

        public string? Name { get; set; }
        public string? Location { get; set; }

        public virtual ICollection<Employee>? Employees{ get; set; }
    }
}
