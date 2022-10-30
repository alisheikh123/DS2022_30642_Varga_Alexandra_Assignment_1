using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineEnergyUtilityPlateformAPI.Migrations
{
    public partial class changehourstable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "AfterMappingStoredHourEnergy",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "AfterMappingStoredHourEnergy");
        }
    }
}
