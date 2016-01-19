namespace WebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Offereds",
                c => new
                    {
                        feedbackId = c.Int(nullable: false, identity: true),
                        senderId = c.Int(),
                        recipientId = c.Int(),
                        date = c.DateTime(nullable: false),
                        comments = c.String(),
                        accepted = c.Boolean(nullable: false),
                        isComplete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.feedbackId)
                .ForeignKey("dbo.Users", t => t.recipientId)
                .ForeignKey("dbo.Users", t => t.senderId)
                .Index(t => t.senderId)
                .Index(t => t.recipientId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        userId = c.Int(nullable: false, identity: true),
                        firstName = c.String(),
                        lastName = c.String(),
                        username = c.String(),
                        password = c.String(),
                        email = c.String(),
                    })
                .PrimaryKey(t => t.userId);
            
            CreateTable(
                "dbo.Requesteds",
                c => new
                    {
                        feedbackId = c.Int(nullable: false, identity: true),
                        senderId = c.Int(),
                        recipientId = c.Int(),
                        date = c.DateTime(nullable: false),
                        comments = c.String(),
                        accepted = c.Boolean(nullable: false),
                        isComplete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.feedbackId)
                .ForeignKey("dbo.Users", t => t.recipientId)
                .ForeignKey("dbo.Users", t => t.senderId)
                .Index(t => t.senderId)
                .Index(t => t.recipientId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Requesteds", "senderId", "dbo.Users");
            DropForeignKey("dbo.Requesteds", "recipientId", "dbo.Users");
            DropForeignKey("dbo.Offereds", "senderId", "dbo.Users");
            DropForeignKey("dbo.Offereds", "recipientId", "dbo.Users");
            DropIndex("dbo.Requesteds", new[] { "recipientId" });
            DropIndex("dbo.Requesteds", new[] { "senderId" });
            DropIndex("dbo.Offereds", new[] { "recipientId" });
            DropIndex("dbo.Offereds", new[] { "senderId" });
            DropTable("dbo.Requesteds");
            DropTable("dbo.Users");
            DropTable("dbo.Offereds");
        }
    }
}
