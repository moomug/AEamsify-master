namespace AEams.Web.Core.ViewModels
{
    public class DepartmentViewModel
    {
        public int Id { get; set; }
        [Display(Name = "الاسم")]
        public string Name { get; set; } = null!;

        public bool IsDeleted { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? LastUpdatedOn { get; set; }
    }
}
