﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace StephenKingFanSite.Migrations
{
    public partial class CorrectedScorestable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Score",
                table: "Scores",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Score",
                table: "Scores");
        }
    }
}
