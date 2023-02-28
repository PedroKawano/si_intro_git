using FatecLibrary.BookAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace FatecLibrary.BookAPI.Context;

public class AppDBContext : DbContext
{
    public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }

    // Aqui definimos o mapeamento dos objetos relacionais BD
    public DbSet<Publishing> Publishers { get; set; }
    public DbSet<Book> Books { get; set; }

    // Aqui usamos Fluent API e não Data Annotations
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Publishing>()
            .HasKey(x => x.Id);
        modelBuilder.Entity<Publishing>()
            .Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(100);
        modelBuilder.Entity<Publishing>()
            .Property(p => p.Acronym)
            .HasMaxLength(10);

        modelBuilder.Entity<Book>()
            .HasKey(x => x.Id);
        modelBuilder.Entity<Book>()
            .Property(x => x.Title)
            .IsRequired()
            .HasMaxLength(100);
        modelBuilder.Entity<Book>()
            .Property(x => x.Price)
            .IsRequired()
            .HasPrecision(8, 2);
        modelBuilder.Entity<Book>()
            .Property(x => x.PublicationYear)
            .IsRequired();
        modelBuilder.Entity<Book>()
            .Property(x => x.Edition)
            .IsRequired();
        modelBuilder.Entity<Book>()
            .Property(x => x.ImageURL)
            .HasMaxLength(255);

        // Relacionamento
        modelBuilder.Entity<Publishing>()
            .HasMany(x => x.Books)
            .WithOne(x => x.Publishing)
            .HasForeignKey(x => x.PublishingId);

        // Seed
        modelBuilder.Entity<Publishing>().HasData(
            new Publishing
            {
                Id = 1,
                Name = "Alta Books",
                Acronym = "AB"
            },
            new Publishing
            {
                Id = 2,
                Name = "Novatec Editora",
                Acronym = "NE"
            },
            new Publishing
            {
                Id = 3,
                Name = "Casa do Código",
                Acronym = "CC"
            });

        modelBuilder.Entity<Book>().HasData(
            new Book
            {
                Id = 1,
                Title = "Clean Code",
                Price = 59.90m,
                PublicationYear = 2008,
                Edition = 1,
            }
            );
    }
}
