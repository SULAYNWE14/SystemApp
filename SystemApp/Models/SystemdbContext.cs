using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SystemApp.Models;

public partial class SystemdbContext : DbContext
{
    public SystemdbContext()
    {
    }

    public SystemdbContext(DbContextOptions<SystemdbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AccountUser> AccountUsers { get; set; }
    public virtual DbSet<ClassesTbl> ClassesTbl { get; set; }
    public virtual DbSet<StudentTbl> StudentTbl { get; set; }
    public virtual DbSet<TeacherTbl> TeacherTbl { get; set; }
   

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AccountUser>(entity =>
        {
            entity.ToTable("AccountUser");

            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.MailAddress).HasMaxLength(50);
            entity.Property(e => e.Password)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Phone).HasMaxLength(50);
            entity.Property(e => e.UserName).HasMaxLength(50);
        });
        modelBuilder.Entity<ClassesTbl>(entity =>
        {
            entity.ToTable("ClassesTbl");

            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.Address).HasMaxLength(50);
            entity.Property(e => e.Description).HasMaxLength(50);
            entity.Property(e => e.ClassName).HasMaxLength(50);
        });
        modelBuilder.Entity<StudentTbl>(entity =>
        {
            entity.ToTable("StudentTbl");

            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.Remark).HasMaxLength(50);
            entity.Property(e => e.Emailaddress).HasMaxLength(50);
            entity.Property(e => e.StudentName).HasMaxLength(50);
        });
        modelBuilder.Entity<TeacherTbl>(entity =>
        {
            entity.ToTable("TeacherTbl");

            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.Phone).HasMaxLength(50);
            entity.Property(e => e.Address).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
        });
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
