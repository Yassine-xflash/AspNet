using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Data;

public partial class FirstAspContext : DbContext
{
    public FirstAspContext(DbContextOptions<FirstAspContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Course> Courses { get; set; }
    public virtual DbSet<Lecture> Lectures { get; set; }
    public virtual DbSet<Student> Students { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Courses__3214EC075F807563");

            entity.HasIndex(e => e.Code, "UQ__Courses__A25C5AA7A55E9A35").IsUnique();

            entity.Property(e => e.Code).HasMaxLength(5);
            entity.Property(e => e.Name).HasMaxLength(50);
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
