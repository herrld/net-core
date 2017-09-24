using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CorseFromGround.Migrations
{
    public partial class colrename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Logitude",
                table: "Stops",
                newName: "Longitude");

            migrationBuilder.RenameColumn(
                name: "ArivalTime",
                table: "Stops",
                newName: "Arrival");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Longitude",
                table: "Stops",
                newName: "Logitude");

            migrationBuilder.RenameColumn(
                name: "Arrival",
                table: "Stops",
                newName: "ArivalTime");
        }
    }
}
