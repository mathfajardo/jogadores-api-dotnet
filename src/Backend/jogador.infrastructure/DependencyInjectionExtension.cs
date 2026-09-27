using jogador.domain.Security.PasswordHashing;
using jogador.infrastructure.Security.PasswordHashing;
using Microsoft.Extensions.DependencyInjection;

namespace jogador.infrastructure;

public static class DependencyInjectionExtension
{
    extension(IServiceCollection services)
    {
        public void AddInfrastructure()
        {
            services.AddScoped<IPasswordHasher, Argon2PasswordHasher>();
        }
    }
}
