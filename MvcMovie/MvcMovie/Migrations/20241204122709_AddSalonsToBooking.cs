﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MvcMovie.Migrations
{
    /// <inheritdoc />
    public partial class AddSalonsToBooking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BookingId",
                table: "Salons",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Salons_BookingId",
                table: "Salons",
                column: "BookingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Salons_Bookings_BookingId",
                table: "Salons",
                column: "BookingId",
                principalTable: "Bookings",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Salons_Bookings_BookingId",
                table: "Salons");

            migrationBuilder.DropIndex(
                name: "IX_Salons_BookingId",
                table: "Salons");

            migrationBuilder.DropColumn(
                name: "BookingId",
                table: "Salons");
        }
    }
}
