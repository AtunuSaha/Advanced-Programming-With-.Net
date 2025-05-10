namespace IntroEFCF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IntroWithStudentCourseFaculty : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Faculties",
                c => new
                    {
                        FacultyId = c.Int(nullable: false, identity: true),
                        FacultyName = c.String(),
                    })
                .PrimaryKey(t => t.FacultyId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Faculties");
        }
    }
}
