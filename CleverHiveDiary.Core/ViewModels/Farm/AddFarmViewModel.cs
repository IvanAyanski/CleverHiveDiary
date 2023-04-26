using CleverHiveDiary.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleverHiveDiary.Core.ViewModels.Farm
{
    public class AddFarmViewModel
    {
        [StringLength(20, MinimumLength =1)]
        public string Name { get; set; }

        [StringLength(50, MinimumLength = 1)]
        public string Location { get; set; }

        public int Capacity { get; set; }

        public string? UserId { get; set; } 

       //public List<Hive> Hives { get; set; } = new List<Hive>();
    }
}
