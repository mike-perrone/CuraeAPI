using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FiralApiReal.Migrations
{
    public partial class AddedUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Username = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<byte[]>(nullable: true),
                    PasswordSalt = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
// so far and certainly for our skeleton
// methods are inside controllers
// not the right way to go about this
// repository pattern
// database queries
// level of abstraction
// between database and controller which is entity framework
// we dont query db directly
// we query entity framework
// one level of abstraction
// kinda like mongoose?
// repository interface
// concrete implementation of said interface
// interface exposes methods that the controller can utilize
// controller doesnt care how they are implemented just needs to know theyre available
// repository exposes these mthods
// respository implemenation we implement this stuff
// write instructions to entity framework
// 