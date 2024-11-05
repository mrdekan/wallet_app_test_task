using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Wallet.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    Title = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Date = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    IsPending = table.Column<bool>(type: "boolean", nullable: false),
                    AuthorizedUser = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Icon = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "Id", "Amount", "AuthorizedUser", "Date", "Description", "Icon", "IsPending", "Title", "Type" },
                values: new object[,]
                {
                    { 1, 50.75m, null, new DateTimeOffset(new DateTime(2024, 11, 4, 21, 5, 42, 459, DateTimeKind.Unspecified).AddTicks(9604), new TimeSpan(0, 2, 0, 0, 0)), "Home furniture purchase", "icon1", false, "IKEA", 0 },
                    { 2, 20.00m, "Alice", new DateTimeOffset(new DateTime(2024, 11, 3, 21, 5, 42, 459, DateTimeKind.Unspecified).AddTicks(9664), new TimeSpan(0, 2, 0, 0, 0)), "Grocery shopping", "icon2", true, "Target", 1 },
                    { 3, 120.00m, "Bob", new DateTimeOffset(new DateTime(2024, 11, 2, 21, 5, 42, 459, DateTimeKind.Unspecified).AddTicks(9668), new TimeSpan(0, 2, 0, 0, 0)), "Monthly subscription", "icon3", false, "Spotify", 0 },
                    { 4, 35.00m, null, new DateTimeOffset(new DateTime(2024, 11, 1, 21, 5, 42, 459, DateTimeKind.Unspecified).AddTicks(9672), new TimeSpan(0, 2, 0, 0, 0)), "Online order", "icon4", false, "Amazon", 1 },
                    { 5, 75.50m, null, new DateTimeOffset(new DateTime(2024, 10, 31, 21, 5, 42, 459, DateTimeKind.Unspecified).AddTicks(9676), new TimeSpan(0, 2, 0, 0, 0)), "Shopping for home essentials", "icon5", false, "Walmart", 0 },
                    { 6, 15.00m, "Charlie", new DateTimeOffset(new DateTime(2024, 10, 30, 21, 5, 42, 459, DateTimeKind.Unspecified).AddTicks(9680), new TimeSpan(0, 2, 0, 0, 0)), "Ride to office", "icon6", false, "Uber", 1 },
                    { 7, 45.25m, null, new DateTimeOffset(new DateTime(2024, 10, 29, 21, 5, 42, 459, DateTimeKind.Unspecified).AddTicks(9684), new TimeSpan(0, 2, 0, 0, 0)), "App purchase", "icon7", false, "Apple", 0 },
                    { 8, 100.00m, "David", new DateTimeOffset(new DateTime(2024, 10, 28, 21, 5, 42, 459, DateTimeKind.Unspecified).AddTicks(9687), new TimeSpan(0, 2, 0, 0, 0)), "Annual subscription", "icon8", false, "Netflix", 1 },
                    { 9, 60.00m, null, new DateTimeOffset(new DateTime(2024, 10, 28, 21, 5, 42, 459, DateTimeKind.Unspecified).AddTicks(9691), new TimeSpan(0, 2, 0, 0, 0)), "Coffee with friends", "icon9", true, "Starbucks", 0 },
                    { 10, 250.00m, "Emma", new DateTimeOffset(new DateTime(2024, 10, 28, 21, 5, 42, 459, DateTimeKind.Unspecified).AddTicks(9694), new TimeSpan(0, 2, 0, 0, 0)), "New headphones", "icon10", false, "Best Buy", 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transactions");
        }
    }
}
