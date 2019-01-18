using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Repo.Migrations
{
    public partial class kickstart2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientCorsOrigin_Clients_ClientId",
                table: "ClientCorsOrigin");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientGrantType_Clients_ClientId",
                table: "ClientGrantType");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientScope_Clients_ClientId",
                table: "ClientScope");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientSecret_Clients_ClientId",
                table: "ClientSecret");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClientSecret",
                table: "ClientSecret");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClientScope",
                table: "ClientScope");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClientGrantType",
                table: "ClientGrantType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClientCorsOrigin",
                table: "ClientCorsOrigin");

            migrationBuilder.RenameTable(
                name: "ClientSecret",
                newName: "ClientSecrets");

            migrationBuilder.RenameTable(
                name: "ClientScope",
                newName: "ClientScopes");

            migrationBuilder.RenameTable(
                name: "ClientGrantType",
                newName: "ClientGrantTypes");

            migrationBuilder.RenameTable(
                name: "ClientCorsOrigin",
                newName: "ClientCorsOrigins");

            migrationBuilder.RenameIndex(
                name: "IX_ClientSecret_ClientId",
                table: "ClientSecrets",
                newName: "IX_ClientSecrets_ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_ClientScope_ClientId",
                table: "ClientScopes",
                newName: "IX_ClientScopes_ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_ClientGrantType_ClientId",
                table: "ClientGrantTypes",
                newName: "IX_ClientGrantTypes_ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_ClientCorsOrigin_ClientId",
                table: "ClientCorsOrigins",
                newName: "IX_ClientCorsOrigins_ClientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClientSecrets",
                table: "ClientSecrets",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClientScopes",
                table: "ClientScopes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClientGrantTypes",
                table: "ClientGrantTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClientCorsOrigins",
                table: "ClientCorsOrigins",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: true),
                    Username = table.Column<string>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    EmailVerified = table.Column<bool>(nullable: false),
                    PhoneNumberVerified = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmailVerificationTokens",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<long>(nullable: false),
                    Token = table.Column<string>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    ExpiryTime = table.Column<DateTime>(nullable: false),
                    Used = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailVerificationTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmailVerificationTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PasswordResetTokens",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<long>(nullable: false),
                    Token = table.Column<string>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    ExpiryTime = table.Column<DateTime>(nullable: false),
                    Used = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PasswordResetTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PasswordResetTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<long>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserSessions",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<long>(nullable: false),
                    SessionId = table.Column<string>(nullable: true),
                    Browser = table.Column<string>(nullable: true),
                    OperatingSystem = table.Column<string>(nullable: true),
                    DeviceId = table.Column<string>(nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: true),
                    RefreshToken = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserSessions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmailVerificationTokens_UserId",
                table: "EmailVerificationTokens",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PasswordResetTokens_UserId",
                table: "PasswordResetTokens",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                table: "UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSessions_UserId",
                table: "UserSessions",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientCorsOrigins_Clients_ClientId",
                table: "ClientCorsOrigins",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientGrantTypes_Clients_ClientId",
                table: "ClientGrantTypes",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientScopes_Clients_ClientId",
                table: "ClientScopes",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientSecrets_Clients_ClientId",
                table: "ClientSecrets",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientCorsOrigins_Clients_ClientId",
                table: "ClientCorsOrigins");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientGrantTypes_Clients_ClientId",
                table: "ClientGrantTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientScopes_Clients_ClientId",
                table: "ClientScopes");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientSecrets_Clients_ClientId",
                table: "ClientSecrets");

            migrationBuilder.DropTable(
                name: "EmailVerificationTokens");

            migrationBuilder.DropTable(
                name: "PasswordResetTokens");

            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "UserSessions");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClientSecrets",
                table: "ClientSecrets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClientScopes",
                table: "ClientScopes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClientGrantTypes",
                table: "ClientGrantTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClientCorsOrigins",
                table: "ClientCorsOrigins");

            migrationBuilder.RenameTable(
                name: "ClientSecrets",
                newName: "ClientSecret");

            migrationBuilder.RenameTable(
                name: "ClientScopes",
                newName: "ClientScope");

            migrationBuilder.RenameTable(
                name: "ClientGrantTypes",
                newName: "ClientGrantType");

            migrationBuilder.RenameTable(
                name: "ClientCorsOrigins",
                newName: "ClientCorsOrigin");

            migrationBuilder.RenameIndex(
                name: "IX_ClientSecrets_ClientId",
                table: "ClientSecret",
                newName: "IX_ClientSecret_ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_ClientScopes_ClientId",
                table: "ClientScope",
                newName: "IX_ClientScope_ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_ClientGrantTypes_ClientId",
                table: "ClientGrantType",
                newName: "IX_ClientGrantType_ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_ClientCorsOrigins_ClientId",
                table: "ClientCorsOrigin",
                newName: "IX_ClientCorsOrigin_ClientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClientSecret",
                table: "ClientSecret",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClientScope",
                table: "ClientScope",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClientGrantType",
                table: "ClientGrantType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClientCorsOrigin",
                table: "ClientCorsOrigin",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientCorsOrigin_Clients_ClientId",
                table: "ClientCorsOrigin",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientGrantType_Clients_ClientId",
                table: "ClientGrantType",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientScope_Clients_ClientId",
                table: "ClientScope",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientSecret_Clients_ClientId",
                table: "ClientSecret",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
