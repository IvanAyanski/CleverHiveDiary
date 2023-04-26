using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleverHiveDiary.Core.ViewModels.Note
{
    public class EditNoteViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(300, MinimumLength = 1)]
        public string Text { get; set; }

        [StringLength(20, MinimumLength = 1)]
        public string Title { get; set; }
    }
}
