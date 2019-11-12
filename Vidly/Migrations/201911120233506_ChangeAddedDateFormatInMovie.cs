namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeAddedDateFormatInMovie : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movies", "AddedDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Movies", "ReleaseDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "ReleaseDate", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Movies", "AddedDate", c => c.DateTime(nullable: false));
        }
    }
}
