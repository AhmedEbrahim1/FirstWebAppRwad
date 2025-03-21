using Microsoft.AspNetCore.Mvc;

namespace FirstWebAppRwad.Controllers
{
    public class PassDataController : Controller
    {

        public IActionResult Index()
        {

            return View();
        }

        public IActionResult GetMessage()
        {
            TempData["msg"] = "Abd el rahman";
            return Content("GetMessage--action");
        }

        public IActionResult FirstReadMessage()
        {
            //will save temp data to another request
            if (TempData.ContainsKey("msg"))
            {
                string name = TempData["msg"].ToString();
                TempData.Keep();

            }
            return Content("FirstReadMessage--action");
        }


        public IActionResult SecondReadMessage()
        {
            //will save temp data to another request
            if (TempData.ContainsKey("msg"))
            {
                string name = TempData.Peek("msg").ToString();
            }
            return Content("FirstReadMessage--action");
        }

        public IActionResult ThirdReadMessage()
        {
            //default behaivour of cookie delete after read
            if (TempData.ContainsKey("msg"))
            {
                string name = TempData["msg"].ToString();
                

            }
            return Content("FirstReadMessage--action");
        }


        public IActionResult SetSession()
        {
            HttpContext.Session.SetString("Name", "youssef");
            HttpContext.Session.SetInt32("Age", 21);
            return Content("Set Session --action");
        }


        public IActionResult GetSession()
        {
            string name = HttpContext.Session.GetString("Name");
            //int? Age = HttpContext.Session.GetInt32("Age");
            int Age = HttpContext.Session.GetInt32("Age").Value;
            return Content("Get Session --action");
        }

        //public IActionResult SetCookie()
        //{
        //    HttpContext.Response.Cookies.Append("name", "Ahmed Rizq");
        //    HttpContext.Response.Cookies.Append("age", "31");
        //    HttpContext.Response.Cookies.Append("job", "instructor");
        //    return Content("SetCookie--action");
        //}
        //public IActionResult GetCookie()
        //{
        //   // HttpContext.Response.Cookies.re
        //    return Content("GetCookie");
        //}


        public IActionResult SetCookie()
        {
            //my app added it and saved on the server
            //Session cookie

            // HttpContext.Response.Cookies.Append()
            HttpContext.Response.Cookies.Append("name", "Ramy");//Expired After 20 M

    
            //Presistent cookie
            CookieOptions options = new CookieOptions();
            options.Expires = DateTime.Now.AddDays(5);
            HttpContext.Response.Cookies.Append("color", "red", options);
            return Content("Session Saved");
        }

        public IActionResult GetCookie()
        {
            //my app added it and saved on the server
            string name = HttpContext.Request.Cookies["name"];
            string color = HttpContext.Request.Cookies["color"];
            return Content($"Get cookies name ={name} , color = {color}");
        }



        //session and cookie 


    }
}
