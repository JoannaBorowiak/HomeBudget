﻿// <auto-generated />
using System;
using KalkulatorBudzetowy.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace KalkulatorBudzetowy.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241111084751_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.10");

            modelBuilder.Entity("KalkulatorBudzetowy.Models.Przychod", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Data")
                        .HasColumnType("TEXT");

                    b.Property<string>("Kategoria")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Kwota")
                        .HasColumnType("TEXT");

                    b.Property<string>("Opis")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Przychody");
                });

            modelBuilder.Entity("KalkulatorBudzetowy.Models.Wydatek", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Data")
                        .HasColumnType("TEXT");

                    b.Property<string>("Kategoria")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Kwota")
                        .HasColumnType("TEXT");

                    b.Property<string>("Opis")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Wydatki");
                });
#pragma warning restore 612, 618
        }
    }
}
