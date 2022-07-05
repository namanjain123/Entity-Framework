using Microsoft.EntityFrameworkCore;
using Model.EntityConfiguration;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Model
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option)
        : base(option) { }
        public DbSet<ExpenseHeader> ExpenseHeaders { get; set; }
        public DbSet<ExpenseLine> ExpenseLine
        {
            get; set;
        }
        public DbSet<User> Users
        {
            get; set;
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            builder.Entity<ExpenseLine>()
                .Property(e => e.ToatalCost)
                .HasComputedColumnSql("[Quanity]*[UniCost]");
            //builder.Entity<User>()
            //    .Property(p => p.FullName)
            //    .HasComputedColumnSql("[FirstName]+' '+[LastName]");
            builder.Entity<ExpenseHeader>()
                .Property(e => e.UsdExchangeRate)
                .HasColumnType($"decimal(13,4")
                .IsRequired(true);
            builder.Entity<ExpenseHeader>()
                .HasOne(e => e.Requester)
                .WithMany(e => e.RequestExpenseHeaders)
                .HasForeignKey(e => e.RequesterID)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(true);
            //builder.ApplyConfiguration(new UserConfiguration());
        }
        protected override void OnConfiguring(DbContextOptionsBuilder option)
        {
        }

        
    }
}
