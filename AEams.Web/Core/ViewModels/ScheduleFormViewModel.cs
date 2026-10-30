using Microsoft.AspNetCore.Mvc.Rendering;

namespace AEams.Web.Core.ViewModels
{
    public class ScheduleFormViewModel
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(250, ErrorMessage = Errors.MaxLength)]
        [Display(Name = "العنوان")]
        public string Title { get; set; } = null!;

        [Display(Name = "القسم")]
        public int DepartmentId { get; set; }

        public IEnumerable<SelectListItem>? Department { get; set; }

        public TimeSpan StartOne { get; set; }

        public TimeSpan EndOne { get; set; }

        public TimeSpan? StartTwo { get; set; } = null;

        public TimeSpan? EndtTwo { get; set; } = null;

        public string Description { get; set; } = null!;

        public IList<int> SelectedScheduleWeekOffs { get; set; } = new List<int>();
        public IEnumerable<SelectListItem>? ScheduleWeekOff { get; set; }
    }
}
