using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace api.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Reference = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Designation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    stockFinal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    stockInitial = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    QteVendue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    QteAcheté = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    stockMinimal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PrixAchat_HT = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PrixAchat_TTC = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PrixVente_HT = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PrixVente_TTC = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Info = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Raisonsociale = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    code = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Telephone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fax = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adresse = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Profil",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LabelAr = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profil", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adresse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfilId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Profil_ProfilId",
                        column: x => x.ProfilId,
                        principalTable: "Profil",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LivraisonClients",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Numero = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Telephone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Info = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MontantHT = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TVA = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MontantTTC = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Escompte = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IdClient = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdUser = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LivraisonClients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LivraisonClients_Clients_IdClient",
                        column: x => x.IdClient,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LivraisonClients_Users_IdUser",
                        column: x => x.IdUser,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetailLivraisonClients",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Numero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Designation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantite = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Prix = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MontantHT = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TVA = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MontantTTC = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IdLivraisonClient = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdArticle = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailLivraisonClients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetailLivraisonClients_Articles_IdArticle",
                        column: x => x.IdArticle,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetailLivraisonClients_LivraisonClients_IdLivraisonClient",
                        column: x => x.IdLivraisonClient,
                        principalTable: "LivraisonClients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReglementClients",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Montant = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    D_Creation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdLivraisonClient = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReglementClients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReglementClients_LivraisonClients_IdLivraisonClient",
                        column: x => x.IdLivraisonClient,
                        principalTable: "LivraisonClients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Profil",
                columns: new[] { "Id", "Label", "LabelAr" },
                values: new object[,]
                {
                    { 1, "Administrateur", "مدير" },
                    { 2, "Superviseur", "مشرف" },
                    { 3, "Point focal", "	المخاطب الرئيسي" },
                    { 4, "Propriétaire", "مالك" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Articles_Reference",
                table: "Articles",
                column: "Reference",
                unique: true,
                filter: "[Reference] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_code",
                table: "Clients",
                column: "code",
                unique: true,
                filter: "[code] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_Raisonsociale",
                table: "Clients",
                column: "Raisonsociale",
                unique: true,
                filter: "[Raisonsociale] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_DetailLivraisonClients_IdArticle",
                table: "DetailLivraisonClients",
                column: "IdArticle");

            migrationBuilder.CreateIndex(
                name: "IX_DetailLivraisonClients_IdLivraisonClient",
                table: "DetailLivraisonClients",
                column: "IdLivraisonClient");

            migrationBuilder.CreateIndex(
                name: "IX_LivraisonClients_IdClient",
                table: "LivraisonClients",
                column: "IdClient");

            migrationBuilder.CreateIndex(
                name: "IX_LivraisonClients_IdUser",
                table: "LivraisonClients",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_LivraisonClients_Numero",
                table: "LivraisonClients",
                column: "Numero",
                unique: true,
                filter: "[Numero] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ReglementClients_IdLivraisonClient",
                table: "ReglementClients",
                column: "IdLivraisonClient");

            migrationBuilder.CreateIndex(
                name: "IX_Users_ProfilId",
                table: "Users",
                column: "ProfilId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetailLivraisonClients");

            migrationBuilder.DropTable(
                name: "ReglementClients");

            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "LivraisonClients");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Profil");
        }
    }
}
