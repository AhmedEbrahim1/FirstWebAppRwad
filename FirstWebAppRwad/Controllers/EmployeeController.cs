using FirstWebAppRwad.Models;
using FirstWebAppRwad.Models.Context;
using FirstWebAppRwad.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FirstWebAppRwad.Controllers
{
    public class EmployeeController : Controller
    {
        ApplicationContext context = new ApplicationContext();

        //Recommended

        public EmployeeController()
        {
            
        }
        public IActionResult Index()
        {
            var emps = context.Employees.Include(x => x.Department).ToList();
            //return View("Index");
            //return View();
            //return View("index", emps);
            return View(emps);
        }

        //Employee/GetById
        public IActionResult GetById(int id)
        {
            //send data additional 

            string color = "red";
            string Message = "hello world";
            string name = "Ahmed Rizq";

         
            List<string> branches = new List<string>()
            {
                "Cairo", "Assuit","Mansoura"
            };
            //to send aditional data from controller to view
            //ViewData["color"] = "blue";
            //ViewData["Message"] = Message;
            //ViewData["name"] = name;
            //ViewData["branches"] = branches;

            ViewBag.color = "red";
            ViewBag.Message = "My Message";
            ViewBag.name = name;
            ViewBag.branches = branches;

            ViewData["name"] = "youssef";

            var emp = context.Employees.Find(id);

            #region Deal With View Model
            EmployeeWithColorAndMessageAndNameAndBranchesViewModel viewModel =new();
            viewModel.Name = "youssef";
            viewModel.Color = "red";
            viewModel.Message = "this is my new Message";
            viewModel.Branches = branches;
            viewModel.Employee = emp;
            #endregion
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var depts = context.Departments.ToList();
            ViewData["depts"] = depts;
            return View(new Employee());
        }

        [HttpPost]
        public IActionResult Create(Employee newEmp )
        {
            if(ModelState.IsValid)
           // if(newEmp.Name !=null &&newEmp.Age!=0&&newEmp.Salary!=0&&newEmp.Address!=null&&newEmp.DeptId!=null)
            {
                context.Employees.Add(newEmp);
                context.SaveChanges();
                return RedirectToAction("index");
            }
            else
            {
                var depts = context.Departments.ToList();
                ViewData["depts"] = depts;
                return View(newEmp);
            }
                
        }
    }
}
