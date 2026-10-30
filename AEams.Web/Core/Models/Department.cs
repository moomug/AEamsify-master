namespace AEams.Web.Core.Models
{
    [Index(nameof(Name), IsUnique = true)]
    public class Department : BaseModel
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; } = null!;

    }
}
