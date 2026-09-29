using System;
using FluentMigrator.Runner;
using jogador.infrastructure.DataAccess;
using Microsoft.Extensions.DependencyInjection;

namespace jogador.infrastructure.Migrations;

public class DatabaseMigration
{
    public static void ExecuteMigrations(IServiceProvider serviceProvider)
    {
        var runner = serviceProvider.GetRequiredService<IMigrationRunner>();

        runner.ListMigrations();

        runner.MigrateUp();
    }
}
