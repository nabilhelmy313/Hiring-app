﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class attachments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Attachments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Table_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Row_Id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    File_Type_Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    File_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MIME_Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    File_Length = table.Column<long>(type: "bigint", nullable: false),
                    File_Extension = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    File_Path = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Is_Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attachments", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attachments");
        }
    }
}
