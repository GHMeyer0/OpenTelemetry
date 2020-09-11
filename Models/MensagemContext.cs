using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class MensagemContext : DbContext 
    {
        public MensagemContext(DbContextOptions<MensagemContext> options) : base(options)
        {
        }
        public DbSet<Mensagem> Mensagems { get; set; }

    }
}
