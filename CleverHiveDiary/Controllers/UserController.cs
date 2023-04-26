using CleverHiveDiary.Areas.Admin.Models;
using CleverHiveDiary.Core.ViewModels;
using CleverHiveDiary.Infrastructure.Data;
using CleverHiveDiary.Infrastructure.Data.Models;
using CleverHiveDiary.Infrastructure.Data.Models.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CleverHiveDiary.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;

        private readonly SignInManager<ApplicationUser> signInManager;

        private readonly ApplicationDbContext context;

        private readonly RoleManager<IdentityRole> roleManager;

        public UserController(ApplicationDbContext _context,
            UserManager<ApplicationUser> _userManager,
            SignInManager<ApplicationUser> _signInManager,
            RoleManager<IdentityRole> _roleManager)
        {
            context = _context;
            userManager = _userManager;
            signInManager = _signInManager;
            roleManager = _roleManager;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Register()
        {
            if (!roleManager.RoleExistsAsync(Helper.Admin).GetAwaiter().GetResult())
            {
                await roleManager.CreateAsync(new IdentityRole(Helper.Admin));
                await roleManager.CreateAsync(new IdentityRole(Helper.Doctor));
                await roleManager.CreateAsync(new IdentityRole(Helper.Patient));

            }

            if (User?.Identity?.IsAuthenticated ?? false)
            {
                return RedirectToAction("Index", "Home");
            }

            var model = new RegisterViewModel();

            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = new ApplicationUser()
            {
                Email = model.Email,
                UserName = model.UserName
            };

            var result = await userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                return RedirectToAction("Login", "User");
            }

            foreach (var item in result.Errors)
            {
                ModelState.AddModelError("", item.Description);
            }

            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            if (User?.Identity?.IsAuthenticated ?? false)
            {
                return RedirectToAction("Index", "Home");
            }

            var model = new LoginViewModel();

            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await userManager.FindByEmailAsync(model.Email);

            if (user != null)
            {
                var result = await signInManager.PasswordSignInAsync(user, model.Password, false, false);

                if (user.Id == "u1" && !User.IsInRole("Admin"))
                {
                    await userManager.AddToRoleAsync(user, Helper.Admin);
                }

                if (await userManager.IsInRoleAsync(user, "Admin"))
                {
                    return RedirectToAction("Admin", "Admin", new { area = "Admin" });
                }
                

                return RedirectToAction("Current", "Farm");
            }

            ModelState.AddModelError("", "Invalid login");

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit()
        {
            var user = await userManager.GetUserAsync(User);

            var model = new EditUserViewModel()
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditUserViewModel model)
        {
            var user = await context.Users.FirstOrDefaultAsync(u => u.Id == model.Id);

            user.UserName = model.UserName;
            user.NormalizedUserName = model.UserName.ToUpper();
            user.Email = model.Email;
            user.NormalizedEmail = model.Email.ToUpper();


            await context.SaveChangesAsync();
            return RedirectToAction("Current", "Farm");
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }


        
        //public async Task<bool> IsInRole()
        //{
        //    var user = await userManager.FindByIdAsync("u1");
        //    await userManager.IsInRoleAsync(user, "Admin");

        //    var IsInRole = false;

        //    //var user = await context.Users.FirstOrDefaultAsync(u=> u.Id == "u1");
        //    IsInRole =  await userManager.IsInRoleAsync(user, "Admin");
        //    if (IsInRole)
        //    {
        //        IsInRole=true;
        //    }

        //    return IsInRole;
        //}

        [HttpGet]
        [Area("Admin")]
        public async Task<IActionResult> Admin()
        {
            var users = userManager.Users.ToList();

            var model = new List<UsersViewModel>();

            foreach (var user in users)
            {
                var uvm = new UsersViewModel()
                {
                    Id = user.Id,
                    Email = user.Email,
                    UserName = user.UserName,
                    FarmId = user.FarmId
                };

                model.Add(uvm);
            }

            return View(model);
        }

        [HttpPost]
        [Area("Admin")]
        public async Task<IActionResult> Delete(string userId)
        {
            var user = await context.Users.FindAsync(userId);
            var farm = await context.Farms.FindAsync(user.FarmId);

            foreach (var note in user.Notes)
            {
                context.Notes.Remove(note);
            }

            foreach (var hive in farm.Hives)
            {
                context.Hives.Remove(hive);
            }

            context.Users.Remove(user);
            context.Farms.Remove(farm);
            await context.SaveChangesAsync();
            return RedirectToAction("Admin");

        }
    }
}
