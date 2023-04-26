using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleverHiveDiary.Core.ViewModels.Note
{
    public class NoteViewModel
    {
        public int Id { get; set; }
       
        public string Text { get; set; }

        public string Title { get; set; }

        public string UserId { get; set; }

    }
}
