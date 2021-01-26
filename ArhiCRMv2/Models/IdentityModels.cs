using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ArhiCRMv2.Models
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
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<Amplasament> Amplasaments { get; set; }
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<Aviz> Avizs { get; set; }
        public virtual DbSet<Avizator> Avizators { get; set; }
        public virtual DbSet<AvizToProiectMapping> AvizToProiectMappings { get; set; }
        public virtual DbSet<Beneficiar> Beneficiars { get; set; }
        public virtual DbSet<Colaborator> Colaborators { get; set; }
        public virtual DbSet<Judet> Judets { get; set; }
        public virtual DbSet<Localitate> Localitates { get; set; }
        public virtual DbSet<Observatie> Observaties { get; set; }
        public virtual DbSet<Plata> Platas { get; set; }
        public virtual DbSet<Proiect> Proiects { get; set; }
        public virtual DbSet<ProiectTehnic> ProiectTehnics { get; set; }
        public virtual DbSet<ProiectTehnicToProiectMapping> ProiectTehnicToProiectMappings { get; set; }
        public virtual DbSet<ResponsabilitateBeneficiar> ResponsabilitateBeneficiars { get; set; }
        public virtual DbSet<ResponsabilitateToProiectMapping> ResponsabilitateToProiectMappings { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<Studiu> Studius { get; set; }
        public virtual DbSet<StudiuToProiectMapping> StudiuToProiectMappings { get; set; }
        public virtual DbSet<TipProiect> TipProiects { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}