using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MyFirstWebApp.Models;

public partial class MajuContext : DbContext
{
    public MajuContext()
    {
    }

    public MajuContext(DbContextOptions<MajuContext> options)
        : base(options)
    {
    }

    public virtual DbSet<StudentNew> StudentNews { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-1GTCP0O\\SQLEXPRESS;Database=MAJU;Trusted_Connection=True;trustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<StudentNew>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__StudentN__3214EC0754F0DCA5");

            entity.ToTable("StudentNew");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Age).HasColumnName("AGE");
            entity.Property(e => e.Contact)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("CONTACT");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NAME");
            entity.Property(e => e.Semester)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("SEMESTER");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
