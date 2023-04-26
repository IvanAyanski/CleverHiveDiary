using CleverHiveDiary.Core.Contracts;
using CleverHiveDiary.Core.ViewModels.Hive;
using CleverHiveDiary.Infrastructure.Data;
using CleverHiveDiary.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleverHiveDiary.Core.Services
{
    public class HiveService : IHiveService
    {
        private readonly ApplicationDbContext context;

        public HiveService(ApplicationDbContext _context)
        {
            context = _context;
        }

        public async Task AddHiveAsync(AddHiveViewModel model, int farmId)
        {
            var hive = new Hive()
            {
                Name = model.Name,
                Production = model.Production,
                StatusId = model.StatusId,
                FarmId = farmId,
                Floors = model.Floors,
                Discription = model.Discription
            };

            await context.Hives.AddAsync(hive);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<HiveViewModel>> GetAllHivesAsync(Farm curFarm)
        {
            var farm = await context.Farms
        .Include(f => f.Hives)
        .ThenInclude(f => f.Status)
        .FirstOrDefaultAsync(f => f.Id == curFarm.Id);

            var hiveViewModels = farm.Hives.Select(h => new HiveViewModel
            {
                Id = h.Id,
                Name = h.Name,
                Status = h?.Status?.Name,
                Production = h.Production,
                Floors= h.Floors,
                Discription = h.Discription
            }).ToList();

            return hiveViewModels;

        }

        public async Task<IEnumerable<StatusHive>> GetHiveStatusAsync()
        {
            return await context.statusHives.ToListAsync();
        }

        public async Task DeleteHiveFromFarm(int hiveId)
        {
            var hive = context.Hives.FirstOrDefault(h => h.Id == hiveId);
            context.Hives.Remove(hive);

            await context.SaveChangesAsync();
        }

        public async Task Edit(int hiveId, EditHiveViewModel model)
        {
            var hive = await context.Hives.FindAsync(hiveId);

            hive.Name = model.Name;
            hive.Production = model.Production;
            hive.StatusId = model.StatusId;
            hive.Floors = model.Floors;
            hive.Discription = model.Discription;

            await context.SaveChangesAsync();
        }

        public async Task<int> GetHiveStatusId(int hiveId)
        {
            var hive = await context.Hives.FindAsync(hiveId);
            var status = await context.statusHives.FirstOrDefaultAsync(s => s.Id == hive.StatusId);

            return status.Id;
        }

    }
}
