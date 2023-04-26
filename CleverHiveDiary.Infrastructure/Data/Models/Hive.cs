using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleverHiveDiary.Infrastructure.Data.Models
{
    public class Hive
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        [Required]
        public int StatusId { get; set; }

        [ForeignKey(nameof(StatusId))]
        public StatusHive Status { get; set; }

        [Required]
        public int Floors { get; set; }

        [Required]
        public double Production { get; set; }

        [Required]
        [StringLength(100)]
        public string Discription { get; set; }

        [Required]
        public int FarmId { get; set; } // One hive belongs to one farm
        [ForeignKey(nameof(FarmId))]
        public Farm Farm { get; set; }
    }
}
