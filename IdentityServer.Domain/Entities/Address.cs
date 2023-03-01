using IdentityServer.Domain.Common;

namespace IdentityServer.Domain.Entities;

public class Address : EntityBase<long>
{
    public string Street { get; set; }
    public string Number { get; set; }
    public string Complement { get; set; }
    public string Neighborhood { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string ZipCode { get; set; }
}
