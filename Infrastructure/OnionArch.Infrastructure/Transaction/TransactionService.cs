using Microsoft.EntityFrameworkCore.Storage;
using OnionArch.Application.Interfaces.Services;
using OnionArch.Persistence.Context;

namespace OnionArch.Infrastructure.Transaction;
public sealed class TransactionService(AppDbContext context) : ITransactionService
{
    public async Task<IDbContextTransaction> CreateTransactionAsync(CancellationToken cancellationToken)
    {
        return await context.Database.BeginTransactionAsync(cancellationToken);
    }


}
