namespace AEams.Web.Core.ViewModels
{
    public class DepartmentFormViewModel
    {
        public int Id { get; set; }

        [MaxLength(100, ErrorMessage = Errors.MaxLength), Display(Name = "القسم"),
              RegularExpression(RegexPatterns.NumbersAndChrOnly_ArEng, ErrorMessage = Errors.OnlyNumbersAndLetters)]
        [Remote("AllowItem", null, AdditionalFields = "Id", ErrorMessage = Errors.Duplicated)]
        public string Name { get; set; } = null!;
    }
}
