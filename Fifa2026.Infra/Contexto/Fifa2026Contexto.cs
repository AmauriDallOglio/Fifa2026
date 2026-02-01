using Fifa2026.Dominio.Entidade;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.Data;
using System.Runtime.Intrinsics.X86;
using System;

namespace Fifa2026.Infra.Contexto
{
    public class Fifa2026Contexto : DbContext
    {
        public Fifa2026Contexto(DbContextOptions<Fifa2026Contexto> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<TimeSelecao> Times { get; set; }
        public DbSet<Estadio> Estadios { get; set; }
        public DbSet<Partida> Partidas { get; set; }
        public DbSet<CategoriaIngresso> CategoriasIngressos { get; set; }
        public DbSet<Compra> Compras { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Índices
            modelBuilder.Entity<Usuario>().HasIndex(u => u.Email).IsUnique();
            modelBuilder.Entity<Partida>().HasIndex(m => m.Data);
            modelBuilder.Entity<Partida>().HasIndex(m => m.EstadioId);
            modelBuilder.Entity<CategoriaIngresso>().HasIndex(t => t.PartidaId);
            modelBuilder.Entity<Compra>().HasIndex(p => p.UsuarioId);

            modelBuilder.Entity<CategoriaIngresso>()
              .Property(c => c.Preco)
              .HasPrecision(10, 2);

            modelBuilder.Entity<Compra>()
                .Property(c => c.PrecoUnitario)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Compra>()
                .Property(c => c.PrecoTotal)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Estadio>()
                .Property(e => e.Latitude)
                .HasPrecision(10, 8);

            modelBuilder.Entity<Estadio>()
            .Property(e => e.Longitude)
            .HasPrecision(11, 8);
        }

        /*

            PS C:\Amauri\GitHub\Fifa2026\Fifa2026> dotnet restore
            PS C:\Amauri\GitHub\Fifa2026\Fifa2026> dotnet ef migrations add InitialCreate -p Fifa2026.Infra -s Fifa2026.Api
            PS C:\Amauri\GitHub\Fifa2026\Fifa2026> dotnet ef database update -p Fifa2026.Infra -s Fifa2026.Api
            Build started...
            Build succeeded.
            info: Microsoft.EntityFrameworkCore.Database.Command[20101]
                  Executed DbCommand (9ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
                  SELECT 1
            info: Microsoft.EntityFrameworkCore.Database.Command[20101]
                  Executed DbCommand(9ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
                  SELECT OBJECT_ID(N'[__EFMigrationsHistory]');
                    info: Microsoft.EntityFrameworkCore.Database.Command[20101]
                          Executed DbCommand(1ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
                  SELECT 1
            info: Microsoft.EntityFrameworkCore.Database.Command[20101]
                  Executed DbCommand(0ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
                  SELECT OBJECT_ID(N'[__EFMigrationsHistory]');
                    info: Microsoft.EntityFrameworkCore.Database.Command[20101]
                          Executed DbCommand(3ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
                  SELECT[MigrationId], [ProductVersion]
                    FROM[__EFMigrationsHistory]
                  ORDER BY[MigrationId];
            info: Microsoft.EntityFrameworkCore.Migrations[20402]
                  Applying migration '20260128011310_InitialCreate'.
            Applying migration '20260128011310_InitialCreate'.
            info: Microsoft.EntityFrameworkCore.Database.Command[20101]
                  Executed DbCommand(10ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
                  CREATE TABLE[CategoriasIngressos] (
                      [Id] int NOT NULL IDENTITY,
                      [PartidaId] int NOT NULL,
                      [Categoria] nvarchar(max) NOT NULL,
                      [Preco] decimal (10,2) NOT NULL,
                      [QuantidadeTotal] int NOT NULL,
                      [QuantidadeDisponivel] int NOT NULL,
                      [Descricao] nvarchar(max) NULL,
                      [CriadoEm] datetime2 NOT NULL,
                      CONSTRAINT[PK_CategoriasIngressos] PRIMARY KEY([Id])
                  );
            info: Microsoft.EntityFrameworkCore.Database.Command[20101]
                  Executed DbCommand(2ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
                  CREATE TABLE[Compras] (
                      [Id] int NOT NULL IDENTITY,
                      [UsuarioId] int NOT NULL,
                      [CategoriaIngressoId] int NOT NULL,
                      [Quantidade] int NOT NULL,
                      [PrecoUnitario] decimal (10,2) NOT NULL,
                      [PrecoTotal] decimal (10,2) NOT NULL,
                      [Status] nvarchar(max) NOT NULL,
                      [MetodoPagamento] nvarchar(max) NULL,
                      [TransacaoId] nvarchar(max) NULL,
                      [CriadoEm] datetime2 NOT NULL,
                      [AtualizadoEm] datetime2 NOT NULL,
                      CONSTRAINT[PK_Compras] PRIMARY KEY([Id])
                  );
            info: Microsoft.EntityFrameworkCore.Database.Command[20101]
                  Executed DbCommand(2ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
                  CREATE TABLE[Estadios] (
                      [Id] int NOT NULL IDENTITY,
                      [Nome] nvarchar(max) NOT NULL,
                      [Cidade] nvarchar(max) NOT NULL,
                      [Pais] nvarchar(max) NOT NULL,
                      [Capacidade] int NOT NULL,
                      [Imagem] nvarchar(max) NULL,
                      [Descricao] nvarchar(max) NULL,
                      [Endereco] nvarchar(max) NULL,
                      [Latitude] decimal (10,8) NULL,
                      [Longitude] decimal (11,8) NULL,
                      [CriadoEm] datetime2 NOT NULL,
                      CONSTRAINT[PK_Estadios] PRIMARY KEY([Id])
                  );
            info: Microsoft.EntityFrameworkCore.Database.Command[20101]
                  Executed DbCommand(3ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
                  CREATE TABLE[Partidas] (
                      [Id] int NOT NULL IDENTITY,
                      [TimeCasaId] int NOT NULL,
                      [TimeVisitanteId] int NOT NULL,
                      [EstadioId] int NOT NULL,
                      [Data] datetime2 NOT NULL,
                      [Hora] nvarchar(max) NOT NULL,
                      [Etapa] nvarchar(max) NOT NULL,
                      [Grupo] nvarchar(max) NULL,
                      [PlacarCasa]
                    int NULL,
                      [PlacarVisitante] int NULL,
                      [Status] nvarchar(max) NOT NULL,
                      [CriadoEm] datetime2 NOT NULL,
                      CONSTRAINT[PK_Partidas] PRIMARY KEY([Id])
                  );
            info: Microsoft.EntityFrameworkCore.Database.Command[20101]
                  Executed DbCommand(3ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
                  CREATE TABLE[Times] (
                      [Id] int NOT NULL IDENTITY,
                      [Nome] nvarchar(max) NOT NULL,
                      [Codigo] nvarchar(max) NOT NULL,
                      [Bandeira] nvarchar(max) NULL,
                      [Grupo] nvarchar(max) NULL,
                      [Confederacao] nvarchar(max) NULL,
                      [RankingFifa]
                    int NULL,
                      [CriadoEm] datetime2 NOT NULL,
                      CONSTRAINT[PK_Times] PRIMARY KEY([Id])
                  );
            info: Microsoft.EntityFrameworkCore.Database.Command[20101]
                  Executed DbCommand(2ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
                  CREATE TABLE[Usuarios] (
                      [Id] int NOT NULL IDENTITY,
                      [Nome] nvarchar(max) NOT NULL,
                      [Email] nvarchar(450) NOT NULL,
                      [Senha] nvarchar(max) NOT NULL,
                      [Papel] nvarchar(max) NULL,
                      [Telefone] nvarchar(max) NULL,
                      [Documento] nvarchar(max) NULL,
                      [CriadoEm] datetime2 NOT NULL,
                      [AtualizadoEm] datetime2 NOT NULL,
                      CONSTRAINT[PK_Usuarios] PRIMARY KEY([Id])
                  );
            info: Microsoft.EntityFrameworkCore.Database.Command[20101]
                  Executed DbCommand(5ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
                  CREATE INDEX[IX_CategoriasIngressos_PartidaId] ON[CategoriasIngressos] ([PartidaId]);
            info: Microsoft.EntityFrameworkCore.Database.Command[20101]
                  Executed DbCommand(2ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
                  CREATE INDEX[IX_Compras_UsuarioId] ON[Compras] ([UsuarioId]);
            info: Microsoft.EntityFrameworkCore.Database.Command[20101]
                  Executed DbCommand(1ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
                  CREATE INDEX[IX_Partidas_Data] ON[Partidas] ([Data]);
            info: Microsoft.EntityFrameworkCore.Database.Command[20101]
                  Executed DbCommand(1ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
                  CREATE INDEX[IX_Partidas_EstadioId] ON[Partidas] ([EstadioId]);
            info: Microsoft.EntityFrameworkCore.Database.Command[20101]
                  Executed DbCommand(2ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
                  CREATE UNIQUE INDEX[IX_Usuarios_Email] ON[Usuarios] ([Email]);
            info: Microsoft.EntityFrameworkCore.Database.Command[20101]
                  Executed DbCommand(9ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
                  INSERT INTO[__EFMigrationsHistory] ([MigrationId], [ProductVersion])
                  VALUES(N'20260128011310_InitialCreate', N'8.0.23');
            Done.
            PS C:\Amauri\GitHub\Fifa2026\Fifa2026>'
    
        */
    }
}
