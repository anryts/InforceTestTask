using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhotoGallery.Server.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_images_albums_album_id",
                table: "images");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "images",
                newName: "title");

            migrationBuilder.RenameColumn(
                name: "file_path",
                table: "images",
                newName: "image_path");

            migrationBuilder.AlterColumn<Guid>(
                name: "album_id",
                table: "images",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "creator_id",
                table: "images",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "creator_id",
                table: "albums",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddForeignKey(
                name: "fk_images_albums_album_id",
                table: "images",
                column: "album_id",
                principalTable: "albums",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_images_albums_album_id",
                table: "images");

            migrationBuilder.DropColumn(
                name: "creator_id",
                table: "images");

            migrationBuilder.DropColumn(
                name: "creator_id",
                table: "albums");

            migrationBuilder.RenameColumn(
                name: "title",
                table: "images",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "image_path",
                table: "images",
                newName: "file_path");

            migrationBuilder.AlterColumn<Guid>(
                name: "album_id",
                table: "images",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "fk_images_albums_album_id",
                table: "images",
                column: "album_id",
                principalTable: "albums",
                principalColumn: "id");
        }
    }
}
