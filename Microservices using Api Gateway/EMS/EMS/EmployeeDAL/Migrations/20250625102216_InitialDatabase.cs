using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EmployeeDAL.Migrations
{
    /// <inheritdoc />
    public partial class InitialDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmpProfile",
                columns: table => new
                {
                    EmpCode = table.Column<int>(type: "int", nullable: false),
                    EmpName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeptCode = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpProfile", x => x.EmpCode);
                });

            migrationBuilder.InsertData(
                table: "EmpProfile",
                columns: new[] { "EmpCode", "DeptCode", "Email", "EmpName" },
                values: new object[,]
                {
                    { 100, 1, "scott@gmail.com", "Scott" },
                    { 101, 2, "tiger@gmail.com", "Tiger" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmpProfile");
        }
    }
}
