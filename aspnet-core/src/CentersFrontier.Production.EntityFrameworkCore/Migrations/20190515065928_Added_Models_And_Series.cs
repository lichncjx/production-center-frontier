using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CentersFrontier.Production.Migrations
{
    public partial class Added_Models_And_Series : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Series",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(maxLength: 32, nullable: false),
                    Name = table.Column<string>(maxLength: 32, nullable: false),
                    Description = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Series", x => x.Id);
                    table.UniqueConstraint("AK_Series_Code", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Models",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(maxLength: 32, nullable: false),
                    Name = table.Column<string>(maxLength: 32, nullable: false),
                    Description = table.Column<string>(maxLength: 256, nullable: true),
                    SeriesCode = table.Column<string>(nullable: true),
                    DerivedFrom = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Models", x => x.Id);
                    table.UniqueConstraint("AK_Models_Code", x => x.Code);
                    table.ForeignKey(
                        name: "FK_Models_Models_DerivedFrom",
                        column: x => x.DerivedFrom,
                        principalTable: "Models",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Models_Series_SeriesCode",
                        column: x => x.SeriesCode,
                        principalTable: "Series",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.InsertData(
                table: "Models",
                columns: new[] { "Id", "Code", "DerivedFrom", "Description", "Name", "SeriesCode" },
                values: new object[] { 8, "CZ-6", null, "长征六号运载火箭", "长征六号", null });

            migrationBuilder.InsertData(
                table: "Series",
                columns: new[] { "Id", "Code", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "CZ-5/5B", "长征五号系列运载火箭", "长五系列" },
                    { 2, "CZ-7/7A", "长征七号系列运载火箭", "长七系列" },
                    { 3, "CZ-3A/3B/3C", "长征三号甲系列运载火箭", "长三甲系列" }
                });

            migrationBuilder.InsertData(
                table: "Models",
                columns: new[] { "Id", "Code", "DerivedFrom", "Description", "Name", "SeriesCode" },
                values: new object[] { 1, "CZ-5", null, "长征五号运载火箭", "长征五号", "CZ-5/5B" });

            migrationBuilder.InsertData(
                table: "Models",
                columns: new[] { "Id", "Code", "DerivedFrom", "Description", "Name", "SeriesCode" },
                values: new object[] { 3, "CZ-7", null, "长征五号运载火箭", "长征七号", "CZ-7/7A" });

            migrationBuilder.InsertData(
                table: "Models",
                columns: new[] { "Id", "Code", "DerivedFrom", "Description", "Name", "SeriesCode" },
                values: new object[] { 5, "CZ-3A", null, "长征三号甲运载火箭", "长征三号甲", "CZ-3A/3B/3C" });

            migrationBuilder.InsertData(
                table: "Models",
                columns: new[] { "Id", "Code", "DerivedFrom", "Description", "Name", "SeriesCode" },
                values: new object[,]
                {
                    { 2, "CZ-5B", "CZ-5", "长征五号乙运载火箭", "长征五号乙", "CZ-5/5B" },
                    { 4, "CZ-7A", "CZ-7", "长征七号甲运载火箭", "长征七号甲", "CZ-7/7A" },
                    { 6, "CZ-3B", "CZ-3A", "长征三号乙运载火箭", "长征三号乙", "CZ-3A/3B/3C" },
                    { 7, "CZ-3C", "CZ-3A", "长征三号丙运载火箭", "长征三号丙", "CZ-3A/3B/3C" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Models_DerivedFrom",
                table: "Models",
                column: "DerivedFrom");

            migrationBuilder.CreateIndex(
                name: "IX_Models_SeriesCode",
                table: "Models",
                column: "SeriesCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Models");

            migrationBuilder.DropTable(
                name: "Series");
        }
    }
}
