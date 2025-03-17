using Microsoft.AspNetCore.Mvc;

namespace FirstWebAppRwad.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        // http://localhost:5289/Test/getmessage

        //function 

        //action
        public string GetMessage()
        {
            return $"DEPI Students";
        }

        //string    => ContentResult
        //Html =>  ViewResult
        //json =>   JsonResult 
        //JavaScript => JavaScriptResult
        //facebook  =>  RedirectResult
        //File   => FileResult


        //action 

        //http://localhost:5289/test/getmessage2
        public ContentResult GetMessage2()
        {
            //ContentResult result = new ContentResult();
            //result.Content = "DEPI Student";
            //return result;

            return Content("DEPI Student");
        }

        //json 
        //
        public JsonResult GetMessage3()
        {
            //JsonResult result = new JsonResult("{'id'=5}");
            //return result;
            return Json("{'Name':'Ahmed Rizq'}");
        }

        //html 

        public ViewResult GetMessage4()
        {
            //ViewResult result = new ViewResult();
            //result.ViewName = "xyz";
            //return result;

            
            return View("xyz");
        }

        //http://localhost:5289/test/getmixed/2
        public IActionResult GetMixed(int id)
        {
            if(id %2==0)
            {
                return Content("hi");
            }
            else
            {
                return View("xyz");
            }
        }


        public IActionResult GetMessage6()
        {
            //RedirectResult result = new RedirectResult("http://www.google.com");
            //return result;
            return Redirect("http://www.google.com");
        }



    }
}
