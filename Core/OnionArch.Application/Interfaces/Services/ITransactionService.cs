using Microsoft.EntityFrameworkCore.Storage;

namespace OnionArch.Application.Interfaces.Services;
public interface ITransactionService
{
    Task<IDbContextTransaction> CreateTransactionAsync(CancellationToken cancellationToken);
}