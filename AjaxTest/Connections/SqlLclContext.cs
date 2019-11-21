using AjaxTest.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Configuration;
using System.Data.Entity;

namespace AjaxTest.Connections
{
    public class SqlLclContext : IdentityDbContext<AppUser>
    {

        public SqlLclContext() : base(GetSqlConnectionStr()) {
            Database.SetInitializer<SqlLclContext>(null);
        }

        public DbSet<AppRole> appRoles { get; set; }
        public DbSet<AppUserRoles> userRoles { get; set; }

        private static string GetSqlConnectionStr()
        {
            var c1 = ConfigurationManager.ConnectionStrings["AdWorks16Lcl"];
            return c1.ConnectionString;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}