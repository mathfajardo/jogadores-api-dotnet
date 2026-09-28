using System;
using jogador.domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace jogador.infrastructure.DataAccess;

internal class jogadorDbContext : DbContext
{
    public jogadorDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
    {
        
    }

    public DbSet<Usuario> Usuarios { get; set; }
}
