namespace AjaxTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class app1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetRoles", "RoleId", c => c.Int(identity: true));
            AddColumn("dbo.AspNetRoles", "Description", c => c.String(maxLength: 50));
            AddColumn("dbo.AspNetRoles", "CreateDate", c => c.DateTime());
            AddColumn("dbo.AspNetRoles", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.AspNetUserRoles", "UserRoleId", c => c.Int(identity: true));
            AddColumn("dbo.AspNetUserRoles", "CreateDate", c => c.DateTime());
            AddColumn("dbo.AspNetUserRoles", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String(maxLength: 50));
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String(maxLength: 50));
            AddColumn("dbo.AspNetUsers", "DisplayName", c => c.String(maxLength: 50));
            AddColumn("dbo.AspNetUsers", "PrefEmail", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "PrefText", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "CreateDate", c => c.DateTime(nullable: false));
            CreateIndex("dbo.AspNetRoles", "RoleId", unique: true);
            CreateIndex("dbo.AspNetUserRoles", "UserRoleId", unique: true);
            CreateIndex("dbo.AspNetUsers", "Email", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.AspNetUsers", new[] { "Email" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserRoleId" });
            DropIndex("dbo.AspNetRoles", new[] { "RoleId" });
            DropColumn("dbo.AspNetUsers", "CreateDate");
            DropColumn("dbo.AspNetUsers", "PrefText");
            DropColumn("dbo.AspNetUsers", "PrefEmail");
            DropColumn("dbo.AspNetUsers", "DisplayName");
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "FirstName");
            DropColumn("dbo.AspNetUserRoles", "Discriminator");
            DropColumn("dbo.AspNetUserRoles", "CreateDate");
            DropColumn("dbo.AspNetUserRoles", "UserRoleId");
            DropColumn("dbo.AspNetRoles", "Discriminator");
            DropColumn("dbo.AspNetRoles", "CreateDate");
            DropColumn("dbo.AspNetRoles", "Description");
            DropColumn("dbo.AspNetRoles", "RoleId");
        }
    }
}
