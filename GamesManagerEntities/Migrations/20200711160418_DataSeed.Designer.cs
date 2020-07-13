﻿// <auto-generated />
using GameManagerEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace GameManagerEntities.Migrations
{
    [DbContext(typeof(GamesManagerDbContext))]
    [Migration("20200711160418_DataSeed")]
    partial class DataSeed
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("GameManagerEntities.Models.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("MaxPlayers")
                        .HasColumnType("integer");

                    b.Property<int>("MinAge")
                        .HasColumnType("integer");

                    b.Property<int>("MinPlayers")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("character varying(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Games");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            MaxPlayers = 5,
                            MinAge = 7,
                            MinPlayers = 2,
                            Name = "Game 1"
                        },
                        new
                        {
                            Id = 2,
                            MaxPlayers = 10,
                            MinAge = 15,
                            MinPlayers = 5,
                            Name = "Game 2"
                        },
                        new
                        {
                            Id = 3,
                            MaxPlayers = 4,
                            MinAge = 12,
                            MinPlayers = 1,
                            Name = "Game 3"
                        },
                        new
                        {
                            Id = 4,
                            MaxPlayers = 8,
                            MinAge = 12,
                            MinPlayers = 2,
                            Name = "Game 4"
                        },
                        new
                        {
                            Id = 5,
                            MaxPlayers = 6,
                            MinAge = 4,
                            MinPlayers = 2,
                            Name = "Game 5"
                        },
                        new
                        {
                            Id = 6,
                            MaxPlayers = 12,
                            MinAge = 16,
                            MinPlayers = 4,
                            Name = "Game 6"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
