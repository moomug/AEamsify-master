using AEams.Web.Core.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AEams.Web.Core.Mapping
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            // Department
            CreateMap<Department, DepartmentViewModel>();
            CreateMap<DepartmentFormViewModel, Department>().ReverseMap();
            CreateMap<Department, SelectListItem>()
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Text, opt => opt.MapFrom(src => src.Name)).ReverseMap();

            //Week
            CreateMap<Week, SelectListItem>()
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Text, opt => opt.MapFrom(src => src.NameAr)).ReverseMap();

            //Add Sc
            CreateMap<ApplicationUser, SelectListItem>()
              .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Id))
              .ForMember(dest => dest.Text, opt => opt.MapFrom(src => src.FullName)).ReverseMap();

            CreateMap<ScheduleUsersFormViewModel, ScheduleUser>()
                .ReverseMap()
                 .ForMember(dest => dest.User, opt => opt.Ignore());

                  CreateMap<ScheduleUsersFormViewModel, ApplicationUser>()
                 .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User));
                 //.ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User.Select(s => s.Use!.NameAr).ToList()));

           

            //Schedule
            CreateMap<ScheduleFormViewModel, Schedule>()
                 .ReverseMap()
                .ForMember(dest => dest.ScheduleWeekOff, opt => opt.Ignore());

            CreateMap<Schedule, ScheduleViewModel>()
                    .ForMember(dest => dest.Department, opt => opt.MapFrom(src => src.Department!.Name))
                    .ForMember(dest => dest.ScheduleWeekOff, opt => opt.MapFrom(src => src.ScheduleWeekOff.Select(s => s.Week!.NameAr).ToList()))
                    .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User.Select(s =>  s.User ).ToList()));

            CreateMap<UserViewModel, ScheduleUser>().ReverseMap()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.UserId));
                
            //Users
            CreateMap<ApplicationUser, UserViewModel>().ReverseMap();
            CreateMap<UserFormViewModel, ApplicationUser>()
                    .ForMember(dest => dest.NormalizedEmail, opt => opt.MapFrom(src => src.Email.ToUpper()))
                    .ForMember(dest => dest.NormalizedUserName, opt => opt.MapFrom(src => src.UserName.ToUpper()))
                    .ReverseMap();
        }
    }
}
