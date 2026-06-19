using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Kiemtragiuaki.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RoomTypes_BIT240120",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomTypes_BIT240120", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rooms_BIT240120",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Area = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    RoomTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms_BIT240120", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rooms_BIT240120_RoomTypes_BIT240120_RoomTypeId",
                        column: x => x.RoomTypeId,
                        principalTable: "RoomTypes_BIT240120",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoomImages_BIT240120",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    IsThumbnail = table.Column<bool>(type: "bit", nullable: false),
                    RoomId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomImages_BIT240120", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoomImages_BIT240120_Rooms_BIT240120_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms_BIT240120",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "RoomTypes_BIT240120",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "A room designed for one person with basic amenities", "Single Room" },
                    { 2, "A room designed for two people with enhanced comfort", "Double Room" },
                    { 3, "A spacious room designed for families with multiple beds", "Family Room" }
                });

            migrationBuilder.InsertData(
                table: "Rooms_BIT240120",
                columns: new[] { "Id", "Area", "Description", "IsAvailable", "Name", "Price", "RoomTypeId" },
                values: new object[,]
                {
                    { 1, 25m, "Comfortable single room", true, "Room 101", 250000m, 1 },
                    { 2, 30m, "Single room with balcony", true, "Room 102", 300000m, 1 },
                    { 3, 40m, "Spacious double room", false, "Room 201", 450000m, 2 },
                    { 4, 45m, "Double room with city view", true, "Room 202", 500000m, 2 },
                    { 5, 60m, "Large family room", true, "Room 301", 750000m, 3 },
                    { 6, 70m, "Luxurious family room", true, "Room 302", 800000m, 3 }
                });

            migrationBuilder.InsertData(
                table: "RoomImages_BIT240120",
                columns: new[] { "Id", "ImageUrl", "IsThumbnail", "RoomId" },
                values: new object[,]
                {
                    { 1, "https://via.placeholder.com/300x200?text=Room+101", true, 1 },
                    { 2, "https://via.placeholder.com/300x200?text=Room+101+View", false, 1 },
                    { 3, "https://via.placeholder.com/300x200?text=Room+102", true, 2 },
                    { 4, "https://via.placeholder.com/300x200?text=Room+201", true, 3 },
                    { 5, "https://via.placeholder.com/300x200?text=Room+202", true, 4 },
                    { 6, "https://via.placeholder.com/300x200?text=Room+301", true, 5 },
                    { 7, "https://via.placeholder.com/300x200?text=Room+302", true, 6 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoomImages_BIT240120_RoomId",
                table: "RoomImages_BIT240120",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Room_Name_RoomTypeId_Unique",
                table: "Rooms_BIT240120",
                columns: new[] { "Name", "RoomTypeId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_BIT240120_RoomTypeId",
                table: "Rooms_BIT240120",
                column: "RoomTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoomImages_BIT240120");

            migrationBuilder.DropTable(
                name: "Rooms_BIT240120");

            migrationBuilder.DropTable(
                name: "RoomTypes_BIT240120");
        }
    }
}
