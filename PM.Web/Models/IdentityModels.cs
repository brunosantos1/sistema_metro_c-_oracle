using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace PM.Web.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext() : base("ConnectionDev", throwIfV1Schema: false)
        {
            Database.SetInitializer<IdentityDbContext>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("OO0009T".ToUpper());

        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

       // public System.Data.Entity.DbSet<PM.Domain.Entities.SistemaPerfil> SistemaPerfils { get; set; }

       // public System.Data.Entity.DbSet<PM.Domain.Entities.SistemaLogAcesso> SistemaLogAcessoes { get; set; }
    }
}