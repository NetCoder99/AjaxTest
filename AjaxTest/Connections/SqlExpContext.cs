using AjaxTest.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Configuration;
using System.Data.Entity;

namespace AjaxTest.Connections
{
    public class SqlExpContext : IdentityDbContext<AppUser>
    {
        public SqlExpContext() : base(GetSqlConnectionStr()) { }

        public DbSet<AppRole> appRoles { get; set; }
        public DbSet<AppUserRoles> userRoles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("Security");
        }

        private static string GetSqlConnectionStr()
        {
            var c1 = ConfigurationManager.ConnectionStrings["AdWorks16Exp"];
            return c1.ConnectionString;
        }

    }
}



//public SqlExpContext()
//{ this.Database.Connection.ConnectionString = GetSqlConnectionStr(); }

//public DbSet<CountryCode> CountryCodes { get; set; }
//public DbSet<StateCode> StateCodes { get; set; }

//private static string GetSqlConnectionStr()
//{
//    var c1 = ConfigurationManager.ConnectionStrings["AdWorks16Exp"];
//    return c1.ConnectionString;
//}