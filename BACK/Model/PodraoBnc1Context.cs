using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BACK.Model;

public partial class PodraoBnc1Context : DbContext
{
    public PodraoBnc1Context()
    {
    }

    public PodraoBnc1Context(DbContextOptions<PodraoBnc1Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Adm> Adms { get; set; }

    public virtual DbSet<Cardapio> Cardapios { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Pedido> Pedidos { get; set; }

    public virtual DbSet<PedidodoCliente> PedidodoClientes { get; set; }

    public virtual DbSet<Produto> Produtos { get; set; }

    public virtual DbSet<Promocao> Promocaos { get; set; }

    public virtual DbSet<Totem> Totems { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=CT-C-001YF\\SQLEXPRESS01;Initial Catalog=PodraoBnc1;Integrated Security=True;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Adm>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Adm__3214EC276F34CCA5");

            entity.ToTable("Adm");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Cpf)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Genero)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Nome)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Senha)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Cardapio>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Cardapio__3214EC27A9A6B38A");

            entity.ToTable("Cardapio");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ProdutoId).HasColumnName("ProdutoID");

            entity.HasOne(d => d.Produto).WithMany(p => p.Cardapios)
                .HasForeignKey(d => d.ProdutoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Cardapio__Produt__4E88ABD4");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Cliente__3214EC27EA48D5B1");

            entity.ToTable("Cliente");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Cpf)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Genero)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Nome)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Salt)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Senha)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.TerminodoPedido).HasColumnType("datetime");
        });

        modelBuilder.Entity<Pedido>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Pedido__3214EC273A623065");

            entity.ToTable("Pedido");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ClienteId).HasColumnName("ClienteID");
            entity.Property(e => e.EntregadoPedido).HasColumnType("datetime");
            entity.Property(e => e.ProdutoId).HasColumnName("ProdutoID");
            entity.Property(e => e.PromocaoId).HasColumnName("PromocaoID");

            entity.HasOne(d => d.Cliente).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.ClienteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Pedido__ClienteI__59063A47");

            entity.HasOne(d => d.Produto).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.ProdutoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Pedido__ProdutoI__5AEE82B9");

            entity.HasOne(d => d.Promocao).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.PromocaoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Pedido__Promocao__59FA5E80");
        });

        modelBuilder.Entity<PedidodoCliente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Pedidodo__3214EC2723C1CC78");

            entity.ToTable("PedidodoCliente");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.PedidoId).HasColumnName("PedidoID");

            entity.HasOne(d => d.Cliente).WithMany(p => p.PedidodoClientes)
                .HasForeignKey(d => d.ClienteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PedidodoC__Clien__5DCAEF64");

            entity.HasOne(d => d.Pedido).WithMany(p => p.PedidodoClientes)
                .HasForeignKey(d => d.PedidoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PedidodoC__Pedid__5EBF139D");
        });

        modelBuilder.Entity<Produto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Produto__3214EC27709CF403");

            entity.ToTable("Produto");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DescricaoProduto)
                .HasMaxLength(400)
                .IsUnicode(false);
            entity.Property(e => e.NomeProduto)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Preco).HasColumnType("decimal(5, 2)");
        });

        modelBuilder.Entity<Promocao>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Promocao__3214EC2770108D9C");

            entity.ToTable("Promocao");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DescricaoPromocao)
                .HasMaxLength(400)
                .IsUnicode(false);
            entity.Property(e => e.NomePromocao)
                .HasMaxLength(80)
                .IsUnicode(false);
            entity.Property(e => e.Preco).HasColumnType("decimal(5, 2)");
        });

        modelBuilder.Entity<Totem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Totem__3214EC2774786CDC");

            entity.ToTable("Totem");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CardapioId).HasColumnName("CardapioID");
            entity.Property(e => e.PromocaoId).HasColumnName("PromocaoID");

            entity.HasOne(d => d.Cardapio).WithMany(p => p.Totems)
                .HasForeignKey(d => d.CardapioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Totem__CardapioI__534D60F1");

            entity.HasOne(d => d.Promocao).WithMany(p => p.Totems)
                .HasForeignKey(d => d.PromocaoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Totem__PromocaoI__5441852A");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
