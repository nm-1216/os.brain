using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using Os.Brain.Models;

namespace os.brain.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20160516150201_abc5")]
    partial class abc5
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:TableName", "AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:TableName", "AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasAnnotation("Relational:TableName", "AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasAnnotation("Relational:TableName", "AspNetUserRoles");
                });

            modelBuilder.Entity("Os.Brain.Models.Action<string>", b =>
                {
                    b.Property<string>("ActionId");

                    b.Property<string>("ActionName");

                    b.Property<string>("Description");

                    b.Property<string>("PathId")
                        .IsRequired();

                    b.HasKey("ActionId");

                    b.HasAnnotation("Relational:TableName", "AspNetActions");
                });

            modelBuilder.Entity("Os.Brain.Models.ActionInRole<string>", b =>
                {
                    b.Property<string>("RoleId");

                    b.Property<string>("ActionId");

                    b.HasKey("RoleId", "ActionId");

                    b.HasAnnotation("Relational:TableName", "AspNetActionRoles");
                });

            modelBuilder.Entity("Os.Brain.Models.Application", b =>
                {
                    b.Property<string>("ApplicationId");

                    b.Property<string>("ApplicationName")
                        .IsRequired();

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<int>("OrderBy");

                    b.HasKey("ApplicationId");

                    b.HasAnnotation("Relational:TableName", "AspNetApplications");
                });

            modelBuilder.Entity("Os.Brain.Models.CMS.Cms_News", b =>
                {
                    b.Property<int>("News_ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("News_AddDate")
                        .IsRequired();

                    b.Property<string>("News_AddUser")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.Property<string>("News_Author");

                    b.Property<int?>("News_Catalog")
                        .IsRequired();

                    b.Property<string>("News_Color");

                    b.Property<DateTime?>("News_EditDate")
                        .IsRequired();

                    b.Property<string>("News_EditUser")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.Property<string>("News_Field1");

                    b.Property<string>("News_Field10");

                    b.Property<string>("News_Field2");

                    b.Property<string>("News_Field3");

                    b.Property<string>("News_Field4");

                    b.Property<string>("News_Field5");

                    b.Property<string>("News_Field6");

                    b.Property<string>("News_Field7");

                    b.Property<string>("News_Field8");

                    b.Property<string>("News_Field9");

                    b.Property<string>("News_From")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 32);

                    b.Property<int?>("News_Hits")
                        .IsRequired();

                    b.Property<string>("News_IP");

                    b.Property<string>("News_Ico");

                    b.Property<string>("News_Img");

                    b.Property<string>("News_Keywords")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 128);

                    b.Property<string>("News_Link");

                    b.Property<string>("News_Property");

                    b.Property<string>("News_Subtitle")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 32);

                    b.Property<string>("News_Summary")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("News_Text")
                        .IsRequired()
                        .HasAnnotation("Relational:ColumnType", "Text");

                    b.Property<string>("News_Title")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.Property<int?>("News_isAuth")
                        .IsRequired();

                    b.Property<bool?>("News_isDel")
                        .IsRequired();

                    b.HasKey("News_ID");

                    b.HasAnnotation("Relational:TableName", "CmsNews");
                });

            modelBuilder.Entity("Os.Brain.Models.ErrorLog", b =>
                {
                    b.Property<int>("LogID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<string>("Exception")
                        .HasAnnotation("MaxLength", 4000);

                    b.Property<string>("Level")
                        .HasAnnotation("MaxLength", 128);

                    b.Property<string>("Logger")
                        .HasAnnotation("MaxLength", 512);

                    b.Property<string>("Message")
                        .HasAnnotation("MaxLength", 4000);

                    b.Property<string>("Thread")
                        .HasAnnotation("MaxLength", 128);

                    b.HasKey("LogID");

                    b.HasAnnotation("Relational:TableName", "AspNetErrorLogs");
                });

            modelBuilder.Entity("Os.Brain.Models.EventLog", b =>
                {
                    b.Property<int>("LogID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<string>("Exception")
                        .HasAnnotation("MaxLength", 4000);

                    b.Property<string>("Level")
                        .HasAnnotation("MaxLength", 128);

                    b.Property<string>("Logger")
                        .HasAnnotation("MaxLength", 512);

                    b.Property<string>("Message")
                        .HasAnnotation("MaxLength", 4000);

                    b.Property<string>("Thread")
                        .HasAnnotation("MaxLength", 128);

                    b.HasKey("LogID");

                    b.HasAnnotation("Relational:TableName", "AspNetEventLogs");
                });

            modelBuilder.Entity("Os.Brain.Models.Group<string>", b =>
                {
                    b.Property<string>("GroupId");

                    b.Property<string>("Description");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("GroupName");

                    b.Property<string>("ParentId");

                    b.HasKey("GroupId");

                    b.HasAnnotation("Relational:DiscriminatorProperty", "Discriminator");

                    b.HasAnnotation("Relational:DiscriminatorValue", "Group<string>");

                    b.HasAnnotation("Relational:TableName", "AspNetGroups");
                });

            modelBuilder.Entity("Os.Brain.Models.GroupInRole<string>", b =>
                {
                    b.Property<string>("GroupId");

                    b.Property<string>("RoleId");

                    b.HasKey("GroupId", "RoleId");

                    b.HasAnnotation("Relational:TableName", "AspNetGroupInRoles");
                });

            modelBuilder.Entity("Os.Brain.Models.LoginLog<string>", b =>
                {
                    b.Property<string>("Id");

                    b.Property<DateTime>("AddTime");

                    b.Property<string>("Description");

                    b.Property<string>("IP")
                        .HasAnnotation("MaxLength", 64);

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:TableName", "AspNetLoginLogs");
                });

            modelBuilder.Entity("Os.Brain.Models.Path<string>", b =>
                {
                    b.Property<string>("PathId");

                    b.Property<string>("ApplicationId")
                        .IsRequired();

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("ParentId");

                    b.Property<string>("PathCategory");

                    b.Property<string>("PathName");

                    b.Property<string>("_Path")
                        .HasAnnotation("Relational:ColumnName", "Path");

                    b.HasKey("PathId");

                    b.HasAnnotation("Relational:DiscriminatorProperty", "Discriminator");

                    b.HasAnnotation("Relational:DiscriminatorValue", "Path<string>");

                    b.HasAnnotation("Relational:TableName", "AspNetPaths");
                });

            modelBuilder.Entity("Os.Brain.Models.PathInRole<string>", b =>
                {
                    b.Property<string>("PathId");

                    b.Property<string>("RoleId");

                    b.HasKey("PathId", "RoleId");

                    b.HasAnnotation("Relational:TableName", "AspNetPathRoles");
                });

            modelBuilder.Entity("Os.Brain.Models.PathRestrition<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ACLType");

                    b.Property<string>("PathId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:TableName", "AspNetPathRestritions");
                });

            modelBuilder.Entity("Os.Brain.Models.PersonalizationPerUser<string>", b =>
                {
                    b.Property<string>("PathId");

                    b.Property<string>("UserId");

                    b.Property<bool>("IsAllow");

                    b.HasKey("PathId", "UserId");

                    b.HasAnnotation("Relational:TableName", "AspNetPersonalizationPerUser");
                });

            modelBuilder.Entity("Os.Brain.Models.PricesType", b =>
                {
                    b.Property<int>("ids")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("addTime");

                    b.Property<bool>("isUse");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 128);

                    b.HasKey("ids");

                    b.HasAnnotation("Relational:TableName", "WaterPricesTypes");
                });

            modelBuilder.Entity("Os.Brain.Models.Role", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .HasAnnotation("Relational:Name", "RoleNameIndex");

                    b.HasAnnotation("Relational:TableName", "AspNetRoles");
                });

            modelBuilder.Entity("Os.Brain.Models.RoleRestrition<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ACLType");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:TableName", "AspNetRoleRestritions");
                });

            modelBuilder.Entity("Os.Brain.Models.User", b =>
                {
                    b.Property<string>("Id");

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("Cname")
                        .HasAnnotation("MaxLength", 64);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("DOB")
                        .HasAnnotation("MaxLength", 16);

                    b.Property<string>("Description")
                        .HasAnnotation("MaxLength", 128);

                    b.Property<string>("Email")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("Ename")
                        .HasAnnotation("MaxLength", 64);

                    b.Property<string>("Ext")
                        .HasAnnotation("MaxLength", 10);

                    b.Property<string>("Group")
                        .HasAnnotation("MaxLength", 128);

                    b.Property<DateTime>("HireDate");

                    b.Property<string>("IDCard")
                        .HasAnnotation("MaxLength", 64);

                    b.Property<string>("LockIp")
                        .HasAnnotation("MaxLength", 128);

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("Mobile")
                        .HasAnnotation("MaxLength", 16);

                    b.Property<string>("NO")
                        .HasAnnotation("MaxLength", 32);

                    b.Property<string>("NormalizedEmail")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedUserName")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<int>("PageSize");

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<byte[]>("Photo");

                    b.Property<string>("ProfessionalTitle")
                        .HasAnnotation("MaxLength", 128);

                    b.Property<DateTime>("ResignationDate");

                    b.Property<string>("SecurityStamp");

                    b.Property<int>("Sex");

                    b.Property<string>("Tel")
                        .HasAnnotation("MaxLength", 16);

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<int>("UserType");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasAnnotation("Relational:Name", "EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .HasAnnotation("Relational:Name", "UserNameIndex");

                    b.HasAnnotation("Relational:TableName", "AspNetUsers");
                });

            modelBuilder.Entity("Os.Brain.Models.UserInGroup<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("GroupId");

                    b.HasKey("UserId", "GroupId");

                    b.HasAnnotation("Relational:TableName", "AspNetUserGroups");
                });

            modelBuilder.Entity("Os.Brain.Models.WaterMeter", b =>
                {
                    b.Property<string>("Wm_IdCard")
                        .HasAnnotation("MaxLength", 32);

                    b.Property<string>("Wm_LogName")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.Property<string>("Wm_Pwd")
                        .IsRequired();

                    b.Property<string>("Wm_Tel")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.Property<string>("Wm_Weixin")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 128);

                    b.Property<int>("Wu_id");

                    b.Property<bool>("isGroup");

                    b.Property<bool>("isNeedPay");

                    b.HasKey("Wm_IdCard");

                    b.HasAnnotation("Relational:TableName", "WaterMeters");
                });

            modelBuilder.Entity("Os.Brain.Models.WaterPrices", b =>
                {
                    b.Property<int>("Prices_Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Prices_AddTime");

                    b.Property<int>("Prices_End");

                    b.Property<int>("Prices_Start");

                    b.Property<double>("Prices_Value");

                    b.Property<int>("ids");

                    b.HasKey("Prices_Id");

                    b.HasAnnotation("Relational:TableName", "WaterPrices");
                });

            modelBuilder.Entity("Os.Brain.Models.WaterUser", b =>
                {
                    b.Property<int>("Wu_id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Wu_Address")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 128);

                    b.Property<string>("Wu_Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.Property<string>("Wu_Tel")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.Property<string>("Wu_Village")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 128);

                    b.Property<string>("temp");

                    b.HasKey("Wu_id");

                    b.HasAnnotation("Relational:TableName", "WaterUsers");
                });

            modelBuilder.Entity("Os.Brain.Models.WMS.BinLocation", b =>
                {
                    b.Property<int>("BinLocationId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("AddTime");

                    b.Property<string>("AddUser")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.Property<string>("Discription")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 256);

                    b.Property<DateTime>("ModifyTime");

                    b.Property<string>("ModifyUser")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.Property<string>("R")
                        .IsRequired();

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 32);

                    b.Property<int>("X");

                    b.Property<int>("Y");

                    b.Property<int>("Z");

                    b.HasKey("BinLocationId");

                    b.HasAnnotation("Relational:TableName", "WmsBinLocations");
                });

            modelBuilder.Entity("Os.Brain.Models.WMS.File", b =>
                {
                    b.Property<int>("FileId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("AddTime");

                    b.Property<string>("AddUser")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.Property<byte[]>("Content")
                        .HasAnnotation("Relational:ColumnType", "Image");

                    b.Property<string>("FileExtensions")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 128);

                    b.Property<string>("FileType")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.Property<DateTime>("ModifyTime");

                    b.Property<string>("ModifyUser")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.Property<byte[]>("Thumbnail")
                        .HasAnnotation("Relational:ColumnType", "Image");

                    b.Property<string>("ThumbnailUrl")
                        .HasAnnotation("MaxLength", 64);

                    b.Property<string>("Url")
                        .HasAnnotation("MaxLength", 64);

                    b.HasKey("FileId");

                    b.HasAnnotation("Relational:TableName", "WmsFiles");
                });

            modelBuilder.Entity("Os.Brain.Models.WMS.Tray", b =>
                {
                    b.Property<string>("TrayId");

                    b.Property<DateTime>("AddTime");

                    b.Property<string>("AddUser")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.Property<bool>("IsFull");

                    b.Property<DateTime>("ModifyTime");

                    b.Property<string>("ModifyUser")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.Property<string>("TrayTypeId")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 16);

                    b.HasKey("TrayId");

                    b.HasAnnotation("Relational:TableName", "WmsTrays");
                });

            modelBuilder.Entity("Os.Brain.Models.WMS.TrayInBinLocation", b =>
                {
                    b.Property<string>("TrayId");

                    b.Property<DateTime>("AddTime");

                    b.Property<string>("AddUser")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.Property<int>("BinLocationId");

                    b.Property<DateTime>("ModifyTime");

                    b.Property<string>("ModifyUser")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.HasKey("TrayId");

                    b.HasAnnotation("Relational:TableName", "WmsTrayInBinLocations");
                });

            modelBuilder.Entity("Os.Brain.Models.WMS.TrayType", b =>
                {
                    b.Property<string>("TrayTypeId")
                        .HasAnnotation("MaxLength", 16);

                    b.Property<DateTime>("AddTime");

                    b.Property<string>("AddUser")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.Property<string>("Discription")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 256);

                    b.Property<byte[]>("Image")
                        .HasAnnotation("Relational:ColumnType", "Image");

                    b.Property<DateTime>("ModifyTime");

                    b.Property<string>("ModifyUser")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.Property<string>("Size")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.HasKey("TrayTypeId");

                    b.HasAnnotation("Relational:TableName", "WmsTrayTypes");
                });

            modelBuilder.Entity("Os.Brain.Models.Group", b =>
                {
                    b.HasBaseType("Os.Brain.Models.Group<string>");


                    b.HasAnnotation("Relational:DiscriminatorValue", "Group");
                });

            modelBuilder.Entity("Os.Brain.Models.Path", b =>
                {
                    b.HasBaseType("Os.Brain.Models.Path<string>");


                    b.HasAnnotation("Relational:DiscriminatorValue", "Path");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Os.Brain.Models.Role")
                        .WithMany()
                        .HasForeignKey("RoleId");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Os.Brain.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Os.Brain.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Os.Brain.Models.Role")
                        .WithMany()
                        .HasForeignKey("RoleId");

                    b.HasOne("Os.Brain.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Os.Brain.Models.Action<string>", b =>
                {
                    b.HasOne("Os.Brain.Models.Path<string>")
                        .WithMany()
                        .HasForeignKey("PathId");
                });

            modelBuilder.Entity("Os.Brain.Models.ActionInRole<string>", b =>
                {
                    b.HasOne("Os.Brain.Models.Action<string>")
                        .WithMany()
                        .HasForeignKey("ActionId");

                    b.HasOne("Os.Brain.Models.Role")
                        .WithMany()
                        .HasForeignKey("RoleId");
                });

            modelBuilder.Entity("Os.Brain.Models.Group<string>", b =>
                {
                    b.HasOne("Os.Brain.Models.Group<string>")
                        .WithMany()
                        .HasForeignKey("ParentId");
                });

            modelBuilder.Entity("Os.Brain.Models.GroupInRole<string>", b =>
                {
                    b.HasOne("Os.Brain.Models.Group<string>")
                        .WithMany()
                        .HasForeignKey("GroupId");

                    b.HasOne("Os.Brain.Models.Role")
                        .WithMany()
                        .HasForeignKey("RoleId");
                });

            modelBuilder.Entity("Os.Brain.Models.LoginLog<string>", b =>
                {
                    b.HasOne("Os.Brain.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Os.Brain.Models.Path<string>", b =>
                {
                    b.HasOne("Os.Brain.Models.Application")
                        .WithMany()
                        .HasForeignKey("ApplicationId");

                    b.HasOne("Os.Brain.Models.Path<string>")
                        .WithMany()
                        .HasForeignKey("ParentId");
                });

            modelBuilder.Entity("Os.Brain.Models.PathInRole<string>", b =>
                {
                    b.HasOne("Os.Brain.Models.Path<string>")
                        .WithMany()
                        .HasForeignKey("PathId");

                    b.HasOne("Os.Brain.Models.Role")
                        .WithMany()
                        .HasForeignKey("RoleId");
                });

            modelBuilder.Entity("Os.Brain.Models.PathRestrition<string>", b =>
                {
                    b.HasOne("Os.Brain.Models.Path<string>")
                        .WithMany()
                        .HasForeignKey("PathId");
                });

            modelBuilder.Entity("Os.Brain.Models.PersonalizationPerUser<string>", b =>
                {
                    b.HasOne("Os.Brain.Models.Path<string>")
                        .WithMany()
                        .HasForeignKey("PathId");

                    b.HasOne("Os.Brain.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Os.Brain.Models.RoleRestrition<string>", b =>
                {
                    b.HasOne("Os.Brain.Models.Role")
                        .WithMany()
                        .HasForeignKey("RoleId");
                });

            modelBuilder.Entity("Os.Brain.Models.UserInGroup<string>", b =>
                {
                    b.HasOne("Os.Brain.Models.Group<string>")
                        .WithMany()
                        .HasForeignKey("GroupId");

                    b.HasOne("Os.Brain.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Os.Brain.Models.WaterMeter", b =>
                {
                    b.HasOne("Os.Brain.Models.WaterUser")
                        .WithMany()
                        .HasForeignKey("Wu_id");
                });

            modelBuilder.Entity("Os.Brain.Models.WaterPrices", b =>
                {
                    b.HasOne("Os.Brain.Models.PricesType")
                        .WithMany()
                        .HasForeignKey("ids");
                });

            modelBuilder.Entity("Os.Brain.Models.WMS.Tray", b =>
                {
                    b.HasOne("Os.Brain.Models.WMS.TrayType")
                        .WithMany()
                        .HasForeignKey("TrayTypeId");
                });

            modelBuilder.Entity("Os.Brain.Models.WMS.TrayInBinLocation", b =>
                {
                    b.HasOne("Os.Brain.Models.WMS.BinLocation")
                        .WithMany()
                        .HasForeignKey("BinLocationId");

                    b.HasOne("Os.Brain.Models.WMS.Tray")
                        .WithMany()
                        .HasForeignKey("TrayId");
                });

            modelBuilder.Entity("Os.Brain.Models.Group", b =>
                {
                });

            modelBuilder.Entity("Os.Brain.Models.Path", b =>
                {
                });
        }
    }
}
