using IdentityServer.Domain.Common;

namespace IdentityServer.Domain.Entities;

public class User : EntityBase<long>
{
    public string Username { get; private set; } = string.Empty;
    public string Email { get; set; }
    public byte[] PasswordHash { get; private set; }
    public byte[] PasswordSalt { get; private set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Bio { get; set; }
    public DateTime? Birthdate { get; set; }
    public string ProfilePictureUrl { get; set; }
    public long RoleId { get; set; }
    public Role Role { get; set; }

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

    public void SetPassword(string password)
    {
        if (string.IsNullOrEmpty(password))
        {
            throw new ArgumentException("Password cannot be null or empty.");
        }

        CreatePasswordHash(password);
    }

    public void SetRole(long roleId)
    {
        if (roleId > 0)
        {
            throw new ArgumentException("Role cannot be null or empty.");
        }
        RoleId = roleId;
    }
}
