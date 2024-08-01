using Microsoft.EntityFrameworkCore.Storage;
using OnionArch.Infrastructure.Database.Interfaces;
using OnionArch.Persistence.Context;

namespace OnionArch.Infrastructure.Database;
public sealed class TransactionService(AppDbContext context) : ITransactionService
{
    public async Task<IDbContextTransaction> CreateTransactionAsync(CancellationToken cancellationToken)
    {
        return await context.Database.BeginTransactionAsync(cancellationToken);
    }


}
