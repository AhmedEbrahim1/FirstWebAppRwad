using FirstWebAppRwad.Models;

namespace FirstWebAppRwad.Repository
{
    public interface IDepartmentRepository
    {
        void Add(Department department);
        void Delete(int id);
        void Edit(int id, Department newDept);
        IEnumerable<Department> GetAll();
        Department GetById(int id);
    }
}