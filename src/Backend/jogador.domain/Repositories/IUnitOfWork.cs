using System;

namespace jogador.domain.Repositories;

public interface IUnitOfWork
{
    Task Commit();
}
