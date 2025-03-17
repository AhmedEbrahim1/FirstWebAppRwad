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

        //public static IActionResult Index2()
        //{
        //    var allDepts = context.Departments.ToList();
        //    return View(allDepts);
        //}


    }
}
