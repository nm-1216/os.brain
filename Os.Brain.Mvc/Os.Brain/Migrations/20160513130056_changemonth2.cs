using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace os.brain.Migrations
{
    public partial class changemonth2 : Migration
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
            migrationBuilder.DropForeignKey(name: "FK_WaterMeter_WaterUser_Wu_id", table: "WaterMeters");
            migrationBuilder.DropForeignKey(name: "FK_WaterPrices_PricesType_ids", table: "WaterPrices");
            migrationBuilder.DropForeignKey(name: "FK_Tray_TrayType_TrayTypeId", table: "WmsTrays");
            migrationBuilder.DropForeignKey(name: "FK_TrayInBinLocation_BinLocation_BinLocationId", table: "WmsTrayInBinLocations");
            migrationBuilder.DropForeignKey(name: "FK_TrayInBinLocation_Tray_TrayId", table: "WmsTrayInBinLocations");
            migrationBuilder.CreateTable(
                name: "WaterValues",
                columns: table => new
                {
                    Wm_IdCard = table.Column<string>(nullable: false),
                    Wv_Year = table.Column<int>(nullable: false),
                    Wv_Month = table.Column<int>(nullable: false),
                    Wv_AddTime = table.Column<DateTime>(nullable: false),
                    Wv_AddUser = table.Column<string>(nullable: false),
                    Wv_DoTime = table.Column<DateTime>(nullable: false),
                    Wv_End = table.Column<int>(nullable: false),
                    Wv_ExChange = table.Column<int>(nullable: false),
                    Wv_OldEnd = table.Column<int>(nullable: false),
                    Wv_OldStart = table.Column<int>(nullable: false),
                    Wv_Price = table.Column<double>(nullable: false),
                    Wv_Prints = table.Column<int>(nullable: false),
                    Wv_ReadTime = table.Column<DateTime>(nullable: false),
                    Wv_Start = table.Column<int>(nullable: false),
                    Wv_Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WaterValue", x => new { x.Wm_IdCard, x.Wv_Year, x.Wv_Month });
                });
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
            migrationBuilder.AddForeignKey(
                name: "FK_WaterMeter_WaterUser_Wu_id",
                table: "WaterMeters",
                column: "Wu_id",
                principalTable: "WaterUsers",
                principalColumn: "Wu_id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_WaterPrices_PricesType_ids",
                table: "WaterPrices",
                column: "ids",
                principalTable: "WaterPricesTypes",
                principalColumn: "ids",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_Tray_TrayType_TrayTypeId",
                table: "WmsTrays",
                column: "TrayTypeId",
                principalTable: "WmsTrayTypes",
                principalColumn: "TrayTypeId",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_TrayInBinLocation_BinLocation_BinLocationId",
                table: "WmsTrayInBinLocations",
                column: "BinLocationId",
                principalTable: "WmsBinLocations",
                principalColumn: "BinLocationId",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_TrayInBinLocation_Tray_TrayId",
                table: "WmsTrayInBinLocations",
                column: "TrayId",
                principalTable: "WmsTrays",
                principalColumn: "TrayId",
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
            migrationBuilder.DropForeignKey(name: "FK_WaterMeter_WaterUser_Wu_id", table: "WaterMeters");
            migrationBuilder.DropForeignKey(name: "FK_WaterPrices_PricesType_ids", table: "WaterPrices");
            migrationBuilder.DropForeignKey(name: "FK_Tray_TrayType_TrayTypeId", table: "WmsTrays");
            migrationBuilder.DropForeignKey(name: "FK_TrayInBinLocation_BinLocation_BinLocationId", table: "WmsTrayInBinLocations");
            migrationBuilder.DropForeignKey(name: "FK_TrayInBinLocation_Tray_TrayId", table: "WmsTrayInBinLocations");
            migrationBuilder.DropTable("WaterValues");
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
            migrationBuilder.AddForeignKey(
                name: "FK_WaterMeter_WaterUser_Wu_id",
                table: "WaterMeters",
                column: "Wu_id",
                principalTable: "WaterUsers",
                principalColumn: "Wu_id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_WaterPrices_PricesType_ids",
                table: "WaterPrices",
                column: "ids",
                principalTable: "WaterPricesTypes",
                principalColumn: "ids",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_Tray_TrayType_TrayTypeId",
                table: "WmsTrays",
                column: "TrayTypeId",
                principalTable: "WmsTrayTypes",
                principalColumn: "TrayTypeId",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_TrayInBinLocation_BinLocation_BinLocationId",
                table: "WmsTrayInBinLocations",
                column: "BinLocationId",
                principalTable: "WmsBinLocations",
                principalColumn: "BinLocationId",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_TrayInBinLocation_Tray_TrayId",
                table: "WmsTrayInBinLocations",
                column: "TrayId",
                principalTable: "WmsTrays",
                principalColumn: "TrayId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
