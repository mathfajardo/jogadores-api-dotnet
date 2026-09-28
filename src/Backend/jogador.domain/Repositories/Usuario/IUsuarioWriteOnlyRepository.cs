namespace jogador.domain.Repositories.Usuario;

public interface IUsuarioWriteOnlyRepository
{
    Task Add(Entities.Usuario usuario);
}
