﻿// <auto-generated />
using Ecommerce.Service.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Ecommerce.Service.Migrations
{
    [DbContext(typeof(EcommerceContext))]
    [Migration("20210515220537_chaveComposta")]
    partial class chaveComposta
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Ecommerce.Service.Model.Cliente", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("cpf")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("cliente");
                });

            modelBuilder.Entity("Ecommerce.Service.Model.Item", b =>
                {
                    b.Property<int>("pedidoId")
                        .HasColumnType("int");

                    b.Property<int>("produtoId")
                        .HasColumnType("int");

                    b.Property<int>("quantidade")
                        .HasColumnType("int");

                    b.HasKey("pedidoId", "produtoId");

                    b.HasIndex("produtoId");

                    b.ToTable("item");
                });

            modelBuilder.Entity("Ecommerce.Service.Model.Pedido", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("clienteId")
                        .HasColumnType("int");

                    b.Property<string>("dataPedido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("pedidoId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("clienteId");

                    b.ToTable("pedido");
                });

            modelBuilder.Entity("Ecommerce.Service.Model.Produto", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("estoque")
                        .HasColumnType("int");

                    b.Property<string>("nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("preco")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("produto");
                });

            modelBuilder.Entity("Ecommerce.Service.Model.Item", b =>
                {
                    b.HasOne("Ecommerce.Service.Model.Pedido", "pedido")
                        .WithMany()
                        .HasForeignKey("pedidoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ecommerce.Service.Model.Produto", "Produto")
                        .WithMany()
                        .HasForeignKey("produtoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("pedido");

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("Ecommerce.Service.Model.Pedido", b =>
                {
                    b.HasOne("Ecommerce.Service.Model.Cliente", "cliente")
                        .WithMany()
                        .HasForeignKey("clienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("cliente");
                });
#pragma warning restore 612, 618
        }
    }
}
