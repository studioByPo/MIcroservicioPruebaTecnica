using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MicroservicioPrueba.Migrations
{
    public partial class StartUP : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    cl_id_cliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cl_password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cl_estado = table.Column<bool>(type: "bit", nullable: false),
                    pr_nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    pr_genero = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    pr_edad = table.Column<int>(type: "int", nullable: false),
                    pr_identificacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    pr_direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    pr_telefono = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.cl_id_cliente);
                });

            migrationBuilder.CreateTable(
                name: "Parametros",
                columns: table => new
                {
                    par_id_parametro = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    par_descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    par_valor = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parametros", x => x.par_id_parametro);
                });

            migrationBuilder.CreateTable(
                name: "TipoCuenta",
                columns: table => new
                {
                    tc_id_tipo_cuenta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tc_codigo = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    tc_descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoCuenta", x => x.tc_id_tipo_cuenta);
                });

            migrationBuilder.CreateTable(
                name: "TipoMovimiento",
                columns: table => new
                {
                    tm_id_tipo_movimiento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tm_codigo = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    tm_descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoMovimiento", x => x.tm_id_tipo_movimiento);
                });

            migrationBuilder.CreateTable(
                name: "Cuenta",
                columns: table => new
                {
                    cu_id_cuenta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cu_numero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cu_cliente = table.Column<int>(type: "int", nullable: false),
                    cu_tipo = table.Column<int>(type: "int", nullable: false),
                    cu_saldo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    cu_estado = table.Column<string>(type: "nvarchar(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cuenta", x => x.cu_id_cuenta);
                    table.ForeignKey(
                        name: "FK_Cuenta_Cliente_cu_cliente",
                        column: x => x.cu_cliente,
                        principalTable: "Cliente",
                        principalColumn: "cl_id_cliente",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cuenta_TipoCuenta_cu_tipo",
                        column: x => x.cu_tipo,
                        principalTable: "TipoCuenta",
                        principalColumn: "tc_id_tipo_cuenta",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Movimientos",
                columns: table => new
                {
                    mo_id_movimiento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    mo_fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    mo_id_cuenta = table.Column<int>(type: "int", nullable: false),
                    mo_tipo = table.Column<int>(type: "int", nullable: false),
                    mo_valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    mo_saldo_final = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movimientos", x => x.mo_id_movimiento);
                    table.ForeignKey(
                        name: "FK_Movimientos_Cuenta_mo_id_cuenta",
                        column: x => x.mo_id_cuenta,
                        principalTable: "Cuenta",
                        principalColumn: "cu_id_cuenta",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Movimientos_TipoMovimiento_mo_tipo",
                        column: x => x.mo_tipo,
                        principalTable: "TipoMovimiento",
                        principalColumn: "tm_id_tipo_movimiento",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cuenta_cu_cliente",
                table: "Cuenta",
                column: "cu_cliente");

            migrationBuilder.CreateIndex(
                name: "IX_Cuenta_cu_tipo",
                table: "Cuenta",
                column: "cu_tipo");

            migrationBuilder.CreateIndex(
                name: "IX_Movimientos_mo_id_cuenta",
                table: "Movimientos",
                column: "mo_id_cuenta");

            migrationBuilder.CreateIndex(
                name: "IX_Movimientos_mo_tipo",
                table: "Movimientos",
                column: "mo_tipo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movimientos");

            migrationBuilder.DropTable(
                name: "Parametros");

            migrationBuilder.DropTable(
                name: "Cuenta");

            migrationBuilder.DropTable(
                name: "TipoMovimiento");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "TipoCuenta");
        }
    }
}
