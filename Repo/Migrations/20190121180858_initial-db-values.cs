using Microsoft.EntityFrameworkCore.Migrations;

namespace Repo.Migrations
{
    public partial class initialdbvalues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"INSERT INTO dbo.clients(ClientId, AllowOfflineAccess, AccessTokenIsReference, AccessTokenLifeTime, RefreshTokenExpiration, SlidingRefreshTokenLifeTime,Enabled) 
                        VALUES('ResourceOwner', 1, 1, 3600, 0, 196000, 1);");
            migrationBuilder.Sql(@"INSERT INTO dbo.ClientScopes(ClientId, Scope) VALUES(1, 'api1');");
            migrationBuilder.Sql(@"INSERT INTO dbo.ClientGrantTypes(ClientId, GrantType) VALUES(1, 'password');");
            migrationBuilder.Sql(@"INSERT INTO dbo.ClientSecrets(ClientId, Type, Expiration, Value) VALUES(1, 'SharedSecret', '2022-01-01', 'K7gNU3sdo+OL0wNhqoVWhr3g6s1xYv72ol/pe/Unols=');");
            migrationBuilder.Sql(@"INSERT INTO dbo.Users(email, username, password, active, emailverified, phonenumberverified) 
                        VALUES('jon@doe.com', 'jon@doe.com', 'AQAAAAEAACcQAAAAEFCBm+wGLhwZWA6dTxVSh/x6lj+Le2iV2kTmwO091UlAq7/Xodmy6+xC8FQTF/sO8A==', 1, 1, 0);");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
