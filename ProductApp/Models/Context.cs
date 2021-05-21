using System;
using Microsoft.EntityFrameworkCore;

namespace ProductApp.Models
{
    public class Context : DbContext
    {
        public virtual DbSet<Category> categories { get; set; }
        public virtual DbSet<Product> products { get; set; }

        private const string connectionString = "server=localhost;port=3306;database=CursoMvc;user=[meu_nickname];password=[minha_super_senha]";    

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(connectionString, new MariaDbServerVersion(new Version(10, 3, 29)));
        }

        public virtual void SetModified(object entity)
        {
            Entry(entity).State = EntityState.Modified;
        }
    }
}