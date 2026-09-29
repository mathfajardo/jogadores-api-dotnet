using jogador.domain.Entities;
using jogador.domain.Repositories.Usuario;
using Microsoft.EntityFrameworkCore;

namespace jogador.infrastructure.DataAccess.UsuarioRepository;

internal sealed class UsuarioRepository : IUsuarioWriteOnlyRepository, IUsuarioReadOnlyRepository
{
    private readonly jogadorDbContext _dbContext;
    public UsuarioRepository(jogadorDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Add(Usuario usuario)
    {
        await _dbContext.Usuarios.AddAsync(usuario);
    }

    public async Task<bool> ExistActiveUserWithEmail(string email)
    {
        return await _dbContext.Usuarios.AnyAsync(usuario => usuario.Ativo && usuario.Email.Equals(email));
    }
}
