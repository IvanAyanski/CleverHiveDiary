using CleverHiveDiary.Core.Contracts;
using CleverHiveDiary.Core.Services;
using CleverHiveDiary.Core.ViewModels.Farm;
using CleverHiveDiary.Infrastructure.Data;
using CleverHiveDiary.Infrastructure.Data.Models;
using CleverHiveDiary.Models;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace CleverHiveDiary.Controllers
{
    public class FarmController : Controller
    {
        //private readonly ICarService carService;
        private readonly ApplicationDbContext context;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IFarmService farmService;

        public FarmController(ApplicationDbContext _context, UserManager<ApplicationUser> _userManager, IFarmService _farmService)
        {
            context = _context;
            userManager = _userManager;
            farmService = _farmService;
        }

        [HttpGet]
        public async Task<IActionResult> Current()
        {
            var user = await userManager.GetUserAsync(User);
            var farm = await context.Farms.FirstOrDefaultAsync(f => f.UserId == user.Id);

           

            var model = new FarmViewModel();
            if (farm == null)
            {
                return RedirectToAction("Add"); ;

            }
            else
            {
                
                var count = await context.Hives.CountAsync(h => h.FarmId == farm.Id);

                model = new FarmViewModel()
                {
                    Id = farm.Id,
                    Name = farm.Name,
                    Location = farm.Location,
                    Capacity = count
                };
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new AddFarmViewModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddFarmViewModel model)
        {
            var user = await userManager.GetUserAsync(User);

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await farmService.CreateFarmAsync(model, user.Id);
                var farm = await context.Farms.FirstOrDefaultAsync(u=> u.UserId == user.Id);
                await farmService.LinkUserToFarm(user.Id, farm.Id);
                return RedirectToAction("Current");
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Нещо се счупи");
                return View(model);
            }

        }

        [HttpGet]
        public async Task<IActionResult> Edit(int farmId)
        { 
         var farm = await context.Farms.FindAsync(farmId);

            var model = new EditFarmViewModel() 
            { 
            Id = farm.Id,
            Name = farm.Name,
            Location = farm.Location
            };
        
        return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int farmId, EditFarmViewModel model)
        {
            await farmService.Edit(model, farmId);
            return RedirectToAction(nameof(Current));
        
        }
    }
}