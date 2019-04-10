using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace binance.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TradeDatas",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    e = table.Column<string>(nullable: true),
                    E = table.Column<DateTime>(nullable: false),
                    s = table.Column<string>(nullable: true),
                    a = table.Column<long>(nullable: false),
                    p = table.Column<decimal>(nullable: false),
                    q = table.Column<decimal>(nullable: false),
                    f = table.Column<long>(nullable: false),
                    l = table.Column<long>(nullable: false),
                    T = table.Column<DateTime>(nullable: false),
                    m = table.Column<bool>(nullable: false),
                    M = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TradeDatas", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TradeDatas");
        }
    }
}
