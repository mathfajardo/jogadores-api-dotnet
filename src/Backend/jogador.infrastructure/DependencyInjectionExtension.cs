using jogador.domain.Repositories;
using jogador.domain.Repositories.Usuario;
using jogador.domain.Security.PasswordHashing;
using jogador.infrastructure.DataAccess;
using jogador.infrastructure.DataAccess.UsuarioRepository;
using jogador.infrastructure.Security.PasswordHashing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace jogador.infrastructure;

public static class DependencyInjectionExtension
{
    extension(IServiceCollection services)
    {
        public void AddInfrastructure(IConfiguration configuration)
        {
            services.AddScoped<IPasswordHasher, Argon2PasswordHasher>();

            services.AddScoped<IUsuarioWriteOnlyRepository, UsuarioRepository>();
            services.AddScoped<IUsuarioReadOnlyRepository, UsuarioRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddDbContext<jogadorDbContext>(config =>
            {
                var connectionString = configuration.GetConnectionString("DbConnection");

                config.UseNpgsql(connectionString);
            });
        }
    }
}
