using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ModeloDB.Migrations
{
    public partial class db1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "configuracion",
                columns: table => new
                {
                    NombreEmpresa = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    sueldoMaximo = table.Column<float>(type: "real", nullable: false),
                    Horas_Extras_Minima = table.Column<float>(type: "real", nullable: false),
                    Horas_Extras_Maxima = table.Column<float>(type: "real", nullable: false),
                    Salario_Horas_Extras = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_configuracion", x => x.NombreEmpresa);
                });

            migrationBuilder.CreateTable(
                name: "personales",
                columns: table => new
                {
                    PersonalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cedula = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstadoCV = table.Column<int>(type: "int", nullable: false),
                    salario = table.Column<float>(type: "real", nullable: false),
                    tipo = table.Column<int>(type: "int", nullable: false),
                    fecha_incio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fecha_salida = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_personales", x => x.PersonalId);
                });

            migrationBuilder.CreateTable(
                name: "decimo_Terceros",
                columns: table => new
                {
                    Decimo_TerceroId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonalId = table.Column<int>(type: "int", nullable: true),
                    fecha_inicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fecha_final = table.Column<DateTime>(type: "datetime2", nullable: false),
                    meses = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    total = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_decimo_Terceros", x => x.Decimo_TerceroId);
                    table.ForeignKey(
                        name: "FK_decimo_Terceros_personales_PersonalId",
                        column: x => x.PersonalId,
                        principalTable: "personales",
                        principalColumn: "PersonalId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "empresas",
                columns: table => new
                {
                    EmpresaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonalId = table.Column<int>(type: "int", nullable: true),
                    ruc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nombreEmpresa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    provincia = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_empresas", x => x.EmpresaId);
                    table.ForeignKey(
                        name: "FK_empresas_personales_PersonalId",
                        column: x => x.PersonalId,
                        principalTable: "personales",
                        principalColumn: "PersonalId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "liquidaciones",
                columns: table => new
                {
                    LiquidacionesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonalId = table.Column<int>(type: "int", nullable: true),
                    cesantia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    periodo_pri = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    salario_base = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estadoliq = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_liquidaciones", x => x.LiquidacionesId);
                    table.ForeignKey(
                        name: "FK_liquidaciones_personales_PersonalId",
                        column: x => x.PersonalId,
                        principalTable: "personales",
                        principalColumn: "PersonalId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    RolesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonalId = table.Column<int>(type: "int", nullable: true),
                    comision = table.Column<float>(type: "real", nullable: false),
                    aporte_iess = table.Column<float>(type: "real", nullable: false),
                    anticipo = table.Column<float>(type: "real", nullable: false),
                    total = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roles", x => x.RolesId);
                    table.ForeignKey(
                        name: "FK_roles_personales_PersonalId",
                        column: x => x.PersonalId,
                        principalTable: "personales",
                        principalColumn: "PersonalId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "salarios",
                columns: table => new
                {
                    SalarioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonalId = table.Column<int>(type: "int", nullable: true),
                    SueldoBasico = table.Column<float>(type: "real", nullable: false),
                    DecimoTercerSueldo = table.Column<float>(type: "real", nullable: false),
                    DecimoCuartoSueldo = table.Column<float>(type: "real", nullable: false),
                    Utilidades = table.Column<float>(type: "real", nullable: false),
                    EstadoSal = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_salarios", x => x.SalarioId);
                    table.ForeignKey(
                        name: "FK_salarios_personales_PersonalId",
                        column: x => x.PersonalId,
                        principalTable: "personales",
                        principalColumn: "PersonalId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_decimo_Terceros_PersonalId",
                table: "decimo_Terceros",
                column: "PersonalId");

            migrationBuilder.CreateIndex(
                name: "IX_empresas_PersonalId",
                table: "empresas",
                column: "PersonalId",
                unique: true,
                filter: "[PersonalId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_liquidaciones_PersonalId",
                table: "liquidaciones",
                column: "PersonalId",
                unique: true,
                filter: "[PersonalId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_roles_PersonalId",
                table: "roles",
                column: "PersonalId");

            migrationBuilder.CreateIndex(
                name: "IX_salarios_PersonalId",
                table: "salarios",
                column: "PersonalId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "configuracion");

            migrationBuilder.DropTable(
                name: "decimo_Terceros");

            migrationBuilder.DropTable(
                name: "empresas");

            migrationBuilder.DropTable(
                name: "liquidaciones");

            migrationBuilder.DropTable(
                name: "roles");

            migrationBuilder.DropTable(
                name: "salarios");

            migrationBuilder.DropTable(
                name: "personales");
        }
    }
}
