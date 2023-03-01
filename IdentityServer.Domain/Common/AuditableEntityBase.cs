namespace IdentityServer.Domain.Common;

public abstract class AuditableEntityBase<Tid>
{
    public Tid Id { get; private set; }
    public DateTime CreatedDate { get; private set; }
    public DateTime? ModifiedDate { get; private set; }
    public bool IsActive { get; set; }
}
