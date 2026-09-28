using jogador.domain.Repositories;

namespace jogador.infrastructure.DataAccess;

internal class UnitOfWork : IUnitOfWork
{
    private readonly jogadorDbContext _dbContext;

    public UnitOfWork(jogadorDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Commit() => await _dbContext.SaveChangesAsync();
}
