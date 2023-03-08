namespace IdentityServer.Domain.Dtos;

public class UserListDto
{
    public string Username { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime? Birthdate { get; set; }

}
