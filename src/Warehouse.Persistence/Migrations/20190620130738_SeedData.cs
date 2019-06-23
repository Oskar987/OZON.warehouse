using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Warehouse.Persistence.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "StockItems",
                schema: "dbo",
                columns: new[] { "Created", "Name", "Brand", "Price" },
                values: new object[] { DateTime.UtcNow, "Холодильник Юпитер-2", "Космос", 5000 });
            migrationBuilder.InsertData(
                table: "StockItems",
                schema: "dbo",
                columns: new[] { "Created", "Name", "Brand", "Price" },
                values: new object[] { DateTime.UtcNow, "Телевизор Заря - 2", "Заря", 5000 });
            migrationBuilder.InsertData(
                table: "StockItems",
                schema: "dbo",
                columns: new[] { "Created", "Name", "Brand", "Price" },
                values: new object[] { DateTime.UtcNow, "Мясорубка Смерч-1", "Вихрь", 5000 });
            migrationBuilder.InsertData(
                table: "StockItems",
                schema: "dbo",
                columns: new[] { "Created", "Name", "Brand", "Price" },
                values: new object[] { DateTime.UtcNow, "Пылесос Мусcолини-1", "Диктатор", 5000 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM dbo.StockItems");
        }
    }
}
