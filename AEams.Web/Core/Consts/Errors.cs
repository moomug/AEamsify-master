namespace AEams.Web.Core.Consts
{
    public class Errors
    {
        public const string RequiredField = "حقل مطلوب";
        public const string MaxLength = "لا يمكن أن يكون الطول أكثر من {1} حرفا";
        public const string MaxMinLength = "يجب أن يكون {0} على الأقل {2} والحد الأقصى {1} من الأحرف.";
        public const string Duplicated = "{0} الذي يحمل نفس الاسم موجود بالفعل!";
        public const string DuplicatedSchedule = "الجدول الزمني بنفس العنوان موجود بالفعل مع نفس القسم!";
        //public const string NotAllowedExtension = "Only .png, .jpg, .jpeg files are allowed!";
        //public const string MaxSize = "File cannot be more that 2 MB!";
        //public const string NotAllowFutureDates = "Date cannot be in the future!";
        //public const string InvalidRange = "{0} should be between {1} and {2}!";
        public const string ConfirmPasswordNotMatch = "كلمة المرور وكلمة المرور التأكيدية غير متطابقتين.";
        public const string WeakPassword = "تحتوي كلمات المرور على أحرف كبيرة وحرف صغير ورقم وحرف غير أبجدي رقمي. يجب أن تتكون كلمات المرور من 8 أحرف على الأقل ";
        public const string InvalidUsername = "يمكن أن يحتوي اسم المستخدم على أحرف أو أرقام فقط.";
        public const string OnlyEnglishLetters = "مسموح فقط باستخدام الحروف الإنجليزية.";
        public const string OnlyArabicLetters = "يسمح فقط بالحروف العربية.";
        public const string OnlyNumbersAndLetters = "يسمح فقط باستخدام الأحرف أو الأرقام العربية / الإنجليزية.";
        public const string DenySpecialCharacters = "يمنع استعمال الرموز.";
    }
}
