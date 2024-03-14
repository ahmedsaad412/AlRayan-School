using AlRayan.Models;
using AlRayan.Models.MainEntity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AlRayan.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Student_Course> Student_Courses{ get; set; }
        public DbSet<Center> Centers{ get; set; }
        public DbSet<Teatcher> Teatchers{ get; set; }
        public DbSet<Student> Students{ get; set; }
        public DbSet<Course> Courses{ get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ApplicationUser>().HasQueryFilter(p=>!p.IsDeleted);
            builder.Entity<Center>().HasQueryFilter(p=>!p.IsDeleted);
            builder.Entity<Teatcher>().HasQueryFilter(p=>!p.IsDeleted);
            builder.Entity<Student>().HasQueryFilter(p=>!p.IsDeleted);
            builder.Entity<Course>().HasQueryFilter(p=>!p.IsDeleted);
            builder.Entity<Student_Course>().HasQueryFilter(p=>!p.IsDeleted);

            base.OnModelCreating(builder);
            builder.Entity<ApplicationUser>().ToTable("Users","security");
            builder.Entity<IdentityRole>().ToTable("Roles","security");
            builder.Entity<IdentityUserRole<string>>().ToTable("UserRoles","security");
            builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims","security");
            builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins","security");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims","security");
            builder.Entity<IdentityUserToken<string>>().ToTable("UserTokens","security");
            
        }
    }
}
