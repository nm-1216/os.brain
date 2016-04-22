using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Metadata;

namespace os.brain.Migrations
{
    public partial class LoginLogs25 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_IdentityRoleClaim<string>_Role_RoleId", table: "AspNetRoleClaims");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserClaim<string>_User_UserId", table: "AspNetUserClaims");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserLogin<string>_User_UserId", table: "AspNetUserLogins");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserRole<string>_Role_RoleId", table: "AspNetUserRoles");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserRole<string>_User_UserId", table: "AspNetUserRoles");
            migrationBuilder.DropForeignKey(name: "FK_Action<string>_Path<string>_PathId", table: "AspNetActions");
            migrationBuilder.DropForeignKey(name: "FK_ActionInRole<string>_Action<string>_ActionId", table: "AspNetActionRoles");
            migrationBuilder.DropForeignKey(name: "FK_ActionInRole<string>_Role_RoleId", table: "AspNetActionRoles");
            migrationBuilder.DropForeignKey(name: "FK_GroupInRole<string>_Group<string>_GroupId", table: "AspNetGroupInRoles");
            migrationBuilder.DropForeignKey(name: "FK_GroupInRole<string>_Role_RoleId", table: "AspNetGroupInRoles");
            migrationBuilder.DropForeignKey(name: "FK_LoginLog<string>_User_UserId", table: "AspNetLoginLogs");
            migrationBuilder.DropForeignKey(name: "FK_Path<string>_Application_ApplicationId", table: "AspNetPaths");
            migrationBuilder.DropForeignKey(name: "FK_PathInRole<string>_Path<string>_PathId", table: "AspNetPathRoles");
            migrationBuilder.DropForeignKey(name: "FK_PathInRole<string>_Role_RoleId", table: "AspNetPathRoles");
            migrationBuilder.DropForeignKey(name: "FK_PathRestrition<string>_Path<string>_PathId", table: "AspNetPathRestritions");
            migrationBuilder.DropForeignKey(name: "FK_PersonalizationPerUser<string>_Path<string>_PathId", table: "AspNetPersonalizationPerUser");
            migrationBuilder.DropForeignKey(name: "FK_PersonalizationPerUser<string>_User_UserId", table: "AspNetPersonalizationPerUser");
            migrationBuilder.DropForeignKey(name: "FK_RoleRestrition<string>_Role_RoleId", table: "AspNetRoleRestritions");
            migrationBuilder.DropForeignKey(name: "FK_UserInGroup<string>_Group<string>_GroupId", table: "AspNetUserGroups");
            migrationBuilder.DropForeignKey(name: "FK_UserInGroup<string>_User_UserId", table: "AspNetUserGroups");
            migrationBuilder.DropTable("WmsFiles");
            //migrationBuilder.DropTable("WmsTrayInBinLocations");
            //migrationBuilder.DropTable("WmsBinLocations");
            migrationBuilder.DropTable("WmsTrays");
            migrationBuilder.DropTable("WmsTrayTypes");
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityRoleClaim<string>_Role_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserClaim<string>_User_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserLogin<string>_User_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserRole<string>_Role_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserRole<string>_User_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_Action<string>_Path<string>_PathId",
                table: "AspNetActions",
                column: "PathId",
                principalTable: "AspNetPaths",
                principalColumn: "PathId",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_ActionInRole<string>_Action<string>_ActionId",
                table: "AspNetActionRoles",
                column: "ActionId",
                principalTable: "AspNetActions",
                principalColumn: "ActionId",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_ActionInRole<string>_Role_RoleId",
                table: "AspNetActionRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_GroupInRole<string>_Group<string>_GroupId",
                table: "AspNetGroupInRoles",
                column: "GroupId",
                principalTable: "AspNetGroups",
                principalColumn: "GroupId",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_GroupInRole<string>_Role_RoleId",
                table: "AspNetGroupInRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_LoginLog<string>_User_UserId",
                table: "AspNetLoginLogs",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_Path<string>_Application_ApplicationId",
                table: "AspNetPaths",
                column: "ApplicationId",
                principalTable: "AspNetApplications",
                principalColumn: "ApplicationId",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_PathInRole<string>_Path<string>_PathId",
                table: "AspNetPathRoles",
                column: "PathId",
                principalTable: "AspNetPaths",
                principalColumn: "PathId",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_PathInRole<string>_Role_RoleId",
                table: "AspNetPathRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_PathRestrition<string>_Path<string>_PathId",
                table: "AspNetPathRestritions",
                column: "PathId",
                principalTable: "AspNetPaths",
                principalColumn: "PathId",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_PersonalizationPerUser<string>_Path<string>_PathId",
                table: "AspNetPersonalizationPerUser",
                column: "PathId",
                principalTable: "AspNetPaths",
                principalColumn: "PathId",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_PersonalizationPerUser<string>_User_UserId",
                table: "AspNetPersonalizationPerUser",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_RoleRestrition<string>_Role_RoleId",
                table: "AspNetRoleRestritions",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_UserInGroup<string>_Group<string>_GroupId",
                table: "AspNetUserGroups",
                column: "GroupId",
                principalTable: "AspNetGroups",
                principalColumn: "GroupId",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_UserInGroup<string>_User_UserId",
                table: "AspNetUserGroups",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_IdentityRoleClaim<string>_Role_RoleId", table: "AspNetRoleClaims");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserClaim<string>_User_UserId", table: "AspNetUserClaims");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserLogin<string>_User_UserId", table: "AspNetUserLogins");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserRole<string>_Role_RoleId", table: "AspNetUserRoles");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserRole<string>_User_UserId", table: "AspNetUserRoles");
            migrationBuilder.DropForeignKey(name: "FK_Action<string>_Path<string>_PathId", table: "AspNetActions");
            migrationBuilder.DropForeignKey(name: "FK_ActionInRole<string>_Action<string>_ActionId", table: "AspNetActionRoles");
            migrationBuilder.DropForeignKey(name: "FK_ActionInRole<string>_Role_RoleId", table: "AspNetActionRoles");
            migrationBuilder.DropForeignKey(name: "FK_GroupInRole<string>_Group<string>_GroupId", table: "AspNetGroupInRoles");
            migrationBuilder.DropForeignKey(name: "FK_GroupInRole<string>_Role_RoleId", table: "AspNetGroupInRoles");
            migrationBuilder.DropForeignKey(name: "FK_LoginLog<string>_User_UserId", table: "AspNetLoginLogs");
            migrationBuilder.DropForeignKey(name: "FK_Path<string>_Application_ApplicationId", table: "AspNetPaths");
            migrationBuilder.DropForeignKey(name: "FK_PathInRole<string>_Path<string>_PathId", table: "AspNetPathRoles");
            migrationBuilder.DropForeignKey(name: "FK_PathInRole<string>_Role_RoleId", table: "AspNetPathRoles");
            migrationBuilder.DropForeignKey(name: "FK_PathRestrition<string>_Path<string>_PathId", table: "AspNetPathRestritions");
            migrationBuilder.DropForeignKey(name: "FK_PersonalizationPerUser<string>_Path<string>_PathId", table: "AspNetPersonalizationPerUser");
            migrationBuilder.DropForeignKey(name: "FK_PersonalizationPerUser<string>_User_UserId", table: "AspNetPersonalizationPerUser");
            migrationBuilder.DropForeignKey(name: "FK_RoleRestrition<string>_Role_RoleId", table: "AspNetRoleRestritions");
            migrationBuilder.DropForeignKey(name: "FK_UserInGroup<string>_Group<string>_GroupId", table: "AspNetUserGroups");
            migrationBuilder.DropForeignKey(name: "FK_UserInGroup<string>_User_UserId", table: "AspNetUserGroups");
            migrationBuilder.CreateTable(
                name: "WmsBinLocations",
                columns: table => new
                {
                    BinLocationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddTime = table.Column<DateTime>(nullable: false),
                    AddUser = table.Column<string>(nullable: false),
                    Discription = table.Column<string>(nullable: false),
                    ModifyTime = table.Column<DateTime>(nullable: false),
                    ModifyUser = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    R = table.Column<string>(nullable: false),
                    Type = table.Column<string>(nullable: false),
                    X = table.Column<int>(nullable: false),
                    Y = table.Column<int>(nullable: false),
                    Z = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BinLocation", x => x.BinLocationId);
                });
            migrationBuilder.CreateTable(
                name: "WmsFiles",
                columns: table => new
                {
                    FileId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddTime = table.Column<DateTime>(nullable: false),
                    AddUser = table.Column<string>(nullable: false),
                    Content = table.Column<byte[]>(type: "Image", nullable: true),
                    FileExtensions = table.Column<string>(nullable: false),
                    FileName = table.Column<string>(nullable: false),
                    FileType = table.Column<string>(nullable: false),
                    ModifyTime = table.Column<DateTime>(nullable: false),
                    ModifyUser = table.Column<string>(nullable: false),
                    Thumbnail = table.Column<byte[]>(type: "Image", nullable: true),
                    ThumbnailUrl = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_File", x => x.FileId);
                });
            migrationBuilder.CreateTable(
                name: "WmsTrayTypes",
                columns: table => new
                {
                    TrayTypeId = table.Column<string>(nullable: false),
                    AddTime = table.Column<DateTime>(nullable: false),
                    AddUser = table.Column<string>(nullable: false),
                    Discription = table.Column<string>(nullable: false),
                    Image = table.Column<byte[]>(type: "Image", nullable: true),
                    ModifyTime = table.Column<DateTime>(nullable: false),
                    ModifyUser = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Size = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrayType", x => x.TrayTypeId);
                });
            migrationBuilder.CreateTable(
                name: "WmsTrays",
                columns: table => new
                {
                    TrayId = table.Column<string>(nullable: false),
                    AddTime = table.Column<DateTime>(nullable: false),
                    AddUser = table.Column<string>(nullable: false),
                    IsFull = table.Column<bool>(nullable: false),
                    ModifyTime = table.Column<DateTime>(nullable: false),
                    ModifyUser = table.Column<string>(nullable: false),
                    TrayTypeId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tray", x => x.TrayId);
                    table.ForeignKey(
                        name: "FK_Tray_TrayType_TrayTypeId",
                        column: x => x.TrayTypeId,
                        principalTable: "WmsTrayTypes",
                        principalColumn: "TrayTypeId",
                        onDelete: ReferentialAction.Restrict);
                });
            //migrationBuilder.CreateTable(
            //    name: "WmsTrayInBinLocations",
            //    columns: table => new
            //    {
            //        TrayId = table.Column<string>(nullable: false),
            //        AddTime = table.Column<DateTime>(nullable: false),
            //        AddUser = table.Column<string>(nullable: false),
            //        BinLocationId = table.Column<int>(nullable: false),
            //        ModifyTime = table.Column<DateTime>(nullable: false),
            //        ModifyUser = table.Column<string>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_TrayInBinLocation", x => x.TrayId);
            //        table.ForeignKey(
            //            name: "FK_TrayInBinLocation_BinLocation_BinLocationId",
            //            column: x => x.BinLocationId,
            //            principalTable: "WmsBinLocations",
            //            principalColumn: "BinLocationId",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_TrayInBinLocation_Tray_TrayId",
            //            column: x => x.TrayId,
            //            principalTable: "WmsTrays",
            //            principalColumn: "TrayId",
            //            onDelete: ReferentialAction.Restrict);
            //    });
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityRoleClaim<string>_Role_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserClaim<string>_User_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserLogin<string>_User_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserRole<string>_Role_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserRole<string>_User_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_Action<string>_Path<string>_PathId",
                table: "AspNetActions",
                column: "PathId",
                principalTable: "AspNetPaths",
                principalColumn: "PathId",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_ActionInRole<string>_Action<string>_ActionId",
                table: "AspNetActionRoles",
                column: "ActionId",
                principalTable: "AspNetActions",
                principalColumn: "ActionId",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_ActionInRole<string>_Role_RoleId",
                table: "AspNetActionRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_GroupInRole<string>_Group<string>_GroupId",
                table: "AspNetGroupInRoles",
                column: "GroupId",
                principalTable: "AspNetGroups",
                principalColumn: "GroupId",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_GroupInRole<string>_Role_RoleId",
                table: "AspNetGroupInRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_LoginLog<string>_User_UserId",
                table: "AspNetLoginLogs",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_Path<string>_Application_ApplicationId",
                table: "AspNetPaths",
                column: "ApplicationId",
                principalTable: "AspNetApplications",
                principalColumn: "ApplicationId",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_PathInRole<string>_Path<string>_PathId",
                table: "AspNetPathRoles",
                column: "PathId",
                principalTable: "AspNetPaths",
                principalColumn: "PathId",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_PathInRole<string>_Role_RoleId",
                table: "AspNetPathRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_PathRestrition<string>_Path<string>_PathId",
                table: "AspNetPathRestritions",
                column: "PathId",
                principalTable: "AspNetPaths",
                principalColumn: "PathId",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_PersonalizationPerUser<string>_Path<string>_PathId",
                table: "AspNetPersonalizationPerUser",
                column: "PathId",
                principalTable: "AspNetPaths",
                principalColumn: "PathId",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_PersonalizationPerUser<string>_User_UserId",
                table: "AspNetPersonalizationPerUser",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_RoleRestrition<string>_Role_RoleId",
                table: "AspNetRoleRestritions",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_UserInGroup<string>_Group<string>_GroupId",
                table: "AspNetUserGroups",
                column: "GroupId",
                principalTable: "AspNetGroups",
                principalColumn: "GroupId",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_UserInGroup<string>_User_UserId",
                table: "AspNetUserGroups",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
