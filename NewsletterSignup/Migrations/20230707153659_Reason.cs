using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewsletterSignup.Migrations
{
    /// <inheritdoc />
    public partial class Reason : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Reason",
                table: "NewsletterSignup",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Reason",
                table: "NewsletterSignup");
        }
    }
}
