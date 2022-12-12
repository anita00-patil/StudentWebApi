using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace StudentWebApi.Models;

public partial class WebDbContext : DbContext
{
   

    public WebDbContext(DbContextOptions<WebDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Student> Students { get; set; }

    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Student__3214EC0770F53A77");

            entity.ToTable("Student");

            entity.Property(e => e.Address)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FatherName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
