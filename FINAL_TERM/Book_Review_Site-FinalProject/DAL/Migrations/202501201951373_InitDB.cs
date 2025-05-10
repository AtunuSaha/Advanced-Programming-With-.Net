namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Bio = c.String(),
                        Website = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        AuthorId = c.Int(nullable: false),
                        Genre = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Authors", t => t.AuthorId, cascadeDelete: true)
                .Index(t => t.AuthorId);
            
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        Rating = c.Double(nullable: false),
                        BookId = c.Int(nullable: false),
                        ReviewerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Books", t => t.BookId, cascadeDelete: true)
                .ForeignKey("dbo.Reviewers", t => t.ReviewerId, cascadeDelete: true)
                .Index(t => t.BookId)
                .Index(t => t.ReviewerId);
            
            CreateTable(
                "dbo.Reviewers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Bio = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reviews", "ReviewerId", "dbo.Reviewers");
            DropForeignKey("dbo.Reviews", "BookId", "dbo.Books");
            DropForeignKey("dbo.Books", "AuthorId", "dbo.Authors");
            DropIndex("dbo.Reviews", new[] { "ReviewerId" });
            DropIndex("dbo.Reviews", new[] { "BookId" });
            DropIndex("dbo.Books", new[] { "AuthorId" });
            DropTable("dbo.Reviewers");
            DropTable("dbo.Reviews");
            DropTable("dbo.Books");
            DropTable("dbo.Authors");
        }
    }
}
