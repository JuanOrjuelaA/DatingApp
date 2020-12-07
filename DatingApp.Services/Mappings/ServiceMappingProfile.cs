namespace DatingApp.Services.Mappings
{
    using AutoMapper;
    using Models.DTOs;
    using Models.Entities;

    public class ServiceMappingProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceMappingProfile"/> class.
        /// </summary>
        public ServiceMappingProfile()
        {
            this.CreateMap<AppUser, MemberDto>();
        }
    }
}