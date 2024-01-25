using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Rillion.Domain.Entities;

namespace Rillion.Infrastructure;

public class ApplicationDbContext : IdentityDbContext<IdentityUser<long>, IdentityRole<long>, long>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : base(options)
    {
    }

    public DbSet<Expense> Expenses { get; set; }
    public DbSet<Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Category>()
            .HasIndex(category => category.Name)
            .IsUnique();

        modelBuilder.Entity<Expense>()
            .HasOne(expense => expense.Category)
            .WithMany(category => category.Expenses)
            .HasForeignKey(expense => expense.CategoryId)
            .IsRequired(true);
    }
}