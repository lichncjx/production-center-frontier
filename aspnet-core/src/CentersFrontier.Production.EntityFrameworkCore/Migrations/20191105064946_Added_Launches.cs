using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CentersFrontier.Production.Migrations
{
    public partial class Added_Launches : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Classifications",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    IsUniversal = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classifications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Launches",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(maxLength: 32, nullable: false),
                    Name = table.Column<string>(maxLength: 32, nullable: false),
                    Description = table.Column<string>(maxLength: 256, nullable: true),
                    ModelCode = table.Column<string>(nullable: false),
                    Stage = table.Column<string>(nullable: false),
                    SpecialClassificationId = table.Column<string>(nullable: true),
                    UniversalClassificationId = table.Column<string>(nullable: true),
                    PlannedCompletionDate = table.Column<DateTime>(nullable: false),
                    PlannedFinishDate = table.Column<DateTime>(nullable: false),
                    PlannedDeliveryDate = table.Column<DateTime>(nullable: false),
                    CompletionPriority = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Launches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Launches_Models_ModelCode",
                        column: x => x.ModelCode,
                        principalTable: "Models",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Launches_Classifications_SpecialClassificationId",
                        column: x => x.SpecialClassificationId,
                        principalTable: "Classifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Launches_Classifications_UniversalClassificationId",
                        column: x => x.UniversalClassificationId,
                        principalTable: "Classifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductionTask",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TaskCode = table.Column<string>(nullable: true),
                    DrawingCode = table.Column<string>(nullable: true),
                    DrawingName = table.Column<string>(nullable: true),
                    MainWorkshop = table.Column<int>(nullable: false),
                    ClassificationId = table.Column<string>(nullable: true),
                    TaskClassificationId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionTask", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductionTask_Classifications_TaskClassificationId",
                        column: x => x.TaskClassificationId,
                        principalTable: "Classifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "AssemblyDetail",
                keyColumns: new[] { "AssemblyCode", "Ordinal" },
                keyValues: new object[] { "ZJ-001", 1 },
                columns: new[] { "Code", "Name" },
                values: new object[] { "ZYJ-001", "专用件1" });

            migrationBuilder.UpdateData(
                table: "AssemblyDetail",
                keyColumns: new[] { "AssemblyCode", "Ordinal" },
                keyValues: new object[] { "ZJ-001", 2 },
                columns: new[] { "Code", "Name" },
                values: new object[] { "BZJ-001", "标准件1" });

            migrationBuilder.UpdateData(
                table: "AssemblyDetail",
                keyColumns: new[] { "AssemblyCode", "Ordinal" },
                keyValues: new object[] { "ZJ-002", 1 },
                columns: new[] { "Code", "Name" },
                values: new object[] { "ZJ-001", "组件1" });

            migrationBuilder.UpdateData(
                table: "AssemblyDetail",
                keyColumns: new[] { "AssemblyCode", "Ordinal" },
                keyValues: new object[] { "ZJ-002", 2 },
                columns: new[] { "Code", "Name" },
                values: new object[] { "ZYJ-002", "专用件2" });

            migrationBuilder.UpdateData(
                table: "AssemblyDetail",
                keyColumns: new[] { "AssemblyCode", "Ordinal" },
                keyValues: new object[] { "ZJ-002", 3 },
                columns: new[] { "Code", "Name" },
                values: new object[] { "TYJ-001", "通用件1" });

            migrationBuilder.InsertData(
                table: "Classifications",
                columns: new[] { "Id", "IsUniversal" },
                values: new object[,]
                {
                    { "XxAS04", false },
                    { "YyAC04", false },
                    { "XyAT14", true }
                });

            migrationBuilder.InsertData(
                table: "Launches",
                columns: new[] { "Id", "Code", "CompletionPriority", "Description", "ModelCode", "Name", "PlannedCompletionDate", "PlannedDeliveryDate", "PlannedFinishDate", "SpecialClassificationId", "Stage", "UniversalClassificationId" },
                values: new object[,]
                {
                    { 5, "CZ-7 Y1", 0, null, "CZ-7", "长七遥一", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "S", null },
                    { 6, "CZ-7 Y2", 0, null, "CZ-7", "长七遥二", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "S", null },
                    { 7, "CZ-7A SY", 0, null, "CZ-7A", "长七甲试验", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "C", null },
                    { 8, "CZ-6 Y1", 0, null, "CZ-6", "长六遥一", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "S", null },
                    { 9, "CZ-6 Y2", 0, null, "CZ-6", "长六遥二", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "S", null }
                });

            migrationBuilder.InsertData(
                table: "Launches",
                columns: new[] { "Id", "Code", "CompletionPriority", "Description", "ModelCode", "Name", "PlannedCompletionDate", "PlannedDeliveryDate", "PlannedFinishDate", "SpecialClassificationId", "Stage", "UniversalClassificationId" },
                values: new object[,]
                {
                    { 1, "CZ-5 Y1", 0, null, "CZ-5", "长五遥一", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "XxAS04", "S", "XyAT14" },
                    { 2, "CZ-5 Y2", 0, null, "CZ-5", "长五遥二", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "XxAS04", "S", "XyAT14" },
                    { 3, "CZ-5 Y3", 0, null, "CZ-5", "长五遥三", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "XxAS04", "S", "XyAT14" },
                    { 4, "CZ-5B Y1", 0, null, "CZ-5B", "长五乙遥一", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "YyAC04", "C", "XyAT14" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Launches_ModelCode",
                table: "Launches",
                column: "ModelCode");

            migrationBuilder.CreateIndex(
                name: "IX_Launches_SpecialClassificationId",
                table: "Launches",
                column: "SpecialClassificationId");

            migrationBuilder.CreateIndex(
                name: "IX_Launches_UniversalClassificationId",
                table: "Launches",
                column: "UniversalClassificationId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductionTask_TaskClassificationId",
                table: "ProductionTask",
                column: "TaskClassificationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Launches");

            migrationBuilder.DropTable(
                name: "ProductionTask");

            migrationBuilder.DropTable(
                name: "Classifications");

            migrationBuilder.UpdateData(
                table: "AssemblyDetail",
                keyColumns: new[] { "AssemblyCode", "Ordinal" },
                keyValues: new object[] { "ZJ-001", 1 },
                columns: new[] { "Code", "Name" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "AssemblyDetail",
                keyColumns: new[] { "AssemblyCode", "Ordinal" },
                keyValues: new object[] { "ZJ-001", 2 },
                columns: new[] { "Code", "Name" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "AssemblyDetail",
                keyColumns: new[] { "AssemblyCode", "Ordinal" },
                keyValues: new object[] { "ZJ-002", 1 },
                columns: new[] { "Code", "Name" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "AssemblyDetail",
                keyColumns: new[] { "AssemblyCode", "Ordinal" },
                keyValues: new object[] { "ZJ-002", 2 },
                columns: new[] { "Code", "Name" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "AssemblyDetail",
                keyColumns: new[] { "AssemblyCode", "Ordinal" },
                keyValues: new object[] { "ZJ-002", 3 },
                columns: new[] { "Code", "Name" },
                values: new object[] { null, null });
        }
    }
}
