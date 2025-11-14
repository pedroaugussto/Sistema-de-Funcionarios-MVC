// using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Sistema_De_Funcionarios_MVC.Models;

namespace Sistema_De_Funcionarios_MVC.Data

{
    public class AppDbContext : DbContext
    {
        //* Recebe as opcoes de configuracao do banco
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { } 

        //* Direciona a classe (funcionario) para a tabela (TabelaFuncionario)
        public DbSet<Funcionario> TabelaFuncionario {get; set; }

        //* Sobrescrever o mapeamento do modelo (uma unica tabela para funcionarios)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Funcionario>() //Comeca a configurar a entidade base funcionario
            .HasDiscriminator<string>("Cargo") //Cria uma unica tabela, diferenciando Gerente e Vendedor por cargo
            .HasValue<Gerente>("Gerente") //Quando a instancia for gerente, grava "Gerente" em cargo
            .HasValue<Vendedor>("Vendedor"); //Quando a instancia for vendedor, grava "Vendedor" em cargo
        }
    }
}