using Microsoft.AspNetCore.Mvc.Rendering;
using System.Xml.Linq;

namespace AEams.Web.Core.ViewModels
{
    public class ScheduleUsersFormViewModel
    {
        public int ScheduleId { get; set; }
        public string? UserId { get; set; }

        public IEnumerable<SelectListItem>? User { get; set; }
      
    }
}
