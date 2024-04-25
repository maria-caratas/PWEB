﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WebApplication8.Data;

#nullable disable

namespace WebApplication8.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240401192154_V2")]
    partial class V2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("WebApplication8.Models.CapitolInvatare", b =>
                {
                    b.Property<int>("CapitolInvatareId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CapitolInvatareId"));

                    b.Property<string>("Continut")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Titlu")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("CapitolInvatareId");

                    b.ToTable("CapitolInvatare", (string)null);
                });

            modelBuilder.Entity("WebApplication8.Models.IntrebariQuizz", b =>
                {
                    b.Property<int>("IntrebareId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IntrebareId"));

                    b.Property<string[]>("OptiuniRaspuns")
                        .IsRequired()
                        .HasColumnType("text[]");

                    b.Property<int>("RaspunsCorect")
                        .HasColumnType("integer");

                    b.Property<string>("TextIntrebare")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("IntrebareId");

                    b.ToTable("IntrebariQuizz", (string)null);
                });

            modelBuilder.Entity("WebApplication8.Models.IstoricRezultate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataRezultat")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("RezultatQuizzId")
                        .HasColumnType("integer");

                    b.Property<int>("Scor")
                        .HasColumnType("integer");

                    b.Property<int>("UtilizatorId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Istorice");
                });

            modelBuilder.Entity("WebApplication8.Models.RezultatQuizz", b =>
                {
                    b.Property<int>("RezultatQuizzId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("RezultatQuizzId"));

                    b.Property<int>("IntrebareId")
                        .HasColumnType("integer");

                    b.Property<int>("ScorObtinut")
                        .HasColumnType("integer");

                    b.Property<int>("UtilizatorId")
                        .HasColumnType("integer");

                    b.HasKey("RezultatQuizzId");

                    b.ToTable("RezultatQuizz", (string)null);
                });

            modelBuilder.Entity("WebApplication8.Models.Todo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Todo", (string)null);
                });

            modelBuilder.Entity("WebApplication8.Models.Utilizator", b =>
                {
                    b.Property<int>("UtilizatorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("UtilizatorId"));

                    b.Property<string>("NumeUtilizator")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Parola")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Rol")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("UtilizatorId");

                    b.ToTable("Utilizatori");
                });
#pragma warning restore 612, 618
        }
    }
}
