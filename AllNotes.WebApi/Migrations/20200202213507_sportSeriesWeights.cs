using Microsoft.EntityFrameworkCore.Migrations;

namespace AllNotes.WebApi.Migrations
{
    public partial class sportSeriesWeights : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "Weights",
                table: "Series",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Weights",
                table: "Series",
                type: "int",
                nullable: false,
                oldClrType: typeof(float));
        }
    }
}
