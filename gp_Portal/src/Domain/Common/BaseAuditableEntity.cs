using System.ComponentModel.DataAnnotations;

namespace gp_Portal.Domain.Common;

public abstract class BaseAuditableEntity : BaseEntity
{
    public DateTime Created { get; set; }

    [MaxLength(200)]
    public string? CreatedBy { get; set; }

    public DateTime? LastModified { get; set; }
    [MaxLength(200)]

    public string? LastModifiedBy { get; set; }
}
