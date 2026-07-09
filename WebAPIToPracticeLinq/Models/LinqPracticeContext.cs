using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebAPIToPracticeLinq.Models;

public partial class LinqPracticeContext : DbContext
{
    public LinqPracticeContext()
    {
    }

    public LinqPracticeContext(DbContextOptions<LinqPracticeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Designation> Designations { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=ABHIJEET-PC\\SQLEXPRESS; Database=LinqPractice; Trusted_Connection=True; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Designation>(entity =>
        {
            entity.HasKey(e => e.DesignationId).HasName("PK__Designat__BABD60DE0ECBBBE4");

            entity.ToTable("Designation");

            entity.Property(e => e.DesignationName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmpId).HasName("PK__Employee__AF2DBB992A204FDB");

            entity.ToTable("Employee");

            entity.HasIndex(e => e.Empcode, "UQ__Employee__0167F3B0F40F751B").IsUnique();

            entity.Property(e => e.EmailAddress)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Empcode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Empname)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.MobileNumber)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Salary).HasColumnName("salary");

            entity.HasOne(d => d.Designation).WithMany(p => p.Employees)
                .HasForeignKey(d => d.DesignationId)
                .HasConstraintName("fk1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
