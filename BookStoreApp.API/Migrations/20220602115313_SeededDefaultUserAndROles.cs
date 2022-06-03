using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStoreApp.API.Migrations
{
    public partial class SeededDefaultUserAndROles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "70cde050-5520-4970-9317-ebae7c03c733", "32c12106-a5d3-4778-b6f7-9f8084fde287", "User", "USER" },
                    { "cfcc303a-d6b5-4276-aad2-47a7f2cfe2e0", "34a2f9eb-a563-4176-baf4-6d4743d6d5c9", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1e9a439e-59c4-485e-a7fb-582aa9dac9d3", 0, "ddc6ebee-7554-42e6-b008-0588b206358f", "admin@bookstore.com", false, "System", "Admin", false, null, "ADMIN@BOOKSTORE.COM", "ADMIN@BOOKSTORE.COM", "AQAAAAEAACcQAAAAEPd4VMzpgyT+JGImZxaitKMs3ukLs4Cs3ivFMPgZi3AKJUXKYLeAG8Hma4Wx9ab6Qw==", null, false, "2a9e2668-e03c-4e79-8eb1-15bc44b4f8c0", false, "admin@bookstore.com" },
                    { "93c70946-9052-4a3f-9368-ec97a29cee7a", 0, "8a0d7853-5292-45db-ac90-b920d1a8a9cf", "user@bookstore.com", false, "System", "User", false, null, "USER@BOOKSTORE.COM", "USER@BOOKSTORE.COM", "AQAAAAEAACcQAAAAENPA3ezHB3Jg17DHBXKtn2rdChst/oOnNXRWaDbxRjHrijY7fZyMCgNibMqnff821Q==", null, false, "ce5f6f35-b1fd-4eb6-8334-16eb0053c0ff", false, "user@bookstore.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "cfcc303a-d6b5-4276-aad2-47a7f2cfe2e0", "1e9a439e-59c4-485e-a7fb-582aa9dac9d3" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "70cde050-5520-4970-9317-ebae7c03c733", "93c70946-9052-4a3f-9368-ec97a29cee7a" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "cfcc303a-d6b5-4276-aad2-47a7f2cfe2e0", "1e9a439e-59c4-485e-a7fb-582aa9dac9d3" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "70cde050-5520-4970-9317-ebae7c03c733", "93c70946-9052-4a3f-9368-ec97a29cee7a" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "70cde050-5520-4970-9317-ebae7c03c733");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cfcc303a-d6b5-4276-aad2-47a7f2cfe2e0");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1e9a439e-59c4-485e-a7fb-582aa9dac9d3");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "93c70946-9052-4a3f-9368-ec97a29cee7a");
        }
    }
}
