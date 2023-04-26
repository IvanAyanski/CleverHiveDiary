using CleverHiveDiary.Core.Contracts;
using CleverHiveDiary.Core.ViewModels.Farm;
using CleverHiveDiary.Infrastructure.Data;
using CleverHiveDiary.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleverHiveDiary.Core.Services
{
    public class FarmService : IFarmService
    {
        private readonly ApplicationDbContext context;

        public FarmService(ApplicationDbContext _context)
        {
            context = _context;
        }

        public async Task CreateFarmAsync(AddFarmViewModel model, string userId)
        {
            var newFarm = new Farm()
            { 
             Name = model.Name,
             Capacity = model.Capacity,
             Location = model.Location,
             UserId = userId
             // hives?
            };

           context.Farms.Add(newFarm);
           await context.SaveChangesAsync();
        }

        public async Task Edit(EditFarmViewModel model, int farmId)
        {
            var farm = await context.Farms.FirstOrDefaultAsync(x => x.Id == farmId);

            farm.Name = model.Name;
            farm.Location = model.Location;
            
            await context.SaveChangesAsync();
        }

        public async Task<FarmViewModel> GetUserFarm(string userId)
        {
            var farm = await context.Farms.FirstOrDefaultAsync(x => x.UserId == userId);
            var model = new FarmViewModel() { 
            Name = farm.Name,
            Capacity = farm.Capacity,
            Location = farm.Location,
            Id = farm.Id
            };

            return model;
        }

        public async Task LinkUserToFarm(string userId, int farmId)
        {
            var user = await context.Users.FindAsync(userId);

            user.FarmId = farmId;
            await context.SaveChangesAsync();
        }
    }
}
