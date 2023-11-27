using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;

namespace UserAPI.Models;

public partial class ReactDemoDbContext : DbContext
{
  public ReactDemoDbContext()
  {
  }

  public ReactDemoDbContext(DbContextOptions<ReactDemoDbContext> options)
      : base(options)
  {
  }

  public virtual DbSet<UserDetail> UserDetails { get; set; }

  //    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
  //        => optionsBuilder.UseSqlServer("Server=.\\SQLExpress02; Database=ReactDemoDB;Trusted_Connection=True;TrustServerCertificate=true");

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<UserDetail>(entity =>
    {
      entity.HasKey(x => x.Id);
      entity.Property(e => e.Email).HasMaxLength(50);
      entity.Property(e => e.FirstName).HasMaxLength(20);
      entity.Property(e => e.LastName).HasMaxLength(20);
      entity.Property(e => e.Password).HasMaxLength(20);
    });

    OnModelCreatingPartial(modelBuilder);
  }

  partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
