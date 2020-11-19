using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Suhail.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Parcel",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BlockNumber = table.Column<string>(nullable: true),
                    Neighbourhood = table.Column<string>(nullable: true),
                    SubdivisionNumber = table.Column<string>(nullable: true),
                    LandUseGroup = table.Column<int>(nullable: false),
                    PriceOfMeter = table.Column<decimal>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parcel", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Broker",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    PhoneNumer = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Bio = table.Column<string>(nullable: true),
                    ParcelID = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Broker", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Broker_Parcel_ParcelID",
                        column: x => x.ParcelID,
                        principalTable: "Parcel",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Broker_ParcelID",
                table: "Broker",
                column: "ParcelID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Broker");

            migrationBuilder.DropTable(
                name: "Parcel");
        }
    }
}
