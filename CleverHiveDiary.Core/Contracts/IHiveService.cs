using CleverHiveDiary.Core.ViewModels.Hive;
using CleverHiveDiary.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleverHiveDiary.Core.Contracts
{
    public interface IHiveService
    {
        Task<IEnumerable<HiveViewModel>> GetAllHivesAsync(Farm farm);

        Task DeleteHiveFromFarm(int hiveId);

        Task<IEnumerable<StatusHive>> GetHiveStatusAsync();

        Task AddHiveAsync(AddHiveViewModel model, int farmId);

        Task Edit(int hiveId, EditHiveViewModel model);

        Task<int> GetHiveStatusId(int hiveId);




    }
}
