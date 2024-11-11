﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GradTech.DAL.DbAll.Migrations
{
    /// <inheritdoc />
    public partial class ChangeFuctionTotalAmount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
        CREATE FUNCTION dbo.CalculateTotalAmountToReservation
        (
            @UnitId BIGINT,
            @StartDate DATE,
            @EndDate DATE
        )
        RETURNS DECIMAL
        AS
        BEGIN
            DECLARE @TotalAmount DECIMAL;
            DECLARE @Days INT = DATEDIFF(DAY, @StartDate, @EndDate);
            DECLARE @DailyRate DECIMAL;
            SELECT @DailyRate = DailyRate FROM Unit WHERE UnitId = @UnitId;
            SET @TotalAmount = @DailyRate * @Days;
            RETURN @TotalAmount;
        END;
    ");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP FUNCTION dbo.CalculateTotalAmount;");
        }
    }
}