using FirstWebAppRwad.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstWebAppRwad.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        // action   getstudentById  
        //http://localhost:5289/studnt/getstudntbyid/2
        public IActionResult GetStudentById(int id)
        {
            var allStudent = StudentList.Students;
            var myStd = allStudent.FirstOrDefault(x => x.Id == id);

            //return View("GetStudentById");

            return View("GetStudentById", myStd);

        }

        //action 

        //return student 
        //view 

        public IActionResult GetAllStudents()
        {
            var all = StudentList.Students;
            return View("GetAll", all);
        }


    }
}
