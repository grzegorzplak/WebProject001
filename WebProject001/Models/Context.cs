using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Reflection.Emit;
using WebProject001.Models;
using WebProject001.ViewModels;

namespace WebProject001.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<Expenditure> Expenditures { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDbFunction(typeof(Context).GetMethod(nameof(GetYearMonth), new[] { typeof(DateOnly) }))
                .HasName("YearMonth");
        }

        public string GetYearMonth(DateOnly? myDate)
            => throw new NotSupportedException();
    }
}
