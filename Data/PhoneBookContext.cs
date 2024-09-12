using Microsoft.EntityFrameworkCore;
using Phonebook.Models;
using System.Configuration;

namespace Phonebook.Data;

public class PhoneBookContext : DbContext
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Contact> Contacts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["LocalDbConnection"].ConnectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Contact>()
            .HasOne(c => c.Category)
            .WithOne(cat => cat.Contact)
            .HasForeignKey<Contact>(c => c.CategoryId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}
