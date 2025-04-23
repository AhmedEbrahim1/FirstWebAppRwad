using FirstWebAppRwad.Models;
using FirstWebAppRwad.Models.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FirstWebAppRwad.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationContext _context;
        public Guid Id { get; set; }
        public EmployeeRepository(ApplicationContext context)
        {
            //tightly coupled
            _context = context;
            Id = Guid.NewGuid();
        }
        public Employee GetById(int id)
        {
            return _context.Employees.Find(id);
        }
        public IEnumerable<Employee> GetAll()
        {
            return _context.Employees.ToList();
        }
        public void Add(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
        }
        public void Edit(int id, Employee newEmp)
        {
            var oldEmp = GetById(id);
            oldEmp.Name = newEmp.Name;
            oldEmp.Salary = newEmp.Salary;
            oldEmp.Address = newEmp.Address;
            oldEmp.Age = newEmp.Age;
            oldEmp.DeptId = newEmp.DeptId;
            _context.SaveChanges();

        }

        public void Delete(int id)
        {
            var deletedEmp = GetById(id);
            if (deletedEmp is not null)
            {
                _context.Employees.Remove(deletedEmp);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Employee> GetAllWithIncludes(string[] includes)
        {
            var query = _context.Employees;
            if (includes is not null)
            {
                foreach (var include in includes)
                {
                    query.Include(include);
                }
            }

            return query.ToList();
        }


        public IEnumerable<Employee> GetAllWithDept()
        {
            return _context.Employees.Include("Department").ToList(); ;
        }

        public Employee GetObjByFilter(Expression<Func<Employee, bool>> citeria)
        {
            return _context.Employees.Where(citeria).FirstOrDefault();
        }


        public IEnumerable<Employee> GetListByFilter(Expression<Func<Employee, bool>> citeria, string[] includes = null)
        {
            return _context.Employees.Where(citeria).ToList();
        }


    }
}
