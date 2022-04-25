﻿using Microsoft.EntityFrameworkCore;
using MyAngular20.DataAccess.Mappings;
using MyAngular20.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAngular20.DataAccess.Contexts
{
    internal class MyContext : DbContext
    {
        private readonly string _conn;
        public MyContext(string conn = "")
        {
            this._conn = conn;

            Database.EnsureCreated();
            Database.Migrate();
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            

            if (string.IsNullOrWhiteSpace(_conn))
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb; Database=MyAngular20Db; Trusted_connection=True; MultipleActiveResultSets=True");
            else
                optionsBuilder.UseSqlServer(_conn);
           
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            

            modelBuilder.ApplyConfiguration(new CategoriaMap());
            modelBuilder.ApplyConfiguration(new ClienteMap());
            modelBuilder.ApplyConfiguration(new PedidoItemMap());
            modelBuilder.ApplyConfiguration(new PedidoMap());
            modelBuilder.ApplyConfiguration(new ProdutoMap());
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new ProdutoFotoMap());
            modelBuilder.ApplyConfiguration(new UnidadeDeMedidaMap());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<PedidoItem> PedidosItens { get; set; }
        public DbSet<UnidadeDeMedida> UnidadeDeMedidas { get; set; }

    }
}