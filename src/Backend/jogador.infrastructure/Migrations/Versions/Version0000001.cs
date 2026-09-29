using System;
using FluentMigrator;

namespace jogador.infrastructure.Migrations.Versions;

[Migration(DatabaseVersions.TABLE_USUARIOS, "Creating Usuarios table")]
public class Version0000001 : ForwardOnlyMigration
{
    public override void Up()
    {
        Create.Table("Usuarios")
            .WithColumn("Id").AsGuid().PrimaryKey().NotNullable()
            .WithColumn("Ativo").AsBoolean().NotNullable()
            .WithColumn("Nome").AsString(250).NotNullable()
            .WithColumn("Email").AsString(250).NotNullable()
            .WithColumn("Senha").AsString(2000).NotNullable()
            .WithColumn("DataCriacao").AsDateTimeOffset().NotNullable().WithDefault(SystemMethods.CurrentDateTimeOffset);
    }
}
