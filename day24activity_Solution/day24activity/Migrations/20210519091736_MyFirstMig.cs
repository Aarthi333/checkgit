using Microsoft.EntityFrameworkCore.Migrations;

namespace day24activity.Migrations
{
    public partial class MyFirstMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "sBAccounts",
                columns: table => new
                {
                    AccountID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountNumber = table.Column<int>(type: "int", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerBalance = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sBAccounts", x => x.AccountID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "sBAccounts");
        }
    }
}
