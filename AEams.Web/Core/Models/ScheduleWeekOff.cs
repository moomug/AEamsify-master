namespace AEams.Web.Core.Models
{
    public class ScheduleWeekOff
    {
        public int ScheduleId { get; set; }
        public Schedule? Schedule { get; set; }

        public int WeekId { get; set; }
        public Week? Week { get; set; }
    }
}
