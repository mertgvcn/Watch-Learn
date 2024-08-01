using Microsoft.EntityFrameworkCore.Storage;

namespace OnionArch.Infrastructure.Database.Interfaces;
public interface ITransactionService
{
    Task<IDbContextTransaction> CreateTransactionAsync(CancellationToken cancellationToken);
}