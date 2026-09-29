using System;

namespace jogador.domain.Repositories.Usuario;

public interface IUsuarioReadOnlyRepository
{
    Task<bool> ExistActiveUserWithEmail(string email);
}
