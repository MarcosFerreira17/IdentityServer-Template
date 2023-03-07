using IdentityServer.Domain.Common;

namespace IdentityServer.Domain.Entities;

public class Address : EntityBase<long>
{
    public string Street { get; private set; }
    public string Number { get; private set; }
    public string Complement { get; private set; }
    public string Neighborhood { get; private set; }
    public string City { get; private set; }
    public string State { get; private set; }
    public string ZipCode { get; private set; }
    public long UserId { get; private set; }
    public User User { get; private set; }

}
