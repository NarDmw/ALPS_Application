namespace ALPS_Application.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Varchar : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employees", "FirstName", c => c.String(nullable: false, maxLength: 8000, unicode: false));
            AlterColumn("dbo.Employees", "LastName", c => c.String(nullable: false, maxLength: 8000, unicode: false));
            AlterColumn("dbo.Offices", "City", c => c.String(nullable: false, maxLength: 8000, unicode: false));
            AlterColumn("dbo.USStates", "Name", c => c.String(nullable: false, maxLength: 8000, unicode: false));
            AlterColumn("dbo.USStates", "Abbreviation", c => c.String(nullable: false, maxLength: 2, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.USStates", "Abbreviation", c => c.String(nullable: false, maxLength: 2));
            AlterColumn("dbo.USStates", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Offices", "City", c => c.String(nullable: false));
            AlterColumn("dbo.Employees", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.Employees", "FirstName", c => c.String(nullable: false));
        }
    }
}
