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



        //edit 
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var dept = context.Departments.Find(id);
            if(dept is not null)
            {
                return View(dept);
            }
            return RedirectToAction("index");
        }

        //from route => segment
        //from query
        public IActionResult Edit([FromQuery]int id,Department newDept)
        {
            //entity frame work and linq 
            try
            {
                var oldDept = context.Departments.Find(id);
                oldDept.Location = newDept.Location;
                oldDept.Name = newDept.Name;
                context.Update(oldDept);
                context.SaveChanges();
                return RedirectToAction("index");

            }
            catch
            {
                return View(newDept);
            }
           
            
        }



        [HttpGet]
        public IActionResult Delete(int id)
        {
            //soft delete 
            //change properties of relationship
            var dept = context.Departments.Find(id);
            if(dept is not null)
            {
                context.Departments.Remove(dept);
                context.SaveChanges();
                return RedirectToAction("index");
            }
            
            return View();
        }

        //[httpget]


        /*
         * form method get
         * anocher link <a>
         * url
         */
        //[HttpGet]
        //public IActionResult xyz()
        //{
        //    return Content("Ok");
        //}

        ///*form method post*/
        //[HttpPost]
        //public IActionResult xyz(int id)
        //{
        //    return Content("Ok");
        //}


    }
}
