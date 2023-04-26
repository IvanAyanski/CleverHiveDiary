using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleverHiveDiary.Infrastructure.Data.Models
{
    public class StatusHive
    {
        public StatusHive()
        {
            Hives = new List<Hive>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        public ICollection<Hive> Hives { get; set; }
    }
}
