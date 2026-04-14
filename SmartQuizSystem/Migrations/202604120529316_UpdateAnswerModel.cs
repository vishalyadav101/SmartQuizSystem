namespace SmartQuizSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateAnswerModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Answers", "UserEmail", c => c.String());
            DropColumn("dbo.Answers", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Answers", "UserId", c => c.Int(nullable: false));
            DropColumn("dbo.Answers", "UserEmail");
        }
    }
}
