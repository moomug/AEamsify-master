namespace AEams.Web.Core.Models
{
    public class ScheduleUser
    {
        public int ScheduleId { get; set; }
        public Schedule? Schedule { get; set; }

        public string? UserId { get; set; }
        public ApplicationUser? User { get; set; }

    }
}