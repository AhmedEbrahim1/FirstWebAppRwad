using FirstWebAppRwad.IdentityModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FirstWebAppRwad.Models.Context
{
    public class ApplicationContext:IdentityDbContext<ApplicationUser>
    {
        public ApplicationContext()
        {
            
        }

        public ApplicationContext(DbContextOptions options):base(options)
        {

        }

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("data source=.;initial catalog=DEPI_DB_4;integrated security=true;trustservercertificate=true;");
            base.OnConfiguring(optionsBuilder);
        }


    }
}
