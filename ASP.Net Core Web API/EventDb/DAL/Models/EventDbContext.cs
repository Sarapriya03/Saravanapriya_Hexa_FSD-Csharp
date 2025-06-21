using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using System;

namespace DAL.Models
{
    public class EventDbContext : DbContext
    {
        public DbSet<UserInfo> Users { get; set; }
        public DbSet<EventDetails> Events { get; set; }
        public DbSet<SessionInfo> Sessions { get; set; }
        public DbSet<SpeakersDetails> SpeakersDetails { get; set; }
        public DbSet<ParticipantEventDetails> ParticipantEventDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    DatabaseHelper.GetConnectionString(),
                    options => options.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null)
                );
            }

            base.OnConfiguring(optionsBuilder);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // One-to-Many: EventDetails - Sessions
            modelBuilder.Entity<SessionInfo>()
                .HasOne<EventDetails>()
                .WithMany()
                .HasForeignKey(s => s.EventId);

            // Seed data for default Admin user
            modelBuilder.Entity<UserInfo>().HasData(
                new UserInfo
                {
                    EmailId = "admin@gmail.com",
                    UserName = "Admin",
                    Password = "admin123",
                    Role = "Admin"
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}
