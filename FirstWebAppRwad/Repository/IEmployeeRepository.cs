using FirstWebAppRwad.Models;
using System.Linq.Expressions;

namespace FirstWebAppRwad.Repository
{
    public interface IEmployeeRepository
    {
        public Guid Id { get; set; }
        void Add(Employee employee);
        void Delete(int id);
        void Edit(int id, Employee newEmp);
        IEnumerable<Employee> GetAll();
        IEnumerable<Employee> GetAllWithDept();
        IEnumerable<Employee> GetAllWithIncludes(string[] includes);
        Employee GetById(int id);
        IEnumerable<Employee> GetListByFilter(Expression<Func<Employee, bool>> citeria, string[] includes = null);
        Employee GetObjByFilter(Expression<Func<Employee, bool>> citeria);
    }
}