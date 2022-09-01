using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eComerceWebsite.Migrations
{
    public partial class ChangedDbSetMembersName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MembersMembers",
                table: "MembersMembers");

            migrationBuilder.RenameTable(
                name: "MembersMembers",
                newName: "Members");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Members",
                table: "Members",
                column: "MemberID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Members",
                table: "Members");

            migrationBuilder.RenameTable(
                name: "Members",
                newName: "MembersMembers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MembersMembers",
                table: "MembersMembers",
                column: "MemberID");
        }
    }
}
