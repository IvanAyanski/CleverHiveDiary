using CleverHiveDiary.Core.Services;
using CleverHiveDiary.Infrastructure.Data;
using CleverHiveDiary.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CleverHiveDiary.Core.Services;
using CleverHiveDiary.Core.Contracts;
using CleverHiveDiary.Core.ViewModels.Hive;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CleverHiveDiary.Controllers
{
    public class HiveController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;

        private readonly ApplicationDbContext context;

        private readonly IHiveService hiveService;

        public HiveController(IHiveService _hiveService, ApplicationDbContext _context, UserManager<ApplicationUser> _userManager)
        {
            context = _context;
            userManager = _userManager;
            hiveService = _hiveService;
        }


        [HttpGet]
        public async Task<IActionResult> All()
        {
            var user = await userManager.GetUserAsync(User);

            var farm = await context.Farms.FirstOrDefaultAsync(f => f.UserId == user.Id);

            var model = await hiveService.GetAllHivesAsync(farm);

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new AddHiveViewModel()
            {
                statusHives = await hiveService.GetHiveStatusAsync()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddHiveViewModel model)
        {
            var user = await userManager.GetUserAsync(User);

            var farm = await context.Farms.FirstOrDefaultAsync(f => f.UserId == user.Id);

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await hiveService.AddHiveAsync(model, farm.Id);
                return RedirectToAction("All");
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Нещо се счупи");
                return View(model);
            }
        }

      
        [HttpPost]
        public async Task<IActionResult> Delete(int hiveId)
        {
            await hiveService.DeleteHiveFromFarm(hiveId);
            return RedirectToAction("All");

        }

        [HttpGet]
        public async Task<IActionResult> Edit(int hiveId)
        {
            var hive = await context.Hives.FindAsync(hiveId);

            //var status = await context.statusHives.FirstOrDefaultAsync(s => s.Id == hive.StatusId);

            var model = new EditHiveViewModel()
            {
                Id = hive.Id,
                Name = hive.Name,
                Production = hive.Production,
                Floors = hive.Floors,
                Discription = hive.Discription,
                statusHives = await hiveService.GetHiveStatusAsync()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int hiveId, EditHiveViewModel model)
        {
            await hiveService.Edit(hiveId, model);

            return RedirectToAction(nameof(All));
        }

        [HttpPost]
        public async Task<IActionResult> Detail(int hiveId)
        {
            var hives = await context.Hives.Include(s => s.Status).ToListAsync();

            var hive = hives.FirstOrDefault(h => h.Id == hiveId);

            var model = new HiveViewModel()
            {
                Name = hive.Name,
                Production = hive.Production,
                Discription = hive.Discription,
                Status = hive?.Status.Name,
                Floors = hive.Floors
            };

            return View("Detail", model);
        }
    }
}
