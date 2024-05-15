using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DriveEasee.Migrations
{
    public partial class AddIdentityTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "aluguer",
                columns: table => new
                {
                    id_aluguer = table.Column<int>(type: "int", nullable: false),
                    data_inicio = table.Column<DateTime>(type: "date", nullable: true),
                    data_fim = table.Column<DateTime>(type: "datetime", nullable: true),
                    valor = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    cliente_id_cliente = table.Column<int>(type: "int", nullable: false),
                    carro_id_carro = table.Column<int>(type: "int", nullable: false),
                    drive_ease_id_drive_ease = table.Column<int>(type: "int", nullable: false),
                    caucao_id_caucao = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__aluguer__9A65BA21F8375203", x => x.id_aluguer);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "carro",
                columns: table => new
                {
                    id_carro = table.Column<int>(type: "int", nullable: false),
                    matricula = table.Column<string>(type: "varchar(45)", unicode: false, maxLength: 45, nullable: true),
                    tara = table.Column<int>(type: "int", nullable: true),
                    lotacao = table.Column<int>(type: "int", nullable: true),
                    estado_carro_id_estado_carro = table.Column<int>(type: "int", nullable: false),
                    categoria_carro_id_categoria_carro = table.Column<int>(type: "int", nullable: false),
                    modelo_id_modelo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__carro__D3C318A10909D54C", x => x.id_carro);
                });

            migrationBuilder.CreateTable(
                name: "categoria_carro",
                columns: table => new
                {
                    id_categoria_carro = table.Column<int>(type: "int", nullable: false),
                    nome_categoria = table.Column<string>(type: "varchar(45)", unicode: false, maxLength: 45, nullable: true),
                    modelo_id_modelo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__categori__59AE7B044CDE2050", x => x.id_categoria_carro);
                });

            migrationBuilder.CreateTable(
                name: "caucao",
                columns: table => new
                {
                    id_caucao = table.Column<int>(type: "int", nullable: false),
                    valor = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    estado = table.Column<string>(type: "varchar(45)", unicode: false, maxLength: 45, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__caucao__5B5579FF632FD639", x => x.id_caucao);
                });

            migrationBuilder.CreateTable(
                name: "cliente",
                columns: table => new
                {
                    id_cliente = table.Column<int>(type: "int", nullable: false),
                    cpostal_id_cpostal = table.Column<int>(type: "int", nullable: false),
                    nome = table.Column<string>(type: "varchar(45)", unicode: false, maxLength: 45, nullable: true),
                    morada = table.Column<string>(type: "varchar(45)", unicode: false, maxLength: 45, nullable: true),
                    ntelemovel = table.Column<int>(type: "int", nullable: true),
                    email = table.Column<string>(type: "varchar(45)", unicode: false, maxLength: 45, nullable: true),
                    password = table.Column<string>(type: "varchar(45)", unicode: false, maxLength: 45, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__cliente__677F38F50C78B6CE", x => x.id_cliente);
                });

            migrationBuilder.CreateTable(
                name: "cpostal",
                columns: table => new
                {
                    id_cpostal = table.Column<int>(type: "int", nullable: false),
                    inicio = table.Column<int>(type: "int", nullable: true),
                    fim = table.Column<int>(type: "int", nullable: true),
                    localizacao = table.Column<string>(type: "varchar(45)", unicode: false, maxLength: 45, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__cpostal__7ACC4223750B364B", x => x.id_cpostal);
                });

            migrationBuilder.CreateTable(
                name: "devolucao",
                columns: table => new
                {
                    id_devolucao = table.Column<int>(type: "int", nullable: false),
                    tecnico_id_tecnico = table.Column<int>(type: "int", nullable: false),
                    data = table.Column<DateTime>(type: "date", nullable: true),
                    hora = table.Column<DateTime>(type: "datetime", nullable: true),
                    tipo = table.Column<string>(type: "varchar(45)", unicode: false, maxLength: 45, nullable: true),
                    valor_extra = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    aluguer_id_aluguer = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__devoluca__F014558F1407260A", x => x.id_devolucao);
                });

            migrationBuilder.CreateTable(
                name: "drive_ease",
                columns: table => new
                {
                    id_drive_ease = table.Column<int>(type: "int", nullable: false),
                    nome = table.Column<string>(type: "varchar(45)", unicode: false, maxLength: 45, nullable: true),
                    morada = table.Column<string>(type: "varchar(45)", unicode: false, maxLength: 45, nullable: true),
                    ntelemovel = table.Column<int>(type: "int", nullable: true),
                    email = table.Column<string>(type: "varchar(45)", unicode: false, maxLength: 45, nullable: true),
                    cpostal_id_cpostal = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__drive_ea__D35F3F4AECA266BE", x => x.id_drive_ease);
                });

            migrationBuilder.CreateTable(
                name: "entrega",
                columns: table => new
                {
                    id_entrega = table.Column<int>(type: "int", nullable: false),
                    data = table.Column<DateTime>(type: "date", nullable: true),
                    hora = table.Column<DateTime>(type: "datetime", nullable: true),
                    tecnico_id_tecnico = table.Column<int>(type: "int", nullable: false),
                    aluguer_id_aluguer = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__entrega__017C2C8A32F4789C", x => x.id_entrega);
                });

            migrationBuilder.CreateTable(
                name: "estado_carro",
                columns: table => new
                {
                    id_estado_carro = table.Column<int>(type: "int", nullable: false),
                    nome = table.Column<string>(type: "varchar(45)", unicode: false, maxLength: 45, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__estado_c__6F179939137618E1", x => x.id_estado_carro);
                });

            migrationBuilder.CreateTable(
                name: "fatura",
                columns: table => new
                {
                    id_fatura = table.Column<int>(type: "int", nullable: false),
                    pagamento_id_pagamento = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__fatura__F4902DCBEC611D31", x => x.id_fatura);
                });

            migrationBuilder.CreateTable(
                name: "manutencao",
                columns: table => new
                {
                    id_manutencao = table.Column<int>(type: "int", nullable: false),
                    proposito = table.Column<string>(type: "varchar(45)", unicode: false, maxLength: 45, nullable: true),
                    data = table.Column<DateTime>(type: "date", nullable: true),
                    hora = table.Column<DateTime>(type: "datetime", nullable: true),
                    custo = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    carro_id_carro = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__manutenc__5F9D64EE5867C87B", x => x.id_manutencao);
                });

            migrationBuilder.CreateTable(
                name: "marca",
                columns: table => new
                {
                    id_marca = table.Column<int>(type: "int", nullable: false),
                    nome_marca = table.Column<string>(type: "varchar(45)", unicode: false, maxLength: 45, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__marca__7E43E99EE697C484", x => x.id_marca);
                });

            migrationBuilder.CreateTable(
                name: "modelo",
                columns: table => new
                {
                    id_modelo = table.Column<int>(type: "int", nullable: false),
                    nome_modelo = table.Column<string>(type: "varchar(45)", unicode: false, maxLength: 45, nullable: true),
                    marca_id_marca = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__modelo__B3BFCFF1C7735D1C", x => x.id_modelo);
                });

            migrationBuilder.CreateTable(
                name: "pagamento",
                columns: table => new
                {
                    id_pagamento = table.Column<int>(type: "int", nullable: false),
                    aluguer_id_aluguer = table.Column<int>(type: "int", nullable: false),
                    valor = table.Column<string>(type: "varchar(45)", unicode: false, maxLength: 45, nullable: true),
                    metodo = table.Column<string>(type: "varchar(45)", unicode: false, maxLength: 45, nullable: true),
                    data = table.Column<DateTime>(type: "date", nullable: true),
                    tipo_pagamento_id_tipo_pagamento = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__pagament__3A2D33F72137B179", x => x.id_pagamento);
                });

            migrationBuilder.CreateTable(
                name: "review",
                columns: table => new
                {
                    id_review = table.Column<int>(type: "int", nullable: false),
                    observacoes = table.Column<string>(type: "varchar(45)", unicode: false, maxLength: 45, nullable: true),
                    aluguer_id_aluguer = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__review__2F79F8C720E6BE66", x => x.id_review);
                });

            migrationBuilder.CreateTable(
                name: "tecnico",
                columns: table => new
                {
                    id_tecnico = table.Column<int>(type: "int", nullable: false),
                    cpostal_id_cpostal = table.Column<int>(type: "int", nullable: false),
                    nome = table.Column<string>(type: "varchar(45)", unicode: false, maxLength: 45, nullable: true),
                    morada = table.Column<string>(type: "varchar(45)", unicode: false, maxLength: 45, nullable: true),
                    ntelemovel = table.Column<int>(type: "int", nullable: true),
                    email = table.Column<string>(type: "varchar(45)", unicode: false, maxLength: 45, nullable: true),
                    password = table.Column<string>(type: "varchar(45)", unicode: false, maxLength: 45, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tecnico__D550973742A1F47B", x => x.id_tecnico);
                });

            migrationBuilder.CreateTable(
                name: "tipo_pagamento",
                columns: table => new
                {
                    id_tipo_pagamento = table.Column<int>(type: "int", nullable: false),
                    nome_tipo = table.Column<string>(type: "varchar(45)", unicode: false, maxLength: 45, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tipo_pag__01B984C7806933CE", x => x.id_tipo_pagamento);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "aluguer");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "carro");

            migrationBuilder.DropTable(
                name: "categoria_carro");

            migrationBuilder.DropTable(
                name: "caucao");

            migrationBuilder.DropTable(
                name: "cliente");

            migrationBuilder.DropTable(
                name: "cpostal");

            migrationBuilder.DropTable(
                name: "devolucao");

            migrationBuilder.DropTable(
                name: "drive_ease");

            migrationBuilder.DropTable(
                name: "entrega");

            migrationBuilder.DropTable(
                name: "estado_carro");

            migrationBuilder.DropTable(
                name: "fatura");

            migrationBuilder.DropTable(
                name: "manutencao");

            migrationBuilder.DropTable(
                name: "marca");

            migrationBuilder.DropTable(
                name: "modelo");

            migrationBuilder.DropTable(
                name: "pagamento");

            migrationBuilder.DropTable(
                name: "review");

            migrationBuilder.DropTable(
                name: "tecnico");

            migrationBuilder.DropTable(
                name: "tipo_pagamento");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
