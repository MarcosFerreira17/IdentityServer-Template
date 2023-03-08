using IdentityServer.Domain.Common;

namespace IdentityServer.Domain.Entities.Identity;

public class User : EntityBase<long>
{
    public string Username { get; private set; } = string.Empty;
    public string Email { get; private set; }
    public byte[] PasswordHash { get; private set; }
    public byte[] PasswordSalt { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Bio { get; private set; }
    public DateTime? Birthdate { get; private set; }
    public string ProfilePictureUrl { get; private set; }
    public long RoleId { get; private set; }
    public Role Role { get; private set; }
    public IEnumerable<Address> Addresses { get; private set; }

    public void CreatePasswordHash(string password)
    {
        using var hmac = new System.Security.Cryptography.HMACSHA512();
        PasswordSalt = hmac.Key;
        PasswordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
    }

    public bool VerifyPasswordHash(string password)
    {
        using var hmac = new System.Security.Cryptography.HMACSHA512(PasswordSalt);
        var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        return computedHash.SequenceEqual(PasswordHash);
    }

    public void SetUsername(string username)
    {
        if (string.IsNullOrEmpty(username))
        {
            throw new ArgumentException("Username cannot be null or empty.");
        }

        Username = username;
    }

    public void SetEmail(string email)
    {
        if (string.IsNullOrEmpty(email))
        {
            throw new ArgumentException("Email cannot be null or empty.");
        }

        Email = email;
    }
    public void SetPassword(string password)
    {
        if (string.IsNullOrEmpty(password))
        {
            throw new ArgumentException("Password cannot be null or empty.");
        }

        CreatePasswordHash(password);
    }
    public void SetRoleId(long roleId)
    {
        if (roleId <= 0)
            throw new ArgumentException("Role Id cannot be less than or equal to 0.");

        RoleId = roleId;
    }
}
