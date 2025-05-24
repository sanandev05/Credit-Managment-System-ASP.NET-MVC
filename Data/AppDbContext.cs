using Credit_Managment_System_ASP.NET_MVC.Models;
using Microsoft.EntityFrameworkCore;
using Credit_Managment_System_ASP.NET_MVC.View_Models;

namespace Credit_Managment_System_ASP.NET_MVC.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Merchant> Merchants { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<LoanItem> LoanItems { get; set; }
        public DbSet<LoanDetail> LoanDetails { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<LoanItem>()
            .HasOne(li => li.Loan)
            .WithMany(l => l.LoanItems)
            .HasForeignKey(li => li.LoanId)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Branch>()
                .HasOne(b => b.Merchant)
                .WithMany(m => m.Branches)
                .HasForeignKey(b => b.MerchantId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Branch>()
                .HasMany(b => b.Employees)
                .WithOne()
                .HasForeignKey(e => e.BranchId)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Employee>()
        .HasOne(e => e.Branch)
        .WithMany(b => b.Employees)
        .HasForeignKey(e => e.BranchId)
        .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
