using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace coreCrudeMovies.Migrations
{
    public partial class seed_genres : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] {  "Name" },               
                values: new string[] {  "Action" }
                );

            migrationBuilder.InsertData(
               table: "Genres",
               columns: new[] { "Name" },               
               values: new string[] { "Drama" }
               );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
