using CleverHiveDiary.Areas.Admin.Models;
using CleverHiveDiary.Infrastructure.Data;
using CleverHiveDiary.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CleverHiveDiary.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly UserManager<ApplicationUser> userManager;

        public AdminController(ApplicationDbContext _context, UserManager<ApplicationUser> _userManager)
        {
            context = _context;
            userManager = _userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Admin()
        {
            var users = await context.Users.Include(f => f.Farm).ToListAsync();

            var model = new List<UsersViewModel>();

            foreach (var user in users) 
            { 
                var uvm = new UsersViewModel()
                { 
                    Id = user.Id,
                 Email = user.Email,
                 UserName = user.UserName,
                 FarmId = user.FarmId,
                };     
                
                model.Add(uvm);
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string userId)
        {
            var user = await context.Users.FindAsync(userId);
            var farm = await context.Farms.FirstOrDefaultAsync(f=>f.UserId== userId);

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
