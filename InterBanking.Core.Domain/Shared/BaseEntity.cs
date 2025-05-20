using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterBanking.Core.Domain.Shared;

public class AuditableBaseEntity
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    // Can also be
    // public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
    // public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.UtcNow;
}