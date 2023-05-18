using BackendExam.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BackendExam.Persistence.Context
{
    public class SqlServerDbContext : DbContext
    {
        public SqlServerDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasIndex(f => f.IdentityNo);
            modelBuilder.Entity<Employee>().HasIndex(f => f.Name);
            modelBuilder.Entity<Employee>().HasIndex(f => f.Surname);
            modelBuilder.Entity<Employee>().Property(x => x.IdentityNo).HasMaxLength(11);
            modelBuilder.Entity<Employee>().Property(x => x.Name).HasMaxLength(60);
            modelBuilder.Entity<Employee>().Property(x => x.Surname).HasMaxLength(60);
            modelBuilder.Entity<Employee>()
                .HasMany(f => f.WorkLogs)
                .WithOne(f => f.Employee)
                .HasForeignKey(f => f.EmployeeId)
                .HasPrincipalKey(f => f.Id);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<WorkLog> WorkLogs { get; set; }
    }
}
