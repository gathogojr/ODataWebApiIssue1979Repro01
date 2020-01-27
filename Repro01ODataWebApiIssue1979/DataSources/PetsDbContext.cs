using Repro01ODataWebApiIssue1979.Models;
using Microsoft.EntityFrameworkCore;

namespace Repro01ODataWebApiIssue1979.DataSources
{
    public partial class PetsDbContext : DbContext
    {
        public PetsDbContext()
        {
        }

        public PetsDbContext(DbContextOptions<PetsDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Person> Persons { get; set; }

        public virtual DbSet<Pet> Pets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Data Source = (LocalDb)\MSSQLLocalDB; Integrated Security = True; Persist Security Info = True; Database = Repro01PetsDb");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");
            modelBuilder.Entity<Person>(entity =>
            {
                entity.Property<int>("ShadowId");
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.HasKey("ShadowId", "Id");
                entity.Property(e => e.Name).HasMaxLength(100).IsRequired(false);
            });

            modelBuilder.Entity<Pet>(entity =>
            {
                entity.Property<int>("ShadowId");
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.HasKey("ShadowId", "Id");
                entity.Property(e => e.Name).HasMaxLength(100).IsRequired(false);
                entity.HasOne(d => d.Owner)
                    .WithOne()
                    .HasForeignKey<Pet>("ShadowId", "OwnerId");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

/*
SET IDENTITY_INSERT [dbo].[Persons] ON 
INSERT [dbo].[Persons] ([ShadowId], [Id], [Name]) VALUES (4, 4, N'Annie')
INSERT [dbo].[Persons] ([ShadowId], [Id], [Name]) VALUES (6, 6, N'Jean')
SET IDENTITY_INSERT [dbo].[Persons] OFF
GO

SET IDENTITY_INSERT [dbo].[Pets] ON 
INSERT [dbo].[Pets] ([ShadowId], [Id], [Name], [OwnerId]) VALUES (4, 4, N'Mittens', 4)
INSERT [dbo].[Pets] ([ShadowId], [Id], [Name], [OwnerId]) VALUES (5, 5, N'Patches', NULL)
INSERT [dbo].[Pets] ([ShadowId], [Id], [Name], [OwnerId]) VALUES (6, 6, N'Paddy', 6)
SET IDENTITY_INSERT [dbo].[Pets] OFF
GO
 */
