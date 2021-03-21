using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ELearningWebApp.API.Models
{
    public partial class ElearningWebAppdbContext : DbContext
    {
        public ElearningWebAppdbContext()
        {
        }

        public ElearningWebAppdbContext(DbContextOptions<ElearningWebAppdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admins> Admins { get; set; }
        public virtual DbSet<Chapters> Chapters { get; set; }
        public virtual DbSet<Class> Class { get; set; }
        public virtual DbSet<Students> Students { get; set; }
        public virtual DbSet<SubjectForSyllabus> SubjectForSyllabus { get; set; }
        public virtual DbSet<Subjects> Subjects { get; set; }
        public virtual DbSet<Syllabus> Syllabus { get; set; }
        public virtual DbSet<Topics> Topics { get; set; }
        public virtual DbSet<Videos> Videos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=ConnectionStrings:DefaultConnection");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admins>(entity =>
            {
                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.PasswordHash).IsRequired();

                entity.Property(e => e.PasswordSalt).IsRequired();
            });

            modelBuilder.Entity<Chapters>(entity =>
            {
                entity.HasIndex(e => e.SubjectForSyllabusId);

                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.SubjectName).IsRequired();

                entity.HasOne(d => d.SubjectForSyllabus)
                    .WithMany(p => p.Chapters)
                    .HasForeignKey(d => d.SubjectForSyllabusId)
                    .HasConstraintName("FK_Chapters_GetSubjectForSyllabus_SubjectForSyllabusId");
            });

            modelBuilder.Entity<Students>(entity =>
            {
                entity.Property(e => e.ClassName).IsRequired();

                entity.Property(e => e.MobileNo).IsRequired();

                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.PasswordHash).IsRequired();

                entity.Property(e => e.PasswordSalt).IsRequired();
            });

            modelBuilder.Entity<SubjectForSyllabus>(entity =>
            {
                entity.HasIndex(e => e.SubjectId)
                    .HasName("IX_GetSubjectForSyllabus_SubjectId");

                entity.HasIndex(e => e.SyllabusId)
                    .HasName("IX_GetSubjectForSyllabus_SyllabusId");

                entity.Property(e => e.SubjectName).IsRequired();

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.SubjectForSyllabus)
                    .HasForeignKey(d => d.SubjectId)
                    .HasConstraintName("FK_GetSubjectForSyllabus_Subjects_SubjectId");

                entity.HasOne(d => d.Syllabus)
                    .WithMany(p => p.SubjectForSyllabus)
                    .HasForeignKey(d => d.SyllabusId)
                    .HasConstraintName("FK_GetSubjectForSyllabus_Syllabus_SyllabusId");
            });

            modelBuilder.Entity<Syllabus>(entity =>
            {
                entity.HasIndex(e => e.ClassId);

                entity.Property(e => e.ClassName).IsRequired();

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.Syllabus)
                    .HasForeignKey(d => d.ClassId);
            });

            modelBuilder.Entity<Topics>(entity =>
            {
                entity.HasIndex(e => e.ChapterId);

                entity.Property(e => e.ChapterName).IsRequired();

                entity.Property(e => e.Name).IsRequired();

                entity.HasOne(d => d.Chapter)
                    .WithMany(p => p.Topics)
                    .HasForeignKey(d => d.ChapterId);
            });

            modelBuilder.Entity<Videos>(entity =>
            {
                entity.HasIndex(e => e.TopicId);

                entity.Property(e => e.ChapterName).IsRequired();

                entity.Property(e => e.ClassName).IsRequired();

                entity.Property(e => e.FileName).IsRequired();

                entity.Property(e => e.SubjectName).IsRequired();

                entity.Property(e => e.TopicName).IsRequired();

                entity.HasOne(d => d.Chapter)
                    .WithMany(p => p.Videos)
                    .HasForeignKey(d => d.ChapterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Videos_Chapters");

                entity.HasOne(d => d.SubjectForSyllabus)
                    .WithMany(p => p.Videos)
                    .HasForeignKey(d => d.SubjectForSyllabusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Videos_GetSubjectForSyllabus");

                entity.HasOne(d => d.Syllabus)
                    .WithMany(p => p.Videos)
                    .HasForeignKey(d => d.SyllabusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Videos_Syllabus");

                entity.HasOne(d => d.Topic)
                    .WithMany(p => p.Videos)
                    .HasForeignKey(d => d.TopicId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Videos_Topics");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
