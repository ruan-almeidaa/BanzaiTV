﻿// <auto-generated />
using System;
using BanzaiTV.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BanzaiTV.Migrations
{
    [DbContext(typeof(BancoContext))]
    [Migration("20240715224434_AdicionarTabelaMensalidades")]
    partial class AdicionarTabelaMensalidades
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.18")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BanzaiTV.Models.AdministradorModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("senha")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Administrador");
                });

            modelBuilder.Entity("BanzaiTV.Models.ClienteModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("Ativo")
                        .HasColumnType("boolean");

                    b.Property<string>("Celular")
                        .HasColumnType("text");

                    b.Property<string>("Cpf")
                        .HasColumnType("text");

                    b.Property<int>("DiaVencimento")
                        .HasColumnType("integer");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("PlanoId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("BanzaiTV.Models.MensalidadeModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DataPagamento")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DataVencimento")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("IdCliente")
                        .HasColumnType("integer");

                    b.Property<double>("Valor")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.ToTable("Mensalidades");
                });

            modelBuilder.Entity("BanzaiTV.Models.PlanoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("mesesDuracao")
                        .HasColumnType("integer");

                    b.Property<double>("valor")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.ToTable("Planos");
                });
#pragma warning restore 612, 618
        }
    }
}
