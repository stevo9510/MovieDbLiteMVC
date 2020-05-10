using AutoMapper;

namespace MovieDbLite.MVC.Profiles
{
    public class AwardProfile : Profile
    {
        public AwardProfile()
        {
            CreateMap<Models.Award, ViewModels.AwardViewModel>()
                .ForMember(
                    dest => dest.AwardShowName,
                    opt => opt.MapFrom(src => src.AwardShow == null ? "" : src.AwardShow.ShowName));
        }
    }
}
