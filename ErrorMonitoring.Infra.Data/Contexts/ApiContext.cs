using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ErrorMonitoring.Dominio.Entidades;
using Microsoft.Extensions.Logging;

namespace ErrorMonitoring.Infra.Data.Contexts
{
    public partial class ApiContext : DbContext,IDisposable
    {
        public ApiContext()
        {
        }

        public ApiContext(DbContextOptions<ApiContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Environments> Environments { get; set; }
        public virtual DbSet<Events> Events { get; set; }
        public virtual DbSet<Logs> Logs { get; set; }
        public virtual DbSet<Projects> Projects { get; set; }
        public virtual DbSet<ProjectsEnvironments> ProjectsEnvironments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()));

            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Server=tcp:projetocodenation.database.windows.net,1433;Initial Catalog=errormonitoring;Persist Security Info=False;User ID=squad2;Password=jPDt2e^nAUDD;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;")
                //optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS; Database=ErrorMonitoring; Integrated Security = True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Environments>(entity =>
            {
                entity.ToTable("ENVIRONMENTS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.EnvName)
                    .IsRequired()
                    .HasColumnName("envName")
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Events>(entity =>
            {
                entity.ToTable("EVENTS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.EColectedBy)
                    .HasColumnName("eColectedBy")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.EDate)
                    .HasColumnName("eDate")
                    .HasColumnType("date");

                entity.Property(e => e.EDescription)
                    .HasColumnName("eDescription")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.EException)
                    .HasColumnName("eException")
                    .IsUnicode(false);

                entity.Property(e => e.ELevel)
                    .IsRequired()
                    .HasColumnName("eLevel")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.EMessage)
                    .HasColumnName("eMessage")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.EOrigin)
                    .HasColumnName("eOrigin")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.EStatus)
                    .IsRequired()
                    .HasColumnName("eStatus")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Logs>(entity =>
            {
                entity.ToTable("LOGS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Archived).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.EventTypeNavigation)
                    .WithMany(p => p.Logs)
                    .HasForeignKey(d => d.EventType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__LOGS__EventType__3C69FB99");

                entity.HasOne(d => d.ProjectNavigation)
                    .WithMany(p => p.Logs)
                    .HasForeignKey(d => d.Project)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__LOGS__Project__3B75D760");
            });

            modelBuilder.Entity<Projects>(entity =>
            {
                entity.ToTable("PROJECTS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.IsDesktop).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsMobile).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsWeb).HasDefaultValueSql("((0))");

                entity.Property(e => e.PName)
                    .IsRequired()
                    .HasColumnName("pName")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ProjectsEnvironments>(entity =>
            {
                entity.ToTable("PROJECTS_ENVIRONMENTS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.HasOne(d => d.EnvironmentNavigation)
                    .WithMany(p => p.ProjectsEnvironments)
                    .HasForeignKey(d => d.Environment)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PROJECTS___Envir__412EB0B6");

                entity.HasOne(d => d.ProjectNavigation)
                    .WithMany(p => p.ProjectsEnvironments)
                    .HasForeignKey(d => d.Project)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PROJECTS___Proje__403A8C7D");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
