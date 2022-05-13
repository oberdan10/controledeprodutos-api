﻿// <auto-generated />
using System;
using ControleDeProdutos_API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ControleDeProdutos_API.Migrations
{
    [DbContext(typeof(Data.AppContext))]
    partial class AppContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ControleDeProdutos_API.Models.Categoria", b =>
                {
                    b.Property<long?>("codigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("descricao")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)");

                    b.Property<string>("familia")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)");

                    b.HasKey("codigo");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("ControleDeProdutos_API.Models.Cliente", b =>
                {
                    b.Property<long?>("codigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long?>("cpf")
                        .IsRequired()
                        .HasColumnType("bigint");

                    b.Property<long>("empresaId")
                        .HasColumnType("bigint");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)");

                    b.Property<string>("tipoCliente")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("codigo");

                    b.HasIndex("empresaId");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("ControleDeProdutos_API.Models.Empresa", b =>
                {
                    b.Property<long>("codigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long>("cnpj")
                        .HasColumnType("bigint");

                    b.Property<string>("descricao")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)");

                    b.HasKey("codigo");

                    b.ToTable("Empresas");
                });

            modelBuilder.Entity("ControleDeProdutos_API.Models.Funcionario", b =>
                {
                    b.Property<long>("codigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long?>("cpf")
                        .IsRequired()
                        .HasColumnType("bigint");

                    b.Property<long>("empresaId")
                        .HasColumnType("bigint");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)");

                    b.HasKey("codigo");

                    b.HasIndex("empresaId");

                    b.ToTable("Funcionarios");
                });

            modelBuilder.Entity("ControleDeProdutos_API.Models.Item", b =>
                {
                    b.Property<long?>("codigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long>("categoriaId")
                        .HasColumnType("bigint");

                    b.Property<string>("descricao")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)");

                    b.Property<string>("lote")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<string>("observacao")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.HasKey("codigo");

                    b.HasIndex("categoriaId");

                    b.ToTable("Itens");
                });

            modelBuilder.Entity("ControleDeProdutos_API.Models.Nota", b =>
                {
                    b.Property<long?>("codigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long?>("empresaId")
                        .IsRequired()
                        .HasColumnType("bigint");

                    b.Property<long?>("nota")
                        .HasColumnType("bigint");

                    b.Property<long?>("serie")
                        .HasColumnType("bigint");

                    b.Property<double?>("valorTotal")
                        .HasColumnType("double");

                    b.HasKey("codigo");

                    b.HasIndex("empresaId");

                    b.ToTable("Notas");
                });

            modelBuilder.Entity("ControleDeProdutos_API.Models.Cliente", b =>
                {
                    b.HasOne("ControleDeProdutos_API.Models.Empresa", "Empresa")
                        .WithMany("Cliente")
                        .HasForeignKey("empresaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Empresa");
                });

            modelBuilder.Entity("ControleDeProdutos_API.Models.Funcionario", b =>
                {
                    b.HasOne("ControleDeProdutos_API.Models.Empresa", "Empresa")
                        .WithMany("Funcionario")
                        .HasForeignKey("empresaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Empresa");
                });

            modelBuilder.Entity("ControleDeProdutos_API.Models.Item", b =>
                {
                    b.HasOne("ControleDeProdutos_API.Models.Categoria", "Categoria")
                        .WithMany("Item")
                        .HasForeignKey("categoriaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("ControleDeProdutos_API.Models.Nota", b =>
                {
                    b.HasOne("ControleDeProdutos_API.Models.Empresa", "Empresa")
                        .WithMany("Nota")
                        .HasForeignKey("empresaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Empresa");
                });

            modelBuilder.Entity("ControleDeProdutos_API.Models.Categoria", b =>
                {
                    b.Navigation("Item");
                });

            modelBuilder.Entity("ControleDeProdutos_API.Models.Empresa", b =>
                {
                    b.Navigation("Cliente");

                    b.Navigation("Funcionario");

                    b.Navigation("Nota");
                });
#pragma warning restore 612, 618
        }
    }
}
