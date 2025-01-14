﻿// <auto-generated />
using erp_ordem_servico_api.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace erpordemservicoapi.Migrations
{
    [DbContext(typeof(ErpDbContext))]
    partial class ErpDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("LaboratorioDev.Entity.Atividade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("atividades");
                });

            modelBuilder.Entity("LaboratorioDev.Entity.OrdemServico", b =>
                {
                    b.Property<int>("Numero")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Numero");

                    b.ToTable("ordem_servico");
                });
#pragma warning restore 612, 618
        }
    }
}
