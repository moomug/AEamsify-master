namespace AEams.Web.Core.Models
{
    public class Week
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(30)]
        public string? NameEn { get; set; }
        [MaxLength(30)]
        public string? NameAr { get; set; }

        public ICollection<ScheduleWeekOff> Weeks { get; set; } = new List<ScheduleWeekOff>();
    }
}
