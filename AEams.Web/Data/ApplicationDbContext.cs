using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace AEams.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<ScheduleUser> ScheduleUsers { get; set; }

        public DbSet<ScheduleWeekOff> ScheduleWeekOffs { get; set; }
        public DbSet<Week> Weeks { get; set; }
        public DbSet<Attendances> Attendances { get; set; }
   
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ScheduleUser>().HasKey(e => new { e.ScheduleId, e.UserId });

            builder.Entity<Week>().HasData(new Week { Id = 1, NameEn = "Sunday", NameAr = "الأحد" });
            builder.Entity<Week>().HasData(new Week { Id = 2, NameEn = "Monday", NameAr = "الإثنين" });
            builder.Entity<Week>().HasData(new Week { Id = 3, NameEn = "Tuesday", NameAr = "الثلاثاء" });
            builder.Entity<Week>().HasData(new Week { Id = 4, NameEn = "Wednesday", NameAr = "الاربعاء" });
            builder.Entity<Week>().HasData(new Week { Id = 5, NameEn = "Thursday", NameAr = "الخميس" });
            builder.Entity<Week>().HasData(new Week { Id = 6, NameEn = "Friday", NameAr = "الجمعة" });
            builder.Entity<Week>().HasData(new Week { Id = 7, NameEn = "Saturday", NameAr = "السبت" });

            builder.Entity<ScheduleWeekOff>().HasKey(e => new { e.ScheduleId, e.WeekId });
            base.OnModelCreating(builder);
        }

    }
}