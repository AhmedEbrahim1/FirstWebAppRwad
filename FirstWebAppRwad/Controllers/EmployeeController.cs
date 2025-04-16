using FirstWebAppRwad.Models;
using FirstWebAppRwad.Models.Context;
using FirstWebAppRwad.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

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
            EmployeeWithColorAndMessageAndNameAndBranchesViewModel viewModel = new();
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
        public IActionResult Create(Employee newEmp)
        {
            if (ModelState.IsValid == true)

            //if(newEmp.Name !=null &&newEmp.Name.Length>=3&&newEmp.Name.Length<=20 &&newEmp.Age!=0&&newEmp.Salary!=0&&newEmp.Address!=null&&newEmp.DeptId!=null)
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


        public IActionResult dummyView()
        {
            return View();
        }


        public IActionResult CheckSalary(int salary, string name)
        {
            if (salary < 10000)
            {
                return Json(false);
            }
            return Json(true);
        }

        public IActionResult checkUniqueName(string name, int id)
        {
            var emps = context.Employees.Where(x => x.Name == name).FirstOrDefault();
            var empId = context.Employees.Find(id);
            if (emps == null ||empId is not null)
                return Json(true);
            else
                return Json(false);
        }

        public IActionResult getEmpbyId(int id)
        {
            var emp = context.Employees.Find(id);
            return View(emp);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var oldEmp = context.Employees.Find(id);
            var depts = context.Departments.ToList();
            ViewData["depts"] = depts;
            return View(oldEmp);
        }
        [HttpPost]
        public IActionResult Edit(int id, Employee editEmp)
        {
            if (ModelState.IsValid)
            {
                //var oldEmp = context.Employees.Find(id);
                //oldEmp.Name = editEmp.Name;
                //oldEmp.Address = editEmp.Address;
                //oldEmp.Age = editEmp.Age;
                //oldEmp.Salary = editEmp.Salary;
                //oldEmp.DeptId = editEmp.DeptId;
                var myState = context.Entry(editEmp).State;
                context.Entry(editEmp).State = EntityState.Modified;
                context.Employees.Update(editEmp);
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                var depts = context.Departments.ToList();
                ViewData["depts"] = depts;
                return View(editEmp);
            }
        }

        public IActionResult GetEmpByIdUsingPartial(int id)
        {
            var emp = context.Employees.FirstOrDefault(x => x.Id == id);
            return PartialView(emp);
        }
        public IActionResult GetEmpByIdUsingModal (int id)
        {
            var emp = context.Employees.FirstOrDefault(x => x.Id == id);
            return PartialView(emp);
        }

        [HttpGet]
        public IActionResult EditByModal(int id)
        {
            var oldEmp = context.Employees.FirstOrDefault(e => e.Id == id);
            var depts = context.Departments.ToList();
            ViewData["depts"] = depts;
            return PartialView(oldEmp);
        }
    }
}
