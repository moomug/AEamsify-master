using Microsoft.AspNetCore.Mvc.Rendering;

namespace AEams.Web.Core.ViewModels
{
    public class ScheduleViewModel
    {
        public int Id { get; set; }
        [Display(Name = "العنوان")]
        public string Title { get; set; } = null!;
        [Display(Name = "القسم")]
        public string Department { get; set; } = null!;
        [Display(Name = "القسم")]
        public TimeSpan StartOne { get; set; }
        [Display(Name = "بداية")]
        public TimeSpan EndOne { get; set; }
        [Display(Name = "نهاية")]
        public TimeSpan? StartTwo { get; set; } = null;
        [Display(Name = "الفتره الثانية")]
        public TimeSpan? EndtTwo { get; set; } = null;
        [Display(Name = "مهاية الفتره")]
        public string Description { get; set; } = null!;
        [Display(Name = "ايام الاجازة الاسبوعية")]
        public IEnumerable<string>? ScheduleWeekOff { get; set; } = null!;
        public IEnumerable<UserViewModel> User { get; set; } = null!;
        public bool IsDeleted { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
