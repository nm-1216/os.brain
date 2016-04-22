
namespace Os.Brain.Models
{
    using System;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.Data.Entity;
    using Microsoft.Data.Entity.Infrastructure;
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
        public AppDbContext(DbContextOptions options):base(options)
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

            base.OnModelCreating(builder);

        }
    }
}
