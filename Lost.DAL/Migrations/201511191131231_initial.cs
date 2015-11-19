namespace Lost.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LostPersonEntity",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Birthday = c.DateTime(nullable: false),
                        City = c.String(),
                        Country = c.String(),
                        DateLastSeen = c.DateTime(nullable: false),
                        LocationLastSeen = c.String(),
                        ReporterName = c.String(),
                        ReportDate = c.DateTime(nullable: false),
                        Location = c.String(),
                        IsFound = c.Boolean(nullable: false),
                        RedCrossId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RedCrossEntity", t => t.RedCrossId, cascadeDelete: true)
                .Index(t => t.RedCrossId);
            
            CreateTable(
                "dbo.RedCrossEntity",
                c => new
                    {
                        RedCrossId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        City = c.String(),
                        Country = c.String(),
                        PersonInCharge = c.String(),
                    })
                .PrimaryKey(t => t.RedCrossId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LostPersonEntity", "RedCrossId", "dbo.RedCrossEntity");
            DropIndex("dbo.LostPersonEntity", new[] { "RedCrossId" });
            DropTable("dbo.RedCrossEntity");
            DropTable("dbo.LostPersonEntity");
        }
    }
}
