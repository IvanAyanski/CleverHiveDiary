using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace CleverHiveDiary.Infrastructure.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            Notes = new List<Note>();
        }

        [Required]
        public int FarmId { get; set; }

        [ForeignKey(nameof(FarmId))]
        public Farm Farm { get; set; }

        public ICollection<Note> Notes { get; set; }
    }
}
