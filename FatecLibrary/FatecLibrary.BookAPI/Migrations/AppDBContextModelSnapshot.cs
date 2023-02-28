﻿// <auto-generated />
using FatecLibrary.BookAPI.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FatecLibrary.BookAPI.Migrations
{
    [DbContext(typeof(AppDBContext))]
    partial class AppDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("FatecLibrary.BookAPI.Models.Entities.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Edition")
                        .HasColumnType("int");

                    b.Property<string>("ImageURL")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<decimal>("Price")
                        .HasPrecision(8, 2)
                        .HasColumnType("decimal(8,2)");

                    b.Property<int>("PublicationYear")
                        .HasColumnType("int");

                    b.Property<int>("PublishingId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("PublishingId");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Edition = 1,
                            Price = 59.90m,
                            PublicationYear = 2008,
                            PublishingId = 0,
                            Title = "Clean Code"
                        });
                });

            modelBuilder.Entity("FatecLibrary.BookAPI.Models.Entities.Publishing", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Acronym")
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Publishers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Acronym = "AB",
                            Name = "Alta Books"
                        },
                        new
                        {
                            Id = 2,
                            Acronym = "NE",
                            Name = "Novatec Editora"
                        },
                        new
                        {
                            Id = 3,
                            Acronym = "CC",
                            Name = "Casa do Código"
                        });
                });

            modelBuilder.Entity("FatecLibrary.BookAPI.Models.Entities.Book", b =>
                {
                    b.HasOne("FatecLibrary.BookAPI.Models.Entities.Publishing", "Publishing")
                        .WithMany("Books")
                        .HasForeignKey("PublishingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Publishing");
                });

            modelBuilder.Entity("FatecLibrary.BookAPI.Models.Entities.Publishing", b =>
                {
                    b.Navigation("Books");
                });
#pragma warning restore 612, 618
        }
    }
}
