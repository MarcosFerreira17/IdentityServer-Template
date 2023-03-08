using AutoMapper;
using IdentityServer.Domain.Dtos;
using IdentityServer.Domain.Entities.Identity;

namespace IdentityServer.Infrastructure.MappingProfile;

public class AuthProfile : Profile
{
    public AuthProfile()
    {
        CreateMap<User, UserLoginDto>().ReverseMap();
        CreateMap<User, UserRegisterDto>().ReverseMap();
        CreateMap<User, UserListDto>().ReverseMap();
        CreateMap<User, UserDetailsDto>().ReverseMap();
        CreateMap<Role, RoleDto>().ReverseMap();
    }
}
