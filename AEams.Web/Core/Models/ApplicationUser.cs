using Microsoft.AspNetCore.Identity;

namespace AEams.Web.Core.Models
{
    [Index(nameof(FullName), IsUnique = true)]
    [Index(nameof(NationalID), IsUnique = true)]
    [Index(nameof(Email), IsUnique = true)]
    [Index(nameof(UserName), IsUnique = true)]
    public class ApplicationUser : IdentityUser
    {
        [MaxLength(100)]
        public string FullName { get; set; } = null!;

        public string Nationality { get; set; } = null!;

        [RegularExpression("^\\d{10}$", ErrorMessage = "Valid Learner Number must be supplied")]
        public int NationalID { get; set; }

        public int DepartmentId { get; set; }

        public bool IsDeleted { get; set; }

        public string? CreatedById { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.Now;

        public string? LastUpdatedById { get; set; }

        public DateTime? LastUpdatedOn { get; set; }

        public ICollection<ScheduleUser> User { get; set; } = new List<ScheduleUser>();
    }

}
