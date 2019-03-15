﻿// <auto-generated />
using System;
using CsvProcessor.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CsvProcessor.Repository.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20190315003806_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ScvProcessor.Core.Model.Client", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id");

                    b.Property<string>("ClientAddress")
                        .HasColumnName("Client_Address");

                    b.Property<string>("ClientName")
                        .HasColumnName("Client_Name");

                    b.HasKey("Id");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("ScvProcessor.Core.Model.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id");

                    b.Property<int>("ItemCount")
                        .HasColumnName("Item_Count");

                    b.Property<string>("ItemName")
                        .HasColumnName("Item_Name");

                    b.Property<double>("Price")
                        .HasColumnName("Price");

                    b.HasKey("Id");

                    b.ToTable("Order");
                });
#pragma warning restore 612, 618
        }
    }
}
