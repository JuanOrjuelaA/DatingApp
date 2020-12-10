namespace DatingApp.Services.Mappings
{
    using AutoMapper;
    using Models.DTOs;
    using Models.Entities;
    using System.Linq;
    using Models.Extensions;

    public class ServiceMappingProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceMappingProfile"/> class.
        /// </summary>
        public ServiceMappingProfile()
        {
            this.CreateMap<AppUser, MemberDto>()
                .ForMember(dest => dest.PhotUrl,
                    opt => opt.MapFrom(src => src.Photos.FirstOrDefault(x => x.IsMain).Url))
                .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.DateOfBirth.CalculateAge()));
        }
    }
}