using AutoMapper;
using WebApplication1.Dto;
using WebApplication1.Entites;

namespace WebApplication1
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<User,GetUserDto> ();
            CreateMap<CreateUserDto,User> ();
            CreateMap<UpdateUserDto,User> ();
        }
    }
}
