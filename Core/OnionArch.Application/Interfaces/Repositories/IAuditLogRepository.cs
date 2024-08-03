using OnionArch.Domain.Entities;

namespace OnionArch.Application.Interfaces.Repositories;
public interface IAuditLogRepository : IBaseRepository<AuditLog>
{
    new Task<AuditLog> AddAsync(AuditLog Entity, CancellationToken cancellationToken = default);
}
