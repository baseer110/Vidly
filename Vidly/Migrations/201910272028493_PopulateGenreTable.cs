namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenreTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (Id, Name) VALUES (1, 'Action')");
            //Sql("INSERT INTO Genres (Id, Name) VALUES (2, Drama)");
            //Sql("INSERT INTO Genre (Id, Name) VALUES (3, 'Thriller')");
            //Sql("INSERT INTO Genre (Id, Name) VALUES (4, 'Suspense')");
            //Sql("INSERT INTO Genre (Id, Name) VALUES (5, 'Comedy')");
            //Sql("INSERT INTO Genre (Id, Name) VALUES (6, 'Romance')");
            //Sql("INSERT INTO Genre (Id, Name) VALUES (7, 'Horror')");
            //Sql("INSERT INTO Genre (Id, Name) VALUES (8, 'Science Fiction')");
        }

        public override void Down()
        {
        }
    }
}
