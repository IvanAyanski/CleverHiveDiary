using CleverHiveDiary.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleverHiveDiary.Core.ViewModels.Hive
{
    public class EditHiveViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 2)]
        public string Name { get; set; }

        [Display(Name = "Status")]
        public int StatusId { get; set; }

        public IEnumerable<StatusHive> statusHives { get; set; } = new List<StatusHive>();

        public double Production { get; set; }

        public string Discription { get; set; }

        public int Floors { get; set; }
    }
}
