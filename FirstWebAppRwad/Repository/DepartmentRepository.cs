using FirstWebAppRwad.Models;
using FirstWebAppRwad.Models.Context;

namespace FirstWebAppRwad.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ApplicationContext _context;
        public DepartmentRepository()
        {
            _context = new ApplicationContext();
        }
        //CRUD OPERATION

        public Department GetById(int id)
        {
            return _context.Departments.Find(id);
        }
        public IEnumerable<Department> GetAll()
        {
            return _context.Departments.ToList();
        }
        public void Add(Department department)
        {
            _context.Departments.Add(department);
            _context.SaveChanges();
        }
        public void Edit(int id, Department newDept)
        {
            var oldDept = GetById(id);
            if (oldDept is not null)
            {
                oldDept.Name = newDept.Name;
                oldDept.Location = newDept.Location;
                _context.SaveChanges();
            }

        }
        public void Delete(int id)
        {
            var deletedDept = GetById(id);
            _context.Departments.Remove(deletedDept);
            _context.SaveChanges();
        }
    }
}
