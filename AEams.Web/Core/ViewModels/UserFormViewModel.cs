using Microsoft.AspNetCore.Mvc.Rendering;
using UoN.ExpressiveAnnotations.NetCore.Attributes;

namespace AEams.Web.Core.ViewModels
{
    public class UserFormViewModel
    {
        public string? Id { get; set; }

        [MaxLength(100, ErrorMessage = Errors.MaxLength), Display(Name = "الاسم"),
            RegularExpression(RegexPatterns.NumbersAndChrOnly_ArEng , ErrorMessage = Errors.OnlyNumbersAndLetters)]
        public string FullName { get; set; } = null!;

        [MaxLength(20, ErrorMessage = Errors.MaxLength), Display(Name = "اسم المستخدم"),
            RegularExpression(RegexPatterns.Username, ErrorMessage = Errors.InvalidUsername)]
        [Remote("AllowUserName", null!, AdditionalFields = "Id", ErrorMessage = Errors.Duplicated)]

        public string UserName { get; set; } = null!;

        [MaxLength(200, ErrorMessage = Errors.MaxLength), EmailAddress,  Display(Name = "الإيميل")]
        [Remote("AllowEmail", null!, AdditionalFields = "Id", ErrorMessage = Errors.Duplicated)]
        public string Email { get; set; } = null!;

        [Display(Name = "القسم")]
        public int DepartmentId { get; set; }

        public IEnumerable<SelectListItem>? Department { get; set; }

        [Display(Name = "Roles")]
        public IList<string> SelectedRoles { get; set; } = new List<string>();
        public IEnumerable<SelectListItem>? Roles { get; set; }

        [DataType(DataType.Password),
            StringLength(100, ErrorMessage = Errors.MaxMinLength, MinimumLength = 8),
            RegularExpression(RegexPatterns.Password, ErrorMessage = Errors.WeakPassword)]
        [Display(Name = "كلمة المرور")]
        [RequiredIf("Id == null", ErrorMessage = Errors.RequiredField)]
        public string? Password { get; set; } = null!; 
        
        [DataType(DataType.Password), Display(Name = " تأكيد كلمة المرور"),
            Compare("Password", ErrorMessage = Errors.ConfirmPasswordNotMatch)]
        [RequiredIf("Id == null", ErrorMessage = Errors.RequiredField)]
        public string? ConfirmPassword { get; set; } = null!;

        [Remote("AllowPhoneNumber", null!, AdditionalFields = "Id", ErrorMessage = Errors.Duplicated)]
        public string PhoneNumber { get; set; } = null!;

        public string Nationality { get; set; } = null!;

        [RegularExpression("^\\d{10}$", ErrorMessage = "Valid Learner Number must be supplied")]
        [Remote("AllowNationalID", null!, AdditionalFields = "Id", ErrorMessage = Errors.Duplicated)]
        public int NationalID { get; set; }
    }

}
 