using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NavTech.Configuration.DataAccess.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EntityConfigurations",
                columns: table => new
                {
                    EntityConfigurationID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntityName = table.Column<string>(nullable: true),
                    FieldName = table.Column<string>(nullable: true),
                    IsRequired = table.Column<bool>(nullable: false),
                    MaxLength = table.Column<int>(nullable: false),
                    FieldSource = table.Column<string>(nullable: true),
                    CreatedTime = table.Column<DateTime>(nullable: false),
                    ModifiedTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityConfigurations", x => x.EntityConfigurationID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EntityConfigurations");
        }
    }
}
