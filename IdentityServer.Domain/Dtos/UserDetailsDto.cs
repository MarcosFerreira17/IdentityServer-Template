namespace IdentityServer.Domain.Dtos;
public class UserDetailsDto
{
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Bio { get; set; }
    public DateTime? Birthdate { get; set; }
    public string ProfilePictureUrl { get; set; }
    public IEnumerable<AddressDto> Addresses { get; set; }

}
