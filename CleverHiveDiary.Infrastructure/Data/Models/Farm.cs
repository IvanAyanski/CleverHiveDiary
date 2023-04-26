using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleverHiveDiary.Infrastructure.Data.Models
{
    public class Farm
    {
        public Farm()
        {
            Hives = new List<Hive>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Location { get; set; }

        [Required]
        public int Capacity { get; set; }

        [Required]
        public string UserId { get; set; } // One farm belongs to one farmer
        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; }

        public ICollection<Hive> Hives { get; set; }
    }
}
