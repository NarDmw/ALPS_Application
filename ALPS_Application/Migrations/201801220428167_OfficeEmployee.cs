namespace ALPS_Application.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OfficeEmployee : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        OfficeId = c.String(),
                        Office_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Offices", t => t.Office_ID, cascadeDelete: true)
                .Index(t => t.Office_ID);
            
            CreateTable(
                "dbo.Offices",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        City = c.String(nullable: false),
                        USStateId = c.String(),
                        State_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.USStates", t => t.State_ID, cascadeDelete: true)
                .Index(t => t.State_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "Office_ID", "dbo.Offices");
            DropForeignKey("dbo.Offices", "State_ID", "dbo.USStates");
            DropIndex("dbo.Offices", new[] { "State_ID" });
            DropIndex("dbo.Employees", new[] { "Office_ID" });
            DropTable("dbo.Offices");
            DropTable("dbo.Employees");
        }
    }
}
