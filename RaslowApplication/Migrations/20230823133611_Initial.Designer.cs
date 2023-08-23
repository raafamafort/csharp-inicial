﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;
using RaslowApplication.Persistence;

#nullable disable

namespace RaslowApplication.Migrations
{
    [DbContext(typeof(OracleDbContext))]
    [Migration("20230823133611_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            OracleModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RaslowApplication.Models.Hospede", b =>
                {
                    b.Property<int>("HospedeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HospedeID"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Sobrenome")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("HospedeID");

                    b.ToTable("Hospedes");
                });

            modelBuilder.Entity("RaslowApplication.Models.Pagamento", b =>
                {
                    b.Property<int>("PagamentoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PagamentoID"));

                    b.Property<DateTime>("DataPagamento")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<int>("ReservaID")
                        .HasColumnType("NUMBER(10)");

                    b.Property<decimal>("Valor")
                        .HasColumnType("DECIMAL(18, 2)");

                    b.HasKey("PagamentoID");

                    b.HasIndex("ReservaID");

                    b.ToTable("Pagamentos");
                });

            modelBuilder.Entity("RaslowApplication.Models.Quarto", b =>
                {
                    b.Property<int>("QuartoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("QuartoID"));

                    b.Property<string>("NumeroQuarto")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<decimal>("PrecoPorNoite")
                        .HasColumnType("DECIMAL(18, 2)");

                    b.Property<int>("TipoQuartoID")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("QuartoID");

                    b.HasIndex("TipoQuartoID");

                    b.ToTable("Quartos");
                });

            modelBuilder.Entity("RaslowApplication.Models.Reserva", b =>
                {
                    b.Property<int>("ReservaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReservaID"));

                    b.Property<DateTime>("DataEntrada")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<DateTime>("DataSaida")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<int>("HospedeID")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("QuartoID")
                        .HasColumnType("NUMBER(10)");

                    b.Property<decimal>("ValorTotal")
                        .HasColumnType("DECIMAL(18, 2)");

                    b.HasKey("ReservaID");

                    b.HasIndex("HospedeID")
                        .IsUnique();

                    b.HasIndex("QuartoID");

                    b.ToTable("Reservas");
                });

            modelBuilder.Entity("RaslowApplication.Models.TipoQuarto", b =>
                {
                    b.Property<int>("TipoQuartoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TipoQuartoID"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("TipoQuartoID");

                    b.ToTable("TiposQuarto");
                });

            modelBuilder.Entity("RaslowApplication.Models.Pagamento", b =>
                {
                    b.HasOne("RaslowApplication.Models.Reserva", "Reserva")
                        .WithMany("Pagamentos")
                        .HasForeignKey("ReservaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Reserva");
                });

            modelBuilder.Entity("RaslowApplication.Models.Quarto", b =>
                {
                    b.HasOne("RaslowApplication.Models.TipoQuarto", "TipoQuarto")
                        .WithMany("Quartos")
                        .HasForeignKey("TipoQuartoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TipoQuarto");
                });

            modelBuilder.Entity("RaslowApplication.Models.Reserva", b =>
                {
                    b.HasOne("RaslowApplication.Models.Hospede", "Hospede")
                        .WithOne("Reserva")
                        .HasForeignKey("RaslowApplication.Models.Reserva", "HospedeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RaslowApplication.Models.Quarto", "Quarto")
                        .WithMany("Reservas")
                        .HasForeignKey("QuartoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hospede");

                    b.Navigation("Quarto");
                });

            modelBuilder.Entity("RaslowApplication.Models.Hospede", b =>
                {
                    b.Navigation("Reserva")
                        .IsRequired();
                });

            modelBuilder.Entity("RaslowApplication.Models.Quarto", b =>
                {
                    b.Navigation("Reservas");
                });

            modelBuilder.Entity("RaslowApplication.Models.Reserva", b =>
                {
                    b.Navigation("Pagamentos");
                });

            modelBuilder.Entity("RaslowApplication.Models.TipoQuarto", b =>
                {
                    b.Navigation("Quartos");
                });
#pragma warning restore 612, 618
        }
    }
}
