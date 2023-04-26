using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleverHiveDiary.Core.ViewModels.Farm
{
    public class FarmViewModel
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
      
        public string Location { get; set; }
       
        public int Capacity { get; set; }
    }
}
