using FirstWebAppRwad.Models;
using FirstWebAppRwad.Models.Context;
using Microsoft.AspNetCore.Mvc;

namespace FirstWebAppRwad.Controllers
{
    public class DepartmentController : Controller
    {
        ApplicationContext context = new ApplicationContext();
        public DepartmentController()
        {
            
        }
        //http://localhost:5289/Department/Index
        public IActionResult Index()
        {
            var allDepts = context.Departments.ToList();
            return View(allDepts);
        }

        //action just for return view of the form 
        public IActionResult New()
        {
            return View(new Department());
        }

        // need another action to take binded data and operate it

        public IActionResult CreateNew(Department department)
        {
            if(department.Name !=null &&department.Location != null)
            {
                context.Departments.Add(department);
                context.SaveChanges();
                //after success go to index
                //var depts = context.Departments.ToList();
                //return View("Index",depts);
                //instead of these two steps 
                return RedirectToAction("index");
            }
            else
            {
                return View("New",department);

            }
                
        }


        
    }
}
