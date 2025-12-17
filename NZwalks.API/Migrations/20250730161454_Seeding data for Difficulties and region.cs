using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZwalks.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedingdataforDifficultiesandregion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { new Guid("14491e4d-9abb-44af-8b56-701c0b06b09d"), "Hard" },
                    { new Guid("335d8255-9953-4845-8581-788ac4e153d8"), "Easy" },
                    { new Guid("f7ef4ca5-e069-49cc-9b39-1a90d1438418"), "Medium" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageurl" },
                values: new object[,]
                {
                    { new Guid("311d028f-6801-40a1-85d9-32834d8f3e04"), "WGN", "Wellington", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSIIodJ7L7jxCAiZHGLKTbNKYLND-vgPS3vbA&s" },
                    { new Guid("a1cdec49-afa7-47b7-9584-f82252f37da6"), "NSN", "Nelson", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQZ9kBp01al31iWgPGCja8IOlWL1bG3RS2wLw&s" },
                    { new Guid("f7109940-19f0-48d4-97fd-898942b0ade7"), "BOP", "Bay of Plenty", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT6lhHopLJArrwJ4nyxk1AtR7m72M71_dFbVw&s" },
                    { new Guid("fbd1b7d6-3308-42bb-a98e-2f1500c59673"), "STL", "Southland", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTZjn1lpvZhzBjiTLktxnJ5xUM6qqIPabUtkQ&s" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "ID",
                keyValue: new Guid("14491e4d-9abb-44af-8b56-701c0b06b09d"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "ID",
                keyValue: new Guid("335d8255-9953-4845-8581-788ac4e153d8"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "ID",
                keyValue: new Guid("f7ef4ca5-e069-49cc-9b39-1a90d1438418"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("311d028f-6801-40a1-85d9-32834d8f3e04"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("a1cdec49-afa7-47b7-9584-f82252f37da6"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("f7109940-19f0-48d4-97fd-898942b0ade7"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("fbd1b7d6-3308-42bb-a98e-2f1500c59673"));
        }
    }
}
