using CadastroTeste.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroTeste.EntityFramework
{
    public class UsuarioContext : DbContext
    {
        public UsuarioContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Usuario> Usuarios { get; set; }
    }
}
