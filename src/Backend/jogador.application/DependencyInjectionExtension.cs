using System;
using jogador.application.UseCases.User.Register;
using Microsoft.Extensions.DependencyInjection;

namespace jogador.application;

public static class DependencyInjectionExtension
{
    extension(IServiceCollection services)
    {
        public void AddApplication()
        {
            services.AddScoped<IRegistrarUsuarioContaUseCase, RegistrarUsuarioContaUseCase>();
        }
    }
}
