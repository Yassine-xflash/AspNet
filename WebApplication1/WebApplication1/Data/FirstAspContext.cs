using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Data;

public partial class FirstAspContext : DbContext
{
    public FirstAspContext()
    {
    }

    public FirstAspContext(DbContextOptions<FirstAspContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Class> Classes { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Enreollement> Enreollements { get; set; }

    public virtual DbSet<Lecture> Lectures { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-7H4B19K\\SQLEXPRESS;Database=FirstAsp;User Id=ali;Password=12345678;Trusted_Connection=false;MultipleActiveResultSets=True;Encrypt=false;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Class>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Classes__3214EC07CC22D3E5");

            entity.HasOne(d => d.Course).WithMany(p => p.Classes)
                .HasForeignKey(d => d.Courseid)
                .HasConstraintName("FK__Classes__Coursei__4AB81AF0");

            entity.HasOne(d => d.Lecture).WithMany(p => p.Classes)
                .HasForeignKey(d => d.LectureId)
                .HasConstraintName("FK__Classes__Lecture__49C3F6B7");
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Courses__3214EC075F807563");

            entity.HasIndex(e => e.Code, "UQ__Courses__A25C5AA7A55E9A35").IsUnique();

            entity.Property(e => e.Code).HasMaxLength(5);
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Enreollement>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Enreolle__3214EC07E922FE72");

            entity.Property(e => e.Grade).HasMaxLength(2);

            entity.HasOne(d => d.Classe).WithMany(p => p.Enreollements)
                .HasForeignKey(d => d.ClasseId)
                .HasConstraintName("FK__Enreollem__Class__4E88ABD4");

            entity.HasOne(d => d.Student).WithMany(p => p.Enreollements)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK__Enreollem__Stude__4D94879B");
        });

        modelBuilder.Entity<Lecture>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Lectures__3214EC07760ECCF4");

            entity.Property(e => e.FirstName).HasMaxLength(30);
            entity.Property(e => e.LasrtName).HasMaxLength(30);
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Students__3214EC071B4565EB");

            entity.Property(e => e.FirstName).HasMaxLength(30);
            entity.Property(e => e.LasrtName).HasMaxLength(30);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
