using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Yellowtail.Cord.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RemoveQueryFiltersAndSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Sports",
                columns: new[] { "Id", "Description", "ModifiedBy", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { new Guid("55555555-5555-5555-5555-555555555551"), "Field team sport", new Guid("00000000-0000-0000-0000-000000000001"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Soccer" },
                    { new Guid("55555555-5555-5555-5555-555555555552"), "Court team sport", new Guid("00000000-0000-0000-0000-000000000001"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Basketball" },
                    { new Guid("55555555-5555-5555-5555-555555555553"), "Racket sport", new Guid("00000000-0000-0000-0000-000000000001"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Tennis" },
                    { new Guid("55555555-5555-5555-5555-555555555554"), "Water-based racing", new Guid("00000000-0000-0000-0000-000000000001"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Swimming" },
                    { new Guid("55555555-5555-5555-5555-555555555555"), "Track and field", new Guid("00000000-0000-0000-0000-000000000001"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Athletics" },
                    { new Guid("55555555-5555-5555-5555-555555555556"), "Bicycle racing", new Guid("00000000-0000-0000-0000-000000000001"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Cycling" },
                    { new Guid("55555555-5555-5555-5555-555555555557"), "Combat sport", new Guid("00000000-0000-0000-0000-000000000001"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Boxing" },
                    { new Guid("55555555-5555-5555-5555-555555555558"), "Acrobatic sport", new Guid("00000000-0000-0000-0000-000000000001"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Gymnastics" },
                    { new Guid("55555555-5555-5555-5555-555555555559"), "Court team sport", new Guid("00000000-0000-0000-0000-000000000001"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Volleyball" },
                    { new Guid("55555555-5555-5555-5555-55555555555a"), "Contact team sport", new Guid("00000000-0000-0000-0000-000000000001"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Rugby" }
                });

            migrationBuilder.InsertData(
                table: "Tenants",
                columns: new[] { "Id", "IsActive", "ModifiedBy", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), true, new Guid("00000000-0000-0000-0000-000000000001"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Default" },
                    { new Guid("22222222-2222-2222-2222-222222222222"), true, new Guid("00000000-0000-0000-0000-000000000001"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Titanium Sports Club" },
                    { new Guid("33333333-3333-3333-3333-333333333333"), true, new Guid("00000000-0000-0000-0000-000000000001"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Apex Athletics Club" },
                    { new Guid("44444444-4444-4444-4444-444444444444"), true, new Guid("00000000-0000-0000-0000-000000000001"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Quantum Fitness Club" }
                });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "Id", "FirstName", "LastName", "ModifiedBy", "ModifiedDate", "PhotoUrl", "TenantId" },
                values: new object[,]
                {
                    { new Guid("66666666-6666-6666-6666-666666666661"), "Alice", "Smith", new Guid("00000000-0000-0000-0000-000000000001"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, new Guid("22222222-2222-2222-2222-222222222222") },
                    { new Guid("66666666-6666-6666-6666-666666666662"), "Bob", "Johnson", new Guid("00000000-0000-0000-0000-000000000001"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, new Guid("22222222-2222-2222-2222-222222222222") },
                    { new Guid("66666666-6666-6666-6666-666666666663"), "Charlie", "Brown", new Guid("00000000-0000-0000-0000-000000000001"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, new Guid("22222222-2222-2222-2222-222222222222") },
                    { new Guid("66666666-6666-6666-6666-666666666664"), "Diana", "Prince", new Guid("00000000-0000-0000-0000-000000000001"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, new Guid("33333333-3333-3333-3333-333333333333") },
                    { new Guid("66666666-6666-6666-6666-666666666665"), "Evan", "Wright", new Guid("00000000-0000-0000-0000-000000000001"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, new Guid("33333333-3333-3333-3333-333333333333") },
                    { new Guid("66666666-6666-6666-6666-666666666666"), "Fiona", "Gallagher", new Guid("00000000-0000-0000-0000-000000000001"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, new Guid("33333333-3333-3333-3333-333333333333") },
                    { new Guid("66666666-6666-6666-6666-666666666667"), "George", "Clark", new Guid("00000000-0000-0000-0000-000000000001"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, new Guid("44444444-4444-4444-4444-444444444444") },
                    { new Guid("66666666-6666-6666-6666-666666666668"), "Hannah", "Abbott", new Guid("00000000-0000-0000-0000-000000000001"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, new Guid("44444444-4444-4444-4444-444444444444") },
                    { new Guid("66666666-6666-6666-6666-666666666669"), "Ian", "Malcolm", new Guid("00000000-0000-0000-0000-000000000001"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, new Guid("44444444-4444-4444-4444-444444444444") }
                });

            migrationBuilder.InsertData(
                table: "MemberSports",
                columns: new[] { "MemberId", "SportId" },
                values: new object[,]
                {
                    { new Guid("66666666-6666-6666-6666-666666666661"), new Guid("55555555-5555-5555-5555-555555555551") },
                    { new Guid("66666666-6666-6666-6666-666666666662"), new Guid("55555555-5555-5555-5555-555555555552") },
                    { new Guid("66666666-6666-6666-6666-666666666662"), new Guid("55555555-5555-5555-5555-555555555553") },
                    { new Guid("66666666-6666-6666-6666-666666666663"), new Guid("55555555-5555-5555-5555-555555555554") },
                    { new Guid("66666666-6666-6666-6666-666666666664"), new Guid("55555555-5555-5555-5555-555555555555") },
                    { new Guid("66666666-6666-6666-6666-666666666664"), new Guid("55555555-5555-5555-5555-555555555556") },
                    { new Guid("66666666-6666-6666-6666-666666666665"), new Guid("55555555-5555-5555-5555-555555555557") },
                    { new Guid("66666666-6666-6666-6666-666666666666"), new Guid("55555555-5555-5555-5555-555555555558") },
                    { new Guid("66666666-6666-6666-6666-666666666666"), new Guid("55555555-5555-5555-5555-555555555559") },
                    { new Guid("66666666-6666-6666-6666-666666666667"), new Guid("55555555-5555-5555-5555-55555555555a") },
                    { new Guid("66666666-6666-6666-6666-666666666668"), new Guid("55555555-5555-5555-5555-555555555551") },
                    { new Guid("66666666-6666-6666-6666-666666666668"), new Guid("55555555-5555-5555-5555-555555555554") },
                    { new Guid("66666666-6666-6666-6666-666666666669"), new Guid("55555555-5555-5555-5555-555555555552") },
                    { new Guid("66666666-6666-6666-6666-666666666669"), new Guid("55555555-5555-5555-5555-555555555556") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MemberSports",
                keyColumns: new[] { "MemberId", "SportId" },
                keyValues: new object[] { new Guid("66666666-6666-6666-6666-666666666661"), new Guid("55555555-5555-5555-5555-555555555551") });

            migrationBuilder.DeleteData(
                table: "MemberSports",
                keyColumns: new[] { "MemberId", "SportId" },
                keyValues: new object[] { new Guid("66666666-6666-6666-6666-666666666662"), new Guid("55555555-5555-5555-5555-555555555552") });

            migrationBuilder.DeleteData(
                table: "MemberSports",
                keyColumns: new[] { "MemberId", "SportId" },
                keyValues: new object[] { new Guid("66666666-6666-6666-6666-666666666662"), new Guid("55555555-5555-5555-5555-555555555553") });

            migrationBuilder.DeleteData(
                table: "MemberSports",
                keyColumns: new[] { "MemberId", "SportId" },
                keyValues: new object[] { new Guid("66666666-6666-6666-6666-666666666663"), new Guid("55555555-5555-5555-5555-555555555554") });

            migrationBuilder.DeleteData(
                table: "MemberSports",
                keyColumns: new[] { "MemberId", "SportId" },
                keyValues: new object[] { new Guid("66666666-6666-6666-6666-666666666664"), new Guid("55555555-5555-5555-5555-555555555555") });

            migrationBuilder.DeleteData(
                table: "MemberSports",
                keyColumns: new[] { "MemberId", "SportId" },
                keyValues: new object[] { new Guid("66666666-6666-6666-6666-666666666664"), new Guid("55555555-5555-5555-5555-555555555556") });

            migrationBuilder.DeleteData(
                table: "MemberSports",
                keyColumns: new[] { "MemberId", "SportId" },
                keyValues: new object[] { new Guid("66666666-6666-6666-6666-666666666665"), new Guid("55555555-5555-5555-5555-555555555557") });

            migrationBuilder.DeleteData(
                table: "MemberSports",
                keyColumns: new[] { "MemberId", "SportId" },
                keyValues: new object[] { new Guid("66666666-6666-6666-6666-666666666666"), new Guid("55555555-5555-5555-5555-555555555558") });

            migrationBuilder.DeleteData(
                table: "MemberSports",
                keyColumns: new[] { "MemberId", "SportId" },
                keyValues: new object[] { new Guid("66666666-6666-6666-6666-666666666666"), new Guid("55555555-5555-5555-5555-555555555559") });

            migrationBuilder.DeleteData(
                table: "MemberSports",
                keyColumns: new[] { "MemberId", "SportId" },
                keyValues: new object[] { new Guid("66666666-6666-6666-6666-666666666667"), new Guid("55555555-5555-5555-5555-55555555555a") });

            migrationBuilder.DeleteData(
                table: "MemberSports",
                keyColumns: new[] { "MemberId", "SportId" },
                keyValues: new object[] { new Guid("66666666-6666-6666-6666-666666666668"), new Guid("55555555-5555-5555-5555-555555555551") });

            migrationBuilder.DeleteData(
                table: "MemberSports",
                keyColumns: new[] { "MemberId", "SportId" },
                keyValues: new object[] { new Guid("66666666-6666-6666-6666-666666666668"), new Guid("55555555-5555-5555-5555-555555555554") });

            migrationBuilder.DeleteData(
                table: "MemberSports",
                keyColumns: new[] { "MemberId", "SportId" },
                keyValues: new object[] { new Guid("66666666-6666-6666-6666-666666666669"), new Guid("55555555-5555-5555-5555-555555555552") });

            migrationBuilder.DeleteData(
                table: "MemberSports",
                keyColumns: new[] { "MemberId", "SportId" },
                keyValues: new object[] { new Guid("66666666-6666-6666-6666-666666666669"), new Guid("55555555-5555-5555-5555-555555555556") });

            migrationBuilder.DeleteData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666661"));

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666662"));

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666663"));

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666664"));

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666665"));

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666666"));

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666667"));

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666668"));

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666669"));

            migrationBuilder.DeleteData(
                table: "Sports",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555551"));

            migrationBuilder.DeleteData(
                table: "Sports",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555552"));

            migrationBuilder.DeleteData(
                table: "Sports",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555553"));

            migrationBuilder.DeleteData(
                table: "Sports",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555554"));

            migrationBuilder.DeleteData(
                table: "Sports",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"));

            migrationBuilder.DeleteData(
                table: "Sports",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555556"));

            migrationBuilder.DeleteData(
                table: "Sports",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555557"));

            migrationBuilder.DeleteData(
                table: "Sports",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555558"));

            migrationBuilder.DeleteData(
                table: "Sports",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555559"));

            migrationBuilder.DeleteData(
                table: "Sports",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-55555555555a"));

            migrationBuilder.DeleteData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"));

            migrationBuilder.DeleteData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"));

            migrationBuilder.DeleteData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444444"));
        }
    }
}
