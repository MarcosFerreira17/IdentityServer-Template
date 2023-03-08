using IdentityServer.Domain.Common;

namespace IdentityServer.Domain.Entities.Identity;

public class Role : EntityBase<long>
{
    public Role(string name, string description)
    {
        Name = name;
        Description = description;
    }

    public Role() { }
    public string Name { get; private set; }
    public string Description { get; private set; }

}
