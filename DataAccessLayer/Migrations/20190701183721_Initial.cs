using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DataAccessLayer.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pads",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ActivePageIndex = table.Column<int>(nullable: false),
                    ActiveTaskIndex = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pads", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Entry",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Caption = table.Column<string>(nullable: true),
                    Addition = table.Column<string>(nullable: true),
                    Link = table.Column<string>(nullable: true),
                    Tags = table.Column<List<string>>(nullable: true),
                    IsDone = table.Column<bool>(nullable: false),
                    PadId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entry", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Entry_Pads_PadId",
                        column: x => x.PadId,
                        principalTable: "Pads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Entry_PadId",
                table: "Entry",
                column: "PadId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Entry");

            migrationBuilder.DropTable(
                name: "Pads");
        }
    }
}
