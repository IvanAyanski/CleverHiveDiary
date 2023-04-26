using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleverHiveDiary.Core.ViewModels.Farm
{
    public class EditFarmViewModel
    {
        public int Id { get; set; }

        [StringLength(20, MinimumLength = 1)]
        public string Name { get; set; }

        [StringLength(50, MinimumLength = 1)]
        public string Location { get; set; }

    }
}
