
using Microsoft.EntityFrameworkCore;
using SchoolWebApi.Model;

namespace SchoolWebApi.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Student> Students => Set<Student>();
        public DbSet<School> Schools => Set<School>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Student>()
                .Property(s => s.CreatedDate)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Student>()
                .Property(s => s.UpdatedDate)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<School>()
                .Property(s => s.CreatedDate)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<School>()
                .Property(s => s.UpdatedDate)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("GETDATE()");

        }

        

    }

}