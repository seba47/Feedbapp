namespace WebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Offereds",
                c => new
                    {
                        feedbackId = c.Int(nullable: false, identity: true),
                        date = c.DateTime(nullable: false),
                        comments = c.String(),
                        accepted = c.Boolean(nullable: false),
                        isComplete = c.Boolean(nullable: false),
                        recipient_userId = c.Int(),
                        sender_userId = c.Int(),
                    })
                .PrimaryKey(t => t.feedbackId)
                .ForeignKey("dbo.Users", t => t.recipient_userId)
                .ForeignKey("dbo.Users", t => t.sender_userId)
                .Index(t => t.recipient_userId)
                .Index(t => t.sender_userId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        userId = c.Int(nullable: false, identity: true),
                        firstName = c.String(),
                        lastName = c.String(),
                        username = c.String(),
                        password = c.String(),
                    })
                .PrimaryKey(t => t.userId);
            
            CreateTable(
                "dbo.Requesteds",
                c => new
                    {
                        feedbackId = c.Int(nullable: false, identity: true),
                        date = c.DateTime(nullable: false),
                        comments = c.String(),
                        accepted = c.Boolean(nullable: false),
                        isComplete = c.Boolean(nullable: false),
                        recipient_userId = c.Int(),
                        sender_userId = c.Int(),
                    })
                .PrimaryKey(t => t.feedbackId)
                .ForeignKey("dbo.Users", t => t.recipient_userId)
                .ForeignKey("dbo.Users", t => t.sender_userId)
                .Index(t => t.recipient_userId)
                .Index(t => t.sender_userId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Requesteds", "sender_userId", "dbo.Users");
            DropForeignKey("dbo.Requesteds", "recipient_userId", "dbo.Users");
            DropForeignKey("dbo.Offereds", "sender_userId", "dbo.Users");
            DropForeignKey("dbo.Offereds", "recipient_userId", "dbo.Users");
            DropIndex("dbo.Requesteds", new[] { "sender_userId" });
            DropIndex("dbo.Requesteds", new[] { "recipient_userId" });
            DropIndex("dbo.Offereds", new[] { "sender_userId" });
            DropIndex("dbo.Offereds", new[] { "recipient_userId" });
            DropTable("dbo.Requesteds");
            DropTable("dbo.Users");
            DropTable("dbo.Offereds");
        }
    }
}
