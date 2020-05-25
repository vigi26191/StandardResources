using Microsoft.AspNet.Identity.EntityFramework;
using StandardResources.Entities.Domain;
using System.Data.Entity;

namespace StandardResources.DAL
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, int, ApplicationUserLogin, ApplicationUserRole, ApplicationUserClaim>
    {
        public ApplicationDbContext() : base("StandardResourcesContext")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>().ToTable("tblUsers");
            modelBuilder.Entity<ApplicationRole>().ToTable("tblRoles");
            modelBuilder.Entity<ApplicationUserRole>().ToTable("tblUserRoles");
            modelBuilder.Entity<ApplicationUserClaim>().ToTable("tblUserClaims");
            modelBuilder.Entity<ApplicationUserLogin>().ToTable("tblUserLogins");

        }
    }
}
