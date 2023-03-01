using AutoMapper;
using IdentityServer.Domain.Dtos;
using IdentityServer.Domain.Entities;

namespace IdentityServer.Infrastructure.MappingProfile;

public class AuthProfile : Profile
{
    public AuthProfile()
    {
        CreateMap<User, UserDto>().ReverseMap();
    }
}
