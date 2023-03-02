using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace projetos.Migrations
{
    /// <inheritdoc />
    public partial class initialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "weapons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    basedamage = table.Column<int>(name: "base_damage", type: "integer", nullable: false),
                    bonusdamagetype = table.Column<string>(name: "bonus_damage_type", type: "text", nullable: false),
                    bonusdamage = table.Column<int>(name: "bonus_damage", type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    specialbonusgiven = table.Column<string>(name: "special_bonus_given", type: "text", nullable: false),
                    slottouse = table.Column<string>(name: "slot_to_use", type: "text", nullable: false),
                    createdat = table.Column<DateTime>(name: "created_at", type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_weapons", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "weapons");
        }
    }
}
