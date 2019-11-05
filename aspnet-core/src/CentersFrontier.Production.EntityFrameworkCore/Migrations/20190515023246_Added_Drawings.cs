using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CentersFrontier.Production.Migrations
{
    public partial class Added_Drawings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Drawings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(maxLength: 32, nullable: false),
                    Name = table.Column<string>(maxLength: 32, nullable: false),
                    Description = table.Column<string>(maxLength: 256, nullable: true),
                    Stage = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    Sort = table.Column<int>(nullable: true),
                    StandardPart_Sort = table.Column<int>(nullable: true),
                    UniversalPart_Sort = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drawings", x => x.Id);
                    table.UniqueConstraint("AK_Drawings_Code", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "AssemblyDetail",
                columns: table => new
                {
                    Ordinal = table.Column<int>(nullable: false),
                    AssemblyCode = table.Column<string>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    Material = table.Column<string>(nullable: true),
                    UnitWeight = table.Column<float>(nullable: true),
                    TotalWeight = table.Column<float>(nullable: true, computedColumnSql: "[UnitWeight] * [Quantity]"),
                    Borrowed = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssemblyDetail", x => new { x.AssemblyCode, x.Ordinal });
                    table.ForeignKey(
                        name: "FK_AssemblyDetail_Drawings_AssemblyCode",
                        column: x => x.AssemblyCode,
                        principalTable: "Drawings",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssemblyDetail_Drawings_Code",
                        column: x => x.Code,
                        principalTable: "Drawings",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Drawings",
                columns: new[] { "Id", "Code", "Description", "Discriminator", "Name", "Stage" },
                values: new object[,]
                {
                    { 5, "ZJ-001", null, "Assembly", "组件1", 0 },
                    { 6, "ZJ-002", null, "Assembly", "组件2", 0 }
                });

            migrationBuilder.InsertData(
                table: "Drawings",
                columns: new[] { "Id", "Code", "Description", "Discriminator", "Name", "Stage", "Sort" },
                values: new object[,]
                {
                    { 1, "ZYJ-001", null, "SpecialPart", "专用件1", 0, 0 },
                    { 2, "ZYJ-002", null, "SpecialPart", "专用件2", 0, 0 }
                });

            migrationBuilder.InsertData(
                table: "Drawings",
                columns: new[] { "Id", "Code", "Description", "Discriminator", "Name", "Stage", "StandardPart_Sort" },
                values: new object[] { 3, "BZJ-001", null, "StandardPart", "标准件1", 0, 0 });

            migrationBuilder.InsertData(
                table: "Drawings",
                columns: new[] { "Id", "Code", "Description", "Discriminator", "Name", "Stage", "UniversalPart_Sort" },
                values: new object[] { 4, "TYJ-001", null, "UniversalPart", "通用件1", 0, 0 });

            migrationBuilder.InsertData(
                table: "AssemblyDetail",
                columns: new[] { "AssemblyCode", "Ordinal", "Code", "Material", "Name", "Quantity", "UnitWeight" },
                values: new object[] { "ZJ-001", 1, null, null, null, 1, null });

            migrationBuilder.InsertData(
                table: "AssemblyDetail",
                columns: new[] { "AssemblyCode", "Ordinal", "Code", "Material", "Name", "Quantity", "UnitWeight" },
                values: new object[] { "ZJ-001", 2, null, null, null, 4, 0.027f });

            migrationBuilder.InsertData(
                table: "AssemblyDetail",
                columns: new[] { "AssemblyCode", "Ordinal", "Code", "Material", "Name", "Quantity", "UnitWeight" },
                values: new object[] { "ZJ-002", 1, null, null, null, 2, null });

            migrationBuilder.InsertData(
                table: "AssemblyDetail",
                columns: new[] { "AssemblyCode", "Ordinal", "Borrowed", "Code", "Material", "Name", "Quantity", "UnitWeight" },
                values: new object[] { "ZJ-002", 2, true, null, null, null, 1, null });

            migrationBuilder.InsertData(
                table: "AssemblyDetail",
                columns: new[] { "AssemblyCode", "Ordinal", "Code", "Material", "Name", "Quantity", "UnitWeight" },
                values: new object[] { "ZJ-002", 3, null, null, null, 1, null });

            migrationBuilder.CreateIndex(
                name: "IX_AssemblyDetail_Code",
                table: "AssemblyDetail",
                column: "Code");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssemblyDetail");

            migrationBuilder.DropTable(
                name: "Drawings");
        }
    }
}
