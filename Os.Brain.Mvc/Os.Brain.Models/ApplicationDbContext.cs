
namespace Os.Brain.Models
{
    using System;
    using CMS;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.Data.Entity;
    using Microsoft.Data.Entity.Infrastructure;
    using TEST;
    using WMS;
    /// <summary>
    /// Base class for the Entity Framework database context used for identity.
    /// </summary>
    public class AppDbContext : AppDbContext<User, Role, string> { }

    /// <summary>
    /// Base class for the Entity Framework database context used for identity.
    /// </summary>
    /// <typeparam name="TUser">The type of the user objects.</typeparam>
    public class AppDbContext<TUser> : AppDbContext<TUser, Role, string> where TUser : User
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
    }

    public class AppDbContext<TUser, TRole, TKey> : IdentityDbContext<TUser, TRole, TKey>
        where TUser : User<TKey>
        where TRole : Role<TKey>
        where TKey : IEquatable<TKey>
    {
        #region 构造器
        /// <summary>
        /// Initializes a new instance of <see cref="IdentityDbContext"/>.
        /// </summary>
        /// <param name="options">The options to be used by a <see cref="DbContext"/>.</param>
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IdentityDbContext" /> class using an <see cref="IServiceProvider" />.
        /// </summary>
        /// <param name="serviceProvider"> The service provider to be used.</param>
        public AppDbContext(IServiceProvider serviceProvider) : base(serviceProvider)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IdentityDbContext" /> class using an <see cref="IServiceProvider" />.
        /// </summary>
        /// <param name="options">The options to be used by a <see cref="DbContext"/>.</param>
        /// <param name="serviceProvider"> The service provider to be used.</param>
        public AppDbContext(IServiceProvider serviceProvider, DbContextOptions options) : base(serviceProvider, options)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IdentityDbContext" /> class.
        /// </summary>
        protected AppDbContext()
        {

        }

        #endregion

        public DbSet<Group> Groups { get; set; }
        public DbSet<UserInGroup<TKey>> UserInGroups { get; set; }
        public DbSet<GroupInRole<TKey>> GroupInRoles { get; set; }
        public DbSet<Application> Applications { get; set; }
        public DbSet<Path<TKey>> Paths { get; set; }
        public DbSet<LoginLog<TKey>> LoginLogs { get; set; }
        public DbSet<EventLog> EventLogs { get; set; }

        #region DbSet 仓储
        //public DbSet<File1> Files { get; set; }
        //public DbSet<TrayType> TrayTypes { get; set; }
        //public DbSet<BinLocation> BinLocations { get; set; }
        //public DbSet<Tray> Trays { get; set; }
        //public DbSet<TrayInBinLocation> TrayInBinLocations { get; set; }
        #endregion

        #region DbSet CMS
        public DbSet<Cms_News> News { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder builder)
        {
            #region 基础模块

            #region 关系表

            builder.Entity<UserInGroup<TKey>>(b =>
            {
                b.HasKey(r => new { r.UserId, r.GroupId });
                b.ToTable("AspNetUserGroups");
            });

            builder.Entity<GroupInRole<TKey>>(b =>
            {
                b.HasKey(r => new { r.GroupId, r.RoleId });
                b.ToTable("AspNetGroupInRoles");
            });

            builder.Entity<PathInRole<TKey>>(b =>
            {
                b.HasKey(r => new { r.PathId, r.RoleId });
                b.ToTable("AspNetPathRoles");
            });

            builder.Entity<PersonalizationPerUser<TKey>>(b =>
            {
                b.HasKey(r => new { r.PathId, r.UserId });
                b.ToTable("AspNetPersonalizationPerUser");
            });

            builder.Entity<ActionInRole<TKey>>(b =>
            {
                b.HasKey(r => new { r.RoleId, r.ActionId });
                b.ToTable("AspNetActionRoles");
            });

            #endregion

            #region Models

            builder.Entity<TUser>(b =>
            {
                b.HasMany(u => u.Groups).WithOne().HasForeignKey(ur => ur.UserId).IsRequired();
                b.HasMany(u => u.Paths).WithOne().HasForeignKey(ur => ur.UserId).IsRequired();
                b.HasMany(u => u.LoginLogs).WithOne().HasForeignKey(ur => ur.UserId).IsRequired();
            });

            builder.Entity<TRole>(b =>
            {
                b.HasMany(u => u.Groups).WithOne().HasForeignKey(ur => ur.RoleId).IsRequired();
                b.HasMany(u => u.Paths).WithOne().HasForeignKey(ur => ur.RoleId).IsRequired();
                b.HasMany(u => u.Actions).WithOne().HasForeignKey(ur => ur.RoleId).IsRequired();
                b.HasMany(u => u.RoleRestritions).WithOne().HasForeignKey(ur => ur.RoleId).IsRequired();
            });

            builder.Entity<Group<TKey>>(b =>
            {
                b.HasKey(r => r.GroupId);
                b.ToTable("AspNetGroups");
                b.HasMany(u => u.Users).WithOne().HasForeignKey(ur => ur.GroupId).IsRequired();
                b.HasMany(u => u.Roles).WithOne().HasForeignKey(ur => ur.GroupId).IsRequired();
            });

            builder.Entity<Path<TKey>>(b =>
            {
                b.HasKey(r => r.PathId);
                b.ToTable("AspNetPaths");
                b.HasMany(u => u.Roles).WithOne().HasForeignKey(ur => ur.PathId).IsRequired();
                b.HasMany(u => u.Users).WithOne().HasForeignKey(ur => ur.PathId).IsRequired();
                b.HasMany(u => u.Actions).WithOne().HasForeignKey(ur => ur.PathId).IsRequired();
                b.HasMany(u => u.PathRestritions).WithOne().HasForeignKey(ur => ur.PathId).IsRequired();
            });

            builder.Entity<Models.Action<TKey>>(b =>
            {
                b.HasKey(r => r.ActionId);
                b.ToTable("AspNetActions");
                b.HasMany(u => u.Roles).WithOne().HasForeignKey(ur => ur.ActionId).IsRequired();
            });

            builder.Entity<PathRestrition<TKey>>(b =>
            {
                b.HasKey(r => r.Id);
                b.ToTable("AspNetPathRestritions");
            });

            builder.Entity<RoleRestrition<TKey>>(b =>
            {
                b.HasKey(r => r.Id);
                b.ToTable("AspNetRoleRestritions");
            });

            builder.Entity<Application>(b =>
            {
                b.HasKey(r => r.ApplicationId);
                b.ToTable("AspNetApplications");
                b.HasMany(u => u.Paths).WithOne().HasForeignKey(ur => ur.ApplicationId).IsRequired();
            });

            builder.Entity<LoginLog<TKey>>(b =>
            {
                b.HasKey(r => r.Id);
                b.ToTable("AspNetLoginLogs");
            });

            builder.Entity<EventLog>(b =>
            {
                b.HasKey(r => r.LogID);
                b.ToTable("AspNetEventLogs");
            });

            builder.Entity<ErrorLog>(b =>
            {
                b.HasKey(r => r.LogID);
                b.ToTable("AspNetErrorLogs");
            });

            builder.Entity<Cms_News>(b =>
            {
                b.HasKey(r => r.News_ID);
                b.ToTable("CmsNews");
                b.Property(u => u.News_AddDate).IsRequired();
                b.Property(u => u.News_AddUser).HasMaxLength(64).IsRequired();
                b.Property(u => u.News_Catalog).IsRequired();
                b.Property(u => u.News_EditDate).IsRequired();
                b.Property(u => u.News_EditUser).HasMaxLength(64).IsRequired();
                b.Property(u => u.News_From).HasMaxLength(32).IsRequired();
                b.Property(u => u.News_Hits).IsRequired();
                b.Property(u => u.News_isAuth).IsRequired();
                b.Property(u => u.News_isDel).IsRequired();
                b.Property(u => u.News_Keywords).HasMaxLength(128).IsRequired();
                b.Property(u => u.News_Subtitle).HasMaxLength(32).IsRequired();
                b.Property(u => u.News_Summary).HasMaxLength(256).IsRequired();
                b.Property(u => u.News_Text).HasColumnType("Text").IsRequired();
                b.Property(u => u.News_Title).HasMaxLength(64).IsRequired();
            });

            #endregion

            #endregion

            #region 仓储
            #region module


            builder.Entity<File>(b =>
            {
                b.HasKey(r => r.FileId);
                b.ToTable("WmsFiles");
                b.Property(u => u.FileName).HasMaxLength(128).IsRequired();
                b.Property(u => u.FileType).HasMaxLength(64).IsRequired();
                b.Property(u => u.FileExtensions).HasMaxLength(64).IsRequired();
                b.Property(u => u.Url).HasMaxLength(64);
                b.Property(u => u.ThumbnailUrl).HasMaxLength(64);
                b.Property(u => u.Content).HasColumnType("Image");
                b.Property(u => u.Thumbnail).HasColumnType("Image");
            });

            builder.Entity<TrayType>(b =>
            {
                b.HasKey(r => r.TrayTypeId);
                b.ToTable("WmsTrayTypes");
                b.Property(u => u.Image).HasColumnType("Image");
                b.Property(u => u.Name).HasMaxLength(64).IsRequired();
                b.Property(u => u.Discription).HasMaxLength(256).IsRequired();
                b.Property(u => u.Size).HasMaxLength(64).IsRequired();
                b.Property(u => u.TrayTypeId).HasMaxLength(16);
                b.HasMany(u => u.Trays).WithOne().HasForeignKey(ur => ur.TrayTypeId).IsRequired();
            });

            builder.Entity<Tray>(b =>
            {
                b.HasKey(r => r.TrayId);
                b.ToTable("WmsTrays");
                b.Property(u => u.TrayTypeId).HasMaxLength(16);
                b.Property(r => r.IsFull).IsRequired();
                b.HasMany(u => u.BinLocations).WithOne().HasForeignKey(ur => ur.TrayId).IsRequired();
            });
            builder.Entity<BinLocation>(b =>
            {
                b.HasKey(r => r.BinLocationId);
                b.ToTable("WmsBinLocations");
                b.Property(r => r.R).IsRequired();
                b.Property(r => r.X).IsRequired();
                b.Property(r => r.Y).IsRequired();
                b.Property(r => r.Z).IsRequired();
                b.Property(r => r.Name).HasMaxLength(64).IsRequired();
                b.Property(r => r.Type).HasMaxLength(32).IsRequired();
                b.Property(r => r.Discription).HasMaxLength(256).IsRequired();
                b.HasMany(u => u.Trays).WithOne().HasForeignKey(ur => ur.BinLocationId).IsRequired();
            });

            builder.Entity<TrayInBinLocation>(b =>
            {
                b.HasKey(r => r.TrayId);
                b.ToTable("WmsTrayInBinLocations");
            });



            /*
           
            



            */
            //builder.Entity<TrayType>(b =>
            //{
            //});

            #endregion

            #endregion

            #region 水费

            #region 关系表

            builder.Entity<PricesType>(b =>
            {
                b.HasKey(r => r.ids);
                b.ToTable("WaterPricesTypes");
            });

            builder.Entity<WaterPrices>(b =>
            {
                b.HasKey(r => r.Prices_Id);
                b.ToTable("WaterPrices");
            });

            builder.Entity<WaterMeter>(b =>
            {
                b.HasKey(r => r.Wm_IdCard);
                b.ToTable("WaterMeters");
            });

            builder.Entity<WaterValue>(b =>
            {
                b.HasKey(r => new { r.Wm_IdCard, r.Wv_Year, r.Wv_Month });
                b.ToTable("WaterValues");
            });

            builder.Entity<WaterValueImport>(b =>
            {
                b.HasKey(r => new { r.Wm_IdCard, r.Wv_Year, r.Wv_Month });
                b.ToTable("WaterValueImports");
            });
            builder.Entity<WaterPayment>(b =>
            {
                b.HasKey(r => new { r.Wm_IdCard, r.Wv_Year, r.Wv_Month });
                b.ToTable("WaterPayments");
            });
            #endregion

            #region Models

            builder.Entity<PricesType>(b =>
            {
                b.Property(u => u.name).HasMaxLength(128).IsRequired();
                b.Property(u => u.isUse).IsRequired();
                b.Property(u => u.addTime).IsRequired();
                b.HasMany(u => u.WaterPrices).WithOne().HasForeignKey(ur => ur.ids).IsRequired();
            });

            builder.Entity<WaterPrices>(b =>
            {
                b.Property(u => u.Prices_Value).IsRequired();
                b.Property(u => u.Prices_Start).IsRequired();
                b.Property(u => u.Prices_End).IsRequired();
                b.Property(u => u.Prices_AddTime).IsRequired();
            });

            builder.Entity<WaterMeter>(b =>
            {
                b.Property(u => u.Wm_IdCard).HasMaxLength(32);
                b.Property(u => u.Wm_LogName).HasMaxLength(64).IsRequired();
                b.Property(u => u.Wm_Weixin).HasMaxLength(128).IsRequired();
                b.Property(u => u.Wm_Tel).HasMaxLength(64).IsRequired();
                b.Property(u => u.Wm_Pwd).IsRequired();
                b.Property(u => u.isGroup).IsRequired();
                b.Property(u => u.isNeedPay).IsRequired();
                b.Property(u => u.Wu_Address).HasMaxLength(128).IsRequired();
                b.Property(u => u.Wu_Name).HasMaxLength(64).IsRequired();
                b.Property(u => u.Wu_Village).HasMaxLength(128).IsRequired();
            });

            builder.Entity<WaterValue>(b =>
            {
                b.Property(u => u.Wm_IdCard).HasMaxLength(32);
                b.Property(u => u.Wv_AddTime).IsRequired();
                b.Property(u => u.Wv_AddUser).HasMaxLength(128).IsRequired();
                b.Property(u => u.Wv_End).IsRequired();
                b.Property(u => u.Wv_ExChange).IsRequired();
                b.Property(u => u.Wv_ReadTime).IsRequired();
                b.Property(u => u.Wv_Start).IsRequired();
                b.Property(u => u.Wv_Status).IsRequired();
                b.HasOne(u => u.WaterMeter).WithMany().HasForeignKey(u => u.Wm_IdCard);
            });

            builder.Entity<WaterValueImport>(b =>
            {
                b.Property(u => u.Wm_IdCard).HasMaxLength(32);
                b.Property(u => u.Wv_AddTime).IsRequired();
                b.Property(u => u.Wv_AddUser).HasMaxLength(128).IsRequired();
                b.Property(u => u.Wv_End).IsRequired();
                b.Property(u => u.Wv_ExChange).IsRequired();
                b.Property(u => u.Wv_ReadTime).IsRequired();
                b.Property(u => u.Wv_Status).IsRequired();
                b.HasOne(u => u.WaterMeter).WithMany().HasForeignKey(u => u.Wm_IdCard);

            });

            builder.Entity<WaterPayment>(b =>
            {
                b.Property(u => u.Wm_IdCard).HasMaxLength(32);
                b.HasOne(u => u.WaterValue)
                .WithMany()
                .HasForeignKey(s => new { s.Wm_IdCard, s.Wv_Year, s.Wv_Month })
                .HasPrincipalKey(c => new { c.Wm_IdCard, c.Wv_Year, c.Wv_Month });
                b.HasOne(u => u.PricesType).WithMany().HasForeignKey(s => s.PricesType_ids);
            });

            #endregion
            
            #endregion



            base.OnModelCreating(builder);

        }


    }
}
