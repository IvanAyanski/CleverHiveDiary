using NonFactors.Mvc.Grid;

namespace CleverHiveDiary.Areas.Admin.Models
{
    public class UsersViewModel
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public int FarmId { get; set; }
    }
}
