namespace AEams.Web.Core.ViewModels
{
    public class UserViewModel
    {
        public string Id { get; set; } = null!;

        public string FullName { get; set; } = null!;

        public string UserName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public int DepartmentId { get; set; }

        public string? Nationality { get; set; }

        public string NationalID { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public bool IsDeleted { get; set; }

        public DateTime? CreatedOn { get; set; }

        public DateTime? LastUpdatedOn { get; set; }
    }
}
