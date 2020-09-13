using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using PessoasAPI.Classes;
using System;
using System.Data.Entity;

namespace PessoasAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();


        }
        public class PessoaContext : DbContext
        {
            public DbSet<Pessoa> Pessoa { get; set; }

            

            public DbSet<Endereco> Endereco { get; set; }

            public DbSet<Pais> Pais { get; set; }
            public DbSet<Estado> Estado { get; set; }

            public DbSet<Cidade> Cidade { get; set; }


            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Pessoa>()
                    .Property(u => u.Cpf)
                    .HasColumnName("cpf");

                modelBuilder.Entity<Pessoa>()
                    .Property(u => u.Nome)
                    .HasColumnName("nome");

                modelBuilder.Entity<Pessoa>()
                    .Property(u => u.Data_nascimento)
                    .HasColumnName("data_nascimento");

                modelBuilder.Entity<Pessoa>()
                   .HasKey(x => x.Id);

            }


        }



        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
