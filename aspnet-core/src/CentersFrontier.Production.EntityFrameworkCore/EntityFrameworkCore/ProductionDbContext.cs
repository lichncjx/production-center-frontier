using Abp.Zero.EntityFrameworkCore;
using CentersFrontier.Production.Authorization.Roles;
using CentersFrontier.Production.Authorization.Users;
using CentersFrontier.Production.Drawings;
using CentersFrontier.Production.Launches;
using CentersFrontier.Production.Models;
using CentersFrontier.Production.MultiTenancy;
using CentersFrontier.Production.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CentersFrontier.Production.EntityFrameworkCore
{
    public class ProductionDbContext : AbpZeroDbContext<Tenant, Role, User, ProductionDbContext>
    {
        /* Define a DbSet for each entity of the application */

        // models
        public DbSet<Series> Series { get; set; }
        public DbSet<Model> Models { get; set; }

        // launches
        public DbSet<Launch> Launches { get; set; }
        //public DbSet<Bundle> Bundles { get; set; }

        // tasks
        //public DbSet<ProductionTask> ProductionTasks { get; set; }
        public DbSet<TaskClassification> Classifications { get; set; }

        // drawings
        public DbSet<Drawing> Drawings { get; set; }

        public ProductionDbContext(DbContextOptions<ProductionDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Models

            modelBuilder.Entity<Series>(entity =>
            {
                entity.HasMany(s => s.Models)
                    .WithOne(m => m.Series)
                    .HasForeignKey("SeriesCode")
                    .HasPrincipalKey(s => s.Code)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<Model>(entity =>
            {
                entity.HasMany(m => m.Derivatives)
                    .WithOne()
                    .HasForeignKey(m => m.DerivedFrom)
                    .HasPrincipalKey(m => m.Code)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            #region SeriesSeed

            modelBuilder.Entity<Series>().HasData(
                new Series { Id = 1, Code = "CZ-5/5B", Name = "长五系列", Description = "长征五号系列运载火箭" },
                new Series { Id = 2, Code = "CZ-7/7A", Name = "长七系列", Description = "长征七号系列运载火箭" },
                new Series { Id = 3, Code = "CZ-3A/3B/3C", Name = "长三甲系列", Description = "长征三号甲系列运载火箭" });

            #endregion

            #region ModelSeed

            modelBuilder.Entity<Model>().HasData(
                new { Id = 1, Code = "CZ-5", Name = "长征五号", Description = "长征五号运载火箭", SeriesCode = "CZ-5/5B" },
                new { Id = 2, Code = "CZ-5B", Name = "长征五号乙", Description = "长征五号乙运载火箭", SeriesCode = "CZ-5/5B", DerivedFrom = "CZ-5" },
                new { Id = 3, Code = "CZ-7", Name = "长征七号", Description = "长征五号运载火箭", SeriesCode = "CZ-7/7A" },
                new { Id = 4, Code = "CZ-7A", Name = "长征七号甲", Description = "长征七号甲运载火箭", SeriesCode = "CZ-7/7A", DerivedFrom = "CZ-7" },
                new { Id = 5, Code = "CZ-3A", Name = "长征三号甲", Description = "长征三号甲运载火箭", SeriesCode = "CZ-3A/3B/3C" },
                new { Id = 6, Code = "CZ-3B", Name = "长征三号乙", Description = "长征三号乙运载火箭", SeriesCode = "CZ-3A/3B/3C", DerivedFrom = "CZ-3A" },
                new { Id = 7, Code = "CZ-3C", Name = "长征三号丙", Description = "长征三号丙运载火箭", SeriesCode = "CZ-3A/3B/3C", DerivedFrom = "CZ-3A" },
                new { Id = 8, Code = "CZ-6", Name = "长征六号", Description = "长征六号运载火箭" });

            #endregion

            #endregion

            #region Launches

            modelBuilder.Entity<Launch>(entity =>
            {
                entity.HasOne(l => l.Model)
                    .WithMany(m => m.Launches)
                    .HasForeignKey(l => l.ModelCode)
                    .HasPrincipalKey(m => m.Code);

                entity.HasOne(b => b.SpecialClassification)
                    .WithMany()
                    .HasForeignKey(b => b.SpecialClassificationId);
                entity.HasOne(b => b.UniversalClassification)
                    .WithMany()
                    .HasForeignKey(b => b.UniversalClassificationId);

                entity.Property(l => l.ModelCode).IsRequired();
                entity.Property(l => l.Stage).HasConversion<string>();
            });

            #region LaunchSeed

            modelBuilder.Entity<Launch>().HasData(
                new Launch { Id = 1, Code = "CZ-5 Y1", Name = "长五遥一", ModelCode = "CZ-5", Stage = DevelopmentStage.S, SpecialClassificationId = "XxAS04", UniversalClassificationId = "XyAT14" },
                new Launch { Id = 2, Code = "CZ-5 Y2", Name = "长五遥二", ModelCode = "CZ-5", Stage = DevelopmentStage.S, SpecialClassificationId = "XxAS04", UniversalClassificationId = "XyAT14" },
                new Launch { Id = 3, Code = "CZ-5 Y3", Name = "长五遥三", ModelCode = "CZ-5", Stage = DevelopmentStage.S, SpecialClassificationId = "XxAS04", UniversalClassificationId = "XyAT14" },
                new Launch { Id = 4, Code = "CZ-5B Y1", Name = "长五乙遥一", ModelCode = "CZ-5B", Stage = DevelopmentStage.C, SpecialClassificationId = "YyAC04", UniversalClassificationId = "XyAT14" },
                new Launch { Id = 5, Code = "CZ-7 Y1", Name = "长七遥一", ModelCode = "CZ-7", Stage = DevelopmentStage.S },
                new Launch { Id = 6, Code = "CZ-7 Y2", Name = "长七遥二", ModelCode = "CZ-7", Stage = DevelopmentStage.S },
                new Launch { Id = 7, Code = "CZ-7A SY", Name = "长七甲试验", ModelCode = "CZ-7A", Stage = DevelopmentStage.C },
                new Launch { Id = 8, Code = "CZ-6 Y1", Name = "长六遥一", ModelCode = "CZ-6", Stage = DevelopmentStage.S },
                new Launch { Id = 9, Code = "CZ-6 Y2", Name = "长六遥二", ModelCode = "CZ-6", Stage = DevelopmentStage.S });

            #endregion

            #endregion


            #region Drawings

            #region PartSeed

            modelBuilder.Entity<SpecialPart>().HasData(
                new SpecialPart { Id = 1, Code = "ZYJ-001", Name = "专用件1" },
                new SpecialPart { Id = 2, Code = "ZYJ-002", Name = "专用件2" }
            );

            modelBuilder.Entity<StandardPart>().HasData(
                new StandardPart { Id = 3, Code = "BZJ-001", Name = "标准件1" }
            );

            modelBuilder.Entity<UniversalPart>().HasData(
                new UniversalPart { Id = 4, Code = "TYJ-001", Name = "通用件1" }
            );

            #endregion

            #region AssemblySeed

            modelBuilder.Entity<Assembly>().HasData(
                new Assembly { Id = 5, Code = "ZJ-001", Name = "组件1" },
                new Assembly { Id = 6, Code = "ZJ-002", Name = "组件2" }
            );

            #endregion

            modelBuilder.Entity<Assembly>(entity =>
            {
                entity.OwnsMany(drawing => drawing.AssemblyDetails, a =>
                {
                    // foreign key to owner
                    a.HasForeignKey("AssemblyCode")
                        .HasPrincipalKey(d => d.Code);

                    // primary key
                    a.HasKey("AssemblyCode",
                        "Ordinal");

                    // reference navigational property to drawing entity
                    a.HasOne(d => d.Drawing)
                        .WithMany()
                        .HasForeignKey(d => d.Code)
                        .HasPrincipalKey(d => d.Code);
                    //a.Property(d => d.DrawingCode).IsRequired();

                    a.Property(d => d.TotalWeight).HasComputedColumnSql("[UnitWeight] * [Quantity]");

                    a.Property(d => d.Borrowed).HasDefaultValue(false);

                    /*
                    ZJ-002
                        |-- ZJ-001
                            |-- ZYJ-001
                            |-- BZJ-001
                        |-- ZYJ - 002
                        |-- TYJ - 001
                    */
                    a.HasData(
                        new { AssemblyCode = "ZJ-002", Ordinal = 1, Code = "ZJ-001", Name = "组件1", Quantity = 2, Borrowed = false },
                        new { AssemblyCode = "ZJ-002", Ordinal = 2, Code = "ZYJ-002", Name = "专用件2", Quantity = 1, Borrowed = true },
                        new { AssemblyCode = "ZJ-002", Ordinal = 3, Code = "TYJ-001", Name = "通用件1", Quantity = 1, Borrowed = false },
                        new { AssemblyCode = "ZJ-001", Ordinal = 1, Code = "ZYJ-001", Name = "专用件1", Quantity = 1, Borrowed = false },
                        new { AssemblyCode = "ZJ-001", Ordinal = 2, Code = "BZJ-001", Name = "标准件1", Quantity = 4, Borrowed = false, UnitWeight = 0.027f }
                    );
                });
            });

            #endregion

            #region Tasks

            #region TaskClassificationSeed

            modelBuilder.Entity<TaskClassification>().HasData(
                new TaskClassification { Id = "XxAS04", IsUniversal = false },
                new TaskClassification { Id = "YyAC04", IsUniversal = false },
                new TaskClassification { Id = "XyAT14", IsUniversal = true });

            #endregion

            #endregion
        }
    }
}
