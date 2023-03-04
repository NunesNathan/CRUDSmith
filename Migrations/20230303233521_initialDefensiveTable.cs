using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace projetos.Migrations
{
    /// <inheritdoc />
    public partial class initialDefensiveTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "weapons",
                type: "timestamp with time zone",
                nullable: true,
                defaultValueSql: "NOW()",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "NOW()");

            migrationBuilder.CreateTable(
                name: "defensives",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    bonusdamage = table.Column<int>(name: "bonus_damage", type: "integer", nullable: false),
                    basedamage = table.Column<int>(name: "base_damage", type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    specialbonusgiven = table.Column<string>(name: "special_bonus_given", type: "text", nullable: false),
                    slottouse = table.Column<string>(name: "slot_to_use", type: "text", nullable: false),
                    createdat = table.Column<DateTime>(name: "created_at", type: "timestamp with time zone", nullable: true, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_defensives", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "defensives");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "weapons",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "NOW()",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValueSql: "NOW()");
        }
    }
}
