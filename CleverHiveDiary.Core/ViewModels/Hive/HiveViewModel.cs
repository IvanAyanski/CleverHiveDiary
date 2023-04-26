using CleverHiveDiary.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleverHiveDiary.Core.ViewModels.Hive
{
    public class HiveViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public int StatusId { get; set; }

        public string? Status { get; set; }

        public double Production { get; set; }

        public string? Discription { get; set; }

        public int Floors { get; set; }

        public int FarmId { get; set; }

    }
}
