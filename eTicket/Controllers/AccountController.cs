using eTicket.Data;
using eTicket.Data.Static;
using eTicket.Data.ViewModel;
using eTicket.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace eTicket.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly AppDbContext dbContext;
        public AccountController(UserManager<ApplicationUser> _userManager, SignInManager<ApplicationUser> _signInManage, AppDbContext _dbContext)
        {
            userManager = _userManager;
            signInManager = _signInManage;
            dbContext = _dbContext;
        }
        public async Task<IActionResult> User()
        {
            var users =  await dbContext.Users.ToListAsync();
            return View(users);
        }
        public IActionResult Login() => View(new LoginVm());

        [HttpPost] 
        public async Task<IActionResult> Login(LoginVm loginVm)
        {
            if (!ModelState.IsValid) return View(loginVm);

            var user = await userManager.FindByEmailAsync(loginVm.EmailAddress);
            if (user != null)
            {
                var password = await userManager.CheckPasswordAsync(user, loginVm.Password);
                if (password)
                {
                    var result = await signInManager.PasswordSignInAsync(user, loginVm.Password, false, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Movie");
                    }
                    TempData["Error"] = "Wrong Credentials. please try again!";
                    return View(loginVm);
                }

            }
            TempData["Error"] = "Wrong Credentials. please try again!";
            return View(loginVm);
        }


        public IActionResult Register() => View(new RegisterVm());

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVm registerVm)
        {
            if (!ModelState.IsValid) return View(registerVm);

            var user = await userManager.FindByEmailAsync(registerVm.EmailAddress);
            if (user != null)
            {
                TempData["Error"] = "This email is already in used";
                return View(registerVm);
            }

            var newuser = new ApplicationUser()
            {
                FullName = registerVm.FullName,
                Email = registerVm.EmailAddress,
                UserName = registerVm.EmailAddress
            };

            var reponse = await userManager.CreateAsync(newuser, registerVm.Password);
            if (reponse.Succeeded)
                await userManager.AddToRoleAsync(newuser, UserRoles.User);


            return View("RegisterCompleted");
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Movie");
        }
    }
}
