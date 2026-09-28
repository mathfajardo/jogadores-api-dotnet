using jogador.domain.Entities;
using jogador.domain.Repositories.Usuario;

namespace jogador.infrastructure.DataAccess.UsuarioRepository;

internal sealed class UsuarioRepository : IUsuarioWriteOnlyRepository
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
}
