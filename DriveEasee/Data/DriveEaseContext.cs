using System;
using System.Collections.Generic;
using DriveEasee.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DriveEasee.Data
{
    public partial class DriveEaseContext : IdentityUserContext<IdentityUser>
    {
        public DriveEaseContext()
        {
        }

        public DriveEaseContext(DbContextOptions<DriveEaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Aluguer> Aluguers { get; set; } = null!;
        public virtual DbSet<Carro> Carros { get; set; } = null!;
        public virtual DbSet<CategoriaCarro> CategoriaCarros { get; set; } = null!; 
        public virtual DbSet<Caucao> Caucaos { get; set; } = null!;
        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<Cpostal> Cpostals { get; set; } = null!;
        public virtual DbSet<Devolucao> Devolucaos { get; set; } = null!;
        public virtual DbSet<DriveEases> DriveEases { get; set; } = null!;
        public virtual DbSet<Entrega> Entregas { get; set; } = null!;
        public virtual DbSet<EstadoCarro> EstadoCarros { get; set; } = null!;
        public virtual DbSet<Fatura> Faturas { get; set; } = null!;
        public virtual DbSet<Manutencao> Manutencaos { get; set; } = null!;
        public virtual DbSet<Marca> Marcas { get; set; } = null!;
        public virtual DbSet<Modelo> Modelos { get; set; } = null!;
        public virtual DbSet<Pagamento> Pagamentos { get; set; } = null!;
        public virtual DbSet<Review> Reviews { get; set; } = null!;
        public virtual DbSet<Tecnico> Tecnicos { get; set; } = null!;
        public virtual DbSet<TipoPagamento> TipoPagamentos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();

                optionsBuilder.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    sqlServerOptionsAction: sqlOptions =>
                    {
                        sqlOptions.EnableRetryOnFailure(
                            maxRetryCount: 5,
                            maxRetryDelay: TimeSpan.FromSeconds(30),
                            errorNumbersToAdd: null);
                    });
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Aluguer>(entity =>
            {
                entity.HasKey(e => e.IdAluguer)
                    .HasName("PK__aluguer__9A65BA21F8375203");

                entity.ToTable("aluguer");

                entity.Property(e => e.IdAluguer)
                    .ValueGeneratedNever()
                    .HasColumnName("id_aluguer");

                entity.Property(e => e.CarroIdCarro).HasColumnName("carro_id_carro");

                entity.Property(e => e.CaucaoIdCaucao).HasColumnName("caucao_id_caucao");

                entity.Property(e => e.ClienteIdCliente).HasColumnName("cliente_id_cliente");

                entity.Property(e => e.DataFim)
                    .HasColumnType("datetime")
                    .HasColumnName("data_fim");

                entity.Property(e => e.DataInicio)
                    .HasColumnType("date")
                    .HasColumnName("data_inicio");

                entity.Property(e => e.DriveEaseIdDriveEase).HasColumnName("drive_ease_id_drive_ease");

                entity.Property(e => e.Valor)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("valor");

            });

            modelBuilder.Entity<Carro>(entity =>
            {
                entity.HasKey(e => e.IdCarro)
                    .HasName("PK__carro__D3C318A10909D54C");

                entity.ToTable("carro");

                entity.Property(e => e.IdCarro)
                    .ValueGeneratedNever()
                    .HasColumnName("id_carro");

                entity.Property(e => e.CategoriaCarroIdCategoriaCarro).HasColumnName("categoria_carro_id_categoria_carro");

                entity.Property(e => e.EstadoCarroIdEstadoCarro).HasColumnName("estado_carro_id_estado_carro");

                entity.Property(e => e.Lotacao).HasColumnName("lotacao");

                entity.Property(e => e.Matricula)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("matricula");

                entity.Property(e => e.ModeloIdModelo).HasColumnName("modelo_id_modelo");

                entity.Property(e => e.Tara).HasColumnName("tara");


            });

            modelBuilder.Entity<CategoriaCarro>(entity =>
            {
                entity.HasKey(e => e.IdCategoriaCarro)
                    .HasName("PK__categori__59AE7B044CDE2050");

                entity.ToTable("categoria_carro");

                entity.Property(e => e.IdCategoriaCarro)
                    .ValueGeneratedNever()
                    .HasColumnName("id_categoria_carro");

                entity.Property(e => e.ModeloIdModelo).HasColumnName("modelo_id_modelo");

                entity.Property(e => e.NomeCategoria)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("nome_categoria");

            });

            modelBuilder.Entity<Caucao>(entity =>
            {
                entity.HasKey(e => e.IdCaucao)
                    .HasName("PK__caucao__5B5579FF632FD639");

                entity.ToTable("caucao");

                entity.Property(e => e.IdCaucao)
                    .ValueGeneratedNever()
                    .HasColumnName("id_caucao");

                entity.Property(e => e.Estado)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("estado");

                entity.Property(e => e.Valor)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("valor");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente)
                    .HasName("PK__cliente__677F38F50C78B6CE");

                entity.ToTable("cliente");

                entity.Property(e => e.IdCliente)
                    .ValueGeneratedNever()
                    .HasColumnName("id_cliente");

                entity.Property(e => e.CpostalIdCpostal).HasColumnName("cpostal_id_cpostal");

                entity.Property(e => e.Email)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Morada)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("morada");

                entity.Property(e => e.Nome)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("nome");

                entity.Property(e => e.Ntelemovel).HasColumnName("ntelemovel");

                entity.Property(e => e.Password)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("password");
            });

            modelBuilder.Entity<Cpostal>(entity =>
            {
                entity.HasKey(e => e.IdCpostal)
                    .HasName("PK__cpostal__7ACC4223750B364B");

                entity.ToTable("cpostal");

                entity.Property(e => e.IdCpostal)
                    .ValueGeneratedNever()
                    .HasColumnName("id_cpostal");

                entity.Property(e => e.Fim).HasColumnName("fim");

                entity.Property(e => e.Inicio).HasColumnName("inicio");

                entity.Property(e => e.Localizacao)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("localizacao");
            });

            modelBuilder.Entity<Devolucao>(entity =>
            {
                entity.HasKey(e => e.IdDevolucao)
                    .HasName("PK__devoluca__F014558F1407260A");

                entity.ToTable("devolucao");

                entity.Property(e => e.IdDevolucao)
                    .ValueGeneratedNever()
                    .HasColumnName("id_devolucao");

                entity.Property(e => e.AluguerIdAluguer).HasColumnName("aluguer_id_aluguer");

                entity.Property(e => e.Data)
                    .HasColumnType("date")
                    .HasColumnName("data");

                entity.Property(e => e.Hora)
                    .HasColumnType("datetime")
                    .HasColumnName("hora");

                entity.Property(e => e.TecnicoIdTecnico).HasColumnName("tecnico_id_tecnico");

                entity.Property(e => e.Tipo)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("tipo");

                entity.Property(e => e.ValorExtra)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("valor_extra");

            });

            modelBuilder.Entity<DriveEases>(entity =>
            {
                entity.HasKey(e => e.IdDriveEase)
                    .HasName("PK__drive_ea__D35F3F4AECA266BE");

                entity.ToTable("drive_ease");

                entity.Property(e => e.IdDriveEase)
                    .ValueGeneratedNever()
                    .HasColumnName("id_drive_ease");

                entity.Property(e => e.CpostalIdCpostal).HasColumnName("cpostal_id_cpostal");

                entity.Property(e => e.Email)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Morada)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("morada");

                entity.Property(e => e.Nome)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("nome");

                entity.Property(e => e.Ntelemovel).HasColumnName("ntelemovel");
            });

            modelBuilder.Entity<Entrega>(entity =>
            {
                entity.HasKey(e => e.IdEntrega)
                    .HasName("PK__entrega__017C2C8A32F4789C");

                entity.ToTable("entrega");

                entity.Property(e => e.IdEntrega)
                    .ValueGeneratedNever()
                    .HasColumnName("id_entrega");

                entity.Property(e => e.AluguerIdAluguer).HasColumnName("aluguer_id_aluguer");

                entity.Property(e => e.Data)
                    .HasColumnType("date")
                    .HasColumnName("data");

                entity.Property(e => e.Hora)
                    .HasColumnType("datetime")
                    .HasColumnName("hora");

                entity.Property(e => e.TecnicoIdTecnico).HasColumnName("tecnico_id_tecnico");

            });

            modelBuilder.Entity<EstadoCarro>(entity =>
            {
                entity.HasKey(e => e.IdEstadoCarro)
                    .HasName("PK__estado_c__6F179939137618E1");

                entity.ToTable("estado_carro");

                entity.Property(e => e.IdEstadoCarro)
                    .ValueGeneratedNever()
                    .HasColumnName("id_estado_carro");

                entity.Property(e => e.Nome)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("nome");
            });

            modelBuilder.Entity<Fatura>(entity =>
            {
                entity.HasKey(e => e.IdFatura)
                    .HasName("PK__fatura__F4902DCBEC611D31");

                entity.ToTable("fatura");

                entity.Property(e => e.IdFatura)
                    .ValueGeneratedNever()
                    .HasColumnName("id_fatura");

                entity.Property(e => e.PagamentoIdPagamento).HasColumnName("pagamento_id_pagamento");

            });

            modelBuilder.Entity<Manutencao>(entity =>
            {
                entity.HasKey(e => e.IdManutencao)
                    .HasName("PK__manutenc__5F9D64EE5867C87B");

                entity.ToTable("manutencao");

                entity.Property(e => e.IdManutencao)
                    .ValueGeneratedNever()
                    .HasColumnName("id_manutencao");

                entity.Property(e => e.CarroIdCarro).HasColumnName("carro_id_carro");

                entity.Property(e => e.Custo)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("custo");

                entity.Property(e => e.Data)
                    .HasColumnType("date")
                    .HasColumnName("data");

                entity.Property(e => e.Hora)
                    .HasColumnType("datetime")
                    .HasColumnName("hora");

                entity.Property(e => e.Proposito)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("proposito");

            });

            modelBuilder.Entity<Marca>(entity =>
            {
                entity.HasKey(e => e.IdMarca)
                    .HasName("PK__marca__7E43E99EE697C484");

                entity.ToTable("marca");

                entity.Property(e => e.IdMarca)
                    .ValueGeneratedNever()
                    .HasColumnName("id_marca");

                entity.Property(e => e.NomeMarca)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("nome_marca");
            });

            modelBuilder.Entity<Modelo>(entity =>
            {
                entity.HasKey(e => e.IdModelo)
                    .HasName("PK__modelo__B3BFCFF1C7735D1C");

                entity.ToTable("modelo");

                entity.Property(e => e.IdModelo)
                    .ValueGeneratedNever()
                    .HasColumnName("id_modelo");

                entity.Property(e => e.MarcaIdMarca).HasColumnName("marca_id_marca");

                entity.Property(e => e.NomeModelo)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("nome_modelo");
            });

            modelBuilder.Entity<Pagamento>(entity =>
            {
                entity.HasKey(e => e.IdPagamento)
                    .HasName("PK__pagament__3A2D33F72137B179");

                entity.ToTable("pagamento");

                entity.Property(e => e.IdPagamento)
                    .ValueGeneratedNever()
                    .HasColumnName("id_pagamento");

                entity.Property(e => e.AluguerIdAluguer).HasColumnName("aluguer_id_aluguer");

                entity.Property(e => e.Data)
                    .HasColumnType("date")
                    .HasColumnName("data");

                entity.Property(e => e.Metodo)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("metodo");

                entity.Property(e => e.TipoPagamentoIdTipoPagamento).HasColumnName("tipo_pagamento_id_tipo_pagamento");

                entity.Property(e => e.Valor)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("valor");
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.HasKey(e => e.IdReview)
                    .HasName("PK__review__2F79F8C720E6BE66");

                entity.ToTable("review");

                entity.Property(e => e.IdReview)
                    .ValueGeneratedNever()
                    .HasColumnName("id_review");

                entity.Property(e => e.AluguerIdAluguer).HasColumnName("aluguer_id_aluguer");

                entity.Property(e => e.Observacoes)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("observacoes");
            });

            modelBuilder.Entity<Tecnico>(entity =>
            {
                entity.HasKey(e => e.IdTecnico)
                    .HasName("PK__tecnico__D550973742A1F47B");

                entity.ToTable("tecnico");

                entity.Property(e => e.IdTecnico)
                    .ValueGeneratedNever()
                    .HasColumnName("id_tecnico");

                entity.Property(e => e.CpostalIdCpostal).HasColumnName("cpostal_id_cpostal");

                entity.Property(e => e.Email)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Morada)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("morada");

                entity.Property(e => e.Nome)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("nome");

                entity.Property(e => e.Ntelemovel).HasColumnName("ntelemovel");

                entity.Property(e => e.Password)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("password");
            });

            modelBuilder.Entity<TipoPagamento>(entity =>
            {
                entity.HasKey(e => e.IdTipoPagamento)
                    .HasName("PK__tipo_pag__01B984C7806933CE");

                entity.ToTable("tipo_pagamento");

                entity.Property(e => e.IdTipoPagamento)
                    .ValueGeneratedNever()
                    .HasColumnName("id_tipo_pagamento");

                entity.Property(e => e.NomeTipo)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("nome_tipo");
            });

            OnModelCreatingPartial(modelBuilder);
        }
        

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
