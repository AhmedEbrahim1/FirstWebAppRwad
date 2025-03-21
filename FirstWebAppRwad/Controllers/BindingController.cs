using FirstWebAppRwad.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstWebAppRwad.Controllers
{
    public class BindingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //primitive data type  int float decimal string ....
        //array
        //collection dictionary
        //complex data type

        //query string 
        //http://localhost:1234/Binding/TestPrimitive?id=10&name=amira&age=25

        //query string + segment
        //http://localhost:1234/binding/testprimitive/5?name=ahmed&age=30
        public IActionResult TestPrimitive(int Id , string name, int age,int salary)
        {

            return Content("OK");
        }

        //http://localhost:12345/binding/testArray?color=red&color=blue&color=orange
        //color[0]=red , color[1]=blue , color[2]=orange
        //http://localhost:1234/binding/testarray?color[2]=yellow&color[0]=red&color[1]=blue
        public IActionResult TestArray(string[] color)
        {
            return Content("OK");
        }

        //dictionary

        //http://localhost:1234/binding/testdictionary?name=amira&phone[amira]=1234&phone[youssef]=6789
        public IActionResult TestDictionary(string name , Dictionary<string ,int> phone)
        {
            phone["amira"] = 1234;
            return Content("Ok");
        }

        //http://localhost:1234/binding/testcomplex?id=1&name=ahmed&age=25&salary=15000&address=cairo


        //http://localhost:1234/binding/testcomplex?employee.Id=1&employee.Name=ahmed&employee.Age=25&employee.Salary=15000&employee.Address=cairo


        //http://localhost:1234/binding/testcomplex?id=1&name=ahmed&age=25&salary=15000&address=cairo&Department.Name=sd
        public IActionResult TestComplex(Employee employee)
        {
            employee.Name = "Ahmed";
            return Content("Ok");
        }

        //http://lcocalhost:1234/binding?id=5&name=hr&employees[0].id=100   (correct)


       
        //http://lcocalhost:1234/binding?id=5&name=hr&employees.id=100   ( not correct)
        public IActionResult TestComplexV02(Department department)
        {
            return Content("Ok");

        }

    }
}
