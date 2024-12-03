using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace aplicacaoFinal.Migrations
{
    /// <inheritdoc />
    public partial class bdaplicacaoFinal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModeloCarro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KwCarro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModeloPino = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.IdUsuario);
                });

            migrationBuilder.CreateTable(
                name: "Posto",
                columns: table => new
                {
                    IdPosto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomePosto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoPino = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PotenciaPosto = table.Column<int>(type: "int", nullable: false),
                    PrecoPorKwh = table.Column<double>(type: "float", nullable: false),
                    Rua = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bairro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    UsuarioIdUsuario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posto", x => x.IdPosto);
                    table.ForeignKey(
                        name: "FK_Posto_Usuario_UsuarioIdUsuario",
                        column: x => x.UsuarioIdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Posto_UsuarioIdUsuario",
                table: "Posto",
                column: "UsuarioIdUsuario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Posto");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
