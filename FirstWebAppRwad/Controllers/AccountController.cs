using FirstWebAppRwad.IdentityModels;
using FirstWebAppRwad.Models.Context;
using FirstWebAppRwad.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FirstWebAppRwad.Controllers
{
    public class AccountController : Controller
    {

        private readonly UserManager<ApplicationUser> userManager;

        public SignInManager<ApplicationUser> SignInManager { get; }

        public AccountController(UserManager<ApplicationUser> userManager , SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            SignInManager = signInManager;
        }


        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterViewModel userVM)
        {
            if (ModelState.IsValid)
            {
                //save at data base
                //save user at data base

                ApplicationUser user = new ApplicationUser()
                {
                    UserName = userVM.Name,
                    PasswordHash = userVM.password,
                    Address = userVM.Address
                };

                var registerResult=await userManager.CreateAsync(user,user.PasswordHash);
                if(registerResult.Succeeded)
                {

                    //redierct screen of login
                    await userManager.AddToRoleAsync(user, "Admin");
                    //await signInManger.SignInAsync(user, false);
                    //res = User.Identity.IsAuthenticated;
                    return RedirectToAction("index", "Employee");
                }
                else
                {
                    foreach (var error in registerResult.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    //show error
                }

              
                //UserManager<ApplicationUser> userManager 
                //    =new UserManager<ApplicationUser>()

                //dont create just resolve =>ask 
                //ask for usermanager

            }
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLoginViewModel userLoginVM)
        {
            if(ModelState.IsValid)
            {
                var user = await userManager.FindByNameAsync(userLoginVM.Name);
                if(user is not null)
                {
                    //var validLogin = await userManager.CheckPasswordAsync(user, userLoginVM.Password);
                    var validLogin= await userManager.CheckPasswordAsync(user, "1234");
                    if(validLogin)
                    {
                        //cookie based 
                        await SignInManager.SignInAsync(user, userLoginVM.RemeberMe);
                        return RedirectToAction("index","Employee");
                    }
                    else
                    {
                        ModelState.AddModelError("", "incorrect user name or password");
                    }
                }
            }
            return View();
        }

    }
}
