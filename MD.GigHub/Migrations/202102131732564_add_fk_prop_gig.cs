namespace MD.GigHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_fk_prop_gig : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Gigs", "Genre_Id", "dbo.Genres");
            DropIndex("dbo.Gigs", new[] { "Genre_Id" });
            RenameColumn(table: "dbo.Gigs", name: "Artist_Id", newName: "ArtistId");
            RenameColumn(table: "dbo.Gigs", name: "Genre_Id", newName: "GenreId");
            RenameIndex(table: "dbo.Gigs", name: "IX_Artist_Id", newName: "IX_ArtistId");
            AlterColumn("dbo.Gigs", "GenreId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Gigs", "GenreId");
            AddForeignKey("dbo.Gigs", "GenreId", "dbo.Genres", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Gigs", "GenreId", "dbo.Genres");
            DropIndex("dbo.Gigs", new[] { "GenreId" });
            AlterColumn("dbo.Gigs", "GenreId", c => c.Byte());
            RenameIndex(table: "dbo.Gigs", name: "IX_ArtistId", newName: "IX_Artist_Id");
            RenameColumn(table: "dbo.Gigs", name: "GenreId", newName: "Genre_Id");
            RenameColumn(table: "dbo.Gigs", name: "ArtistId", newName: "Artist_Id");
            CreateIndex("dbo.Gigs", "Genre_Id");
            AddForeignKey("dbo.Gigs", "Genre_Id", "dbo.Genres", "Id");
        }
    }
}
