using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleverHiveDiary.Core.ViewModels
{
    public class EditUserViewModel
    {
        public string Id { get; set; }

        [StringLength(15, MinimumLength = 2)]
        public string UserName { get; set; }

        public string NormalizedUserName { get; set; }

        [StringLength(25, MinimumLength = 6)]
        public string Email { get; set; }

        public string NormalizedEmail { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }
    }
}
