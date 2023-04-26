using CleverHiveDiary.Core.ViewModels.Farm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleverHiveDiary.Core.Contracts
{
    public interface IFarmService
    {
        Task<FarmViewModel> GetUserFarm(string userId);

        Task CreateFarmAsync(AddFarmViewModel model, string userId);

        Task LinkUserToFarm(string userId, int farmId);

        Task Edit(EditFarmViewModel model, int farmId);

        
    }
}
