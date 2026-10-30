using System.Xml.Linq;

namespace AEams.Web.Core.Models
{
    [Index(nameof(Title), nameof(DepartmentId), IsUnique = true)]
    public class Schedule : BaseModel
    {
        [Key]
        public int Id { get; set; }
        
        [MaxLength(500)]
        public string Title { get; set; } = null!;

        public int DepartmentId { get; set; }

        public Department? Department { get; set; }

        public TimeSpan StartOne { get; set; }

        public TimeSpan EndOne { get; set; }

        public TimeSpan? StartTwo { get; set; } = null;

        public TimeSpan? EndtTwo { get; set; } = null;

        public string Description { get; set; } = null!;

        public ICollection<ScheduleWeekOff> ScheduleWeekOff { get; set; } = new List<ScheduleWeekOff>();
        public ICollection<ScheduleUser> User { get; set; } = new List<ScheduleUser>();

    }
}
