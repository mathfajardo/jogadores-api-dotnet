namespace jogador.domain.Entities;

public class Usuario
{
    public Guid Id { get; set; } =  Guid.CreateVersion7();
    public bool Ativo  { get; set; } = true;
    public DateTime DataCriacao { get; set; } = DateTime.UtcNow;
    public string Nome { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string Senha { get; set; } = string.Empty;
}
