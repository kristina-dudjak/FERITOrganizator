using FERITOrganizator.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace FERITOrganizator.Server.Models
{
    public partial class OrganizatorContext : DbContext
    {
        public virtual DbSet<Note> Notes { get; set; }

        public virtual DbSet<NotificationSubscription> NotificationSubscriptions { get; set; } 

        public OrganizatorContext(DbContextOptions<OrganizatorContext> options)
            : base(options){}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Note>(entity =>
            {
                entity.Property(e => e.Due).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(80)
                    .IsUnicode(false);

            });
            modelBuilder.Entity<NotificationSubscription>(entity =>
            {
                entity.Property(p => p.NotificationSubscriptionId).IsRequired().ValueGeneratedNever();
                entity.Property(p => p.UserId).IsRequired().ValueGeneratedNever();

            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
