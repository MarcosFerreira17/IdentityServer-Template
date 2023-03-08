using AutoMapper;
using IdentityServer.Domain.Dtos;
using IdentityServer.Domain.Entities.Identity;
using IdentityServer.Domain.Exceptions;
using IdentityServer.Infrastructure.JwtConfiguration;
using IdentityServer.Infrastructure.Repositories.Interfaces;
using IdentityServer.Infrastructure.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace IdentityServer.Infrastructure.Services;

public class AuthService : IAuthService
{
    protected readonly IAuthRepository _authRepository;
    protected readonly IMapper _mapper;
    protected readonly ILogger<IAuthService> _logger;
    protected readonly IConfiguration _configuration;
    public AuthService(IConfiguration configuration, IAuthRepository authRepository, IMapper mapper, ILogger<IAuthService> logger)
    {
        _configuration = configuration;
        _authRepository = authRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task Add(UserRegisterDto request)
    {
        if (request.Username is null || request.Password is null)
        {
            _logger.LogError("Username or password is null");
            throw new NotFoundException("Username or password is null.");
        }
        if (await _authRepository.FindByCondition(x => x.Username == request.Username).AnyAsync())
        {
            _logger.LogError("Username already exists");
            throw new NotFoundException("Username already exists.");
        }
        var entityFromDb = _mapper.Map<User>(request);
        entityFromDb.SetRoleId(1);
        entityFromDb.CreatePasswordHash(request.Password);
        await _authRepository.CreateUser(entityFromDb);
    }
    public async Task<string> Login(UserLoginDto request)
    {
        if (request.Username is null || request.Password is null)
        {
            _logger.LogError("Username or password is null");
            throw new NotFoundException("Username or password is null.");
        }

        var entityFromDb = await _authRepository.FindByCondition(x => x.Username == request.Username).FirstOrDefaultAsync();
        if (request.Password == null || !entityFromDb.VerifyPasswordHash(request.Password))
        {
            _logger.LogError("Username or password is incorrect");
            throw new NotFoundException("Username or password is incorrect.");
        }
        var tokenHandler = new JwtWebTokenConfiguration(_configuration, _authRepository);
        return tokenHandler.CreateToken(entityFromDb);
    }

    public async Task Update(long id, UserDetailsDto request)
    {
        if (request.Username is null || request.Password is null)
        {
            _logger.LogError("Username or password is null");
            throw new NotFoundException("Username or password is null.");
        }

        var updatedUser = await SearchForExistingId(id);

        if (await _authRepository.FindByCondition(x => x.Username == request.Username && x.Id != id).AnyAsync())
        {
            _logger.LogError("Username already exists");
            throw new NotFoundException("Username already exists.");
        }

        updatedUser.SetUsername(request.Username);
        updatedUser.SetPassword(request.Password);
        await _authRepository.Update(updatedUser);
    }

    public async Task Delete(long id)
    {
        await _authRepository.Delete(await SearchForExistingId(id));
    }

    public async Task<IEnumerable<UserListDto>> GetAll()
    {
        var entities = await _authRepository.FindAll();
        var mappedEntity = _mapper.Map<IEnumerable<UserListDto>>(entities);
        if (entities == null)
        {
            _logger.LogInformation("No data found");
            throw new NotFoundException("No data found.");
        }
        return mappedEntity;
    }

    public async Task<UserDetailsDto> GetById(long id)
    {
        var entityFromDb = await SearchForExistingId(id);

        return _mapper.Map<UserDetailsDto>(entityFromDb);
    }

    private async Task<User> SearchForExistingId(long id)
    {
        if (id < 1)
        {
            _logger.LogError("Field id must be filled");
            throw new NotFoundException("Field id must be filled and has to be greater than 0.");
        }

        var entityFromDb = await _authRepository.FindByCondition(x => x.Id == id).FirstOrDefaultAsync();
        if (entityFromDb is not null) return _mapper.Map<User>(entityFromDb);
        _logger.LogInformation("Id not found");
        throw new NotFoundException("This id does not exist in our database, please check and try again.");
    }
}