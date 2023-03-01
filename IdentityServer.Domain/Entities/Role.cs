using IdentityServer.Domain.Common;

namespace IdentityServer.Domain.Entities;

public class Role : EntityBase<long>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public IEnumerable<User> Users { get; set; }
}
