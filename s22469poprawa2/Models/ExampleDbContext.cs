using Microsoft.EntityFrameworkCore;
using System;

namespace s22469poprawa2.Models
{
    public class ExampleDbContext : DbContext
    {
        public ExampleDbContext()
        {
        }
        public ExampleDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<File> File { get; set; }
        public DbSet<Member> Member { get; set; }
        public DbSet<Membership> Membership { get; set; }
        public DbSet<Organization> Organization { get; set; }
        public DbSet<Team> Team { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=db-mssql;Initial Catalog=s22469;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Organization>(entity =>
            {
                entity.HasKey(e => e.OrganizationID);
                entity.Property(e => e.OrganizationName);
                entity.Property(e => e.OrganizationDomain);
                entity.HasData(
                new Organization(1, "ZwiazekPilkarzy","xyz"),
                new Organization(2, "ZwiazekZeglarzy", "xxx"));
            });

            modelBuilder.Entity<Member>(entity =>
            {
                entity.HasKey(e => e.MemberID);
                entity.Property(e => e.MeMberName);
                entity.Property(e => e.MemberSurname);
                entity.Property(e => e.MemberNickName);
                entity.HasOne(d => d.OrganizationF)
                .WithMany(p => p.Members)
                .HasForeignKey(d => d.MemberID);
                entity.HasData(
                    new Member(1, 1, "Jarek", "Kowalczyk", "Ziom"),
                    new Member(2, 1, "Aneta", "Nowak", "Ziomalka"),
                    new Member(3, 2, "Kasia", "Szymanska", "Kajak"));
            });

            modelBuilder.Entity<Team>(entity =>
            {
                entity.HasKey(e => e.TeamID);
                entity.Property(e => e.TeamName);
                entity.Property(e => e.TeamDescription);
                entity.HasOne(d => d.OrganizationF)
                .WithMany(p => p.Teams)
                .HasForeignKey(d => d.TeamID);
                entity.HasData(
                    new Team(1, 1, "Zolwie", "Wolne"),
                    new Team(2, 2, "Kozy", "Mleczne")
             );
            });

            modelBuilder.Entity<Membership>(entity =>
            {
                entity.HasKey(e => e.MemberID);
                entity.HasKey(e => e.TeamID);
                entity.Property(e => e.MembershipDate);

                entity.HasOne(d => d.MemberF)
                .WithMany(p => p.MembershipsMember)
                .HasForeignKey(d => d.MemberID);
                entity.HasOne(d => d.TeamF)
                .WithMany(p => p.Memberships)
                .HasForeignKey(d => d.TeamID);
                entity.HasData(
                    new Membership(1, 2, DateTime.Parse("2006-01-05")),
                    new Membership(2, 1, DateTime.Parse("2006-02-13"))
                    );
            });

            modelBuilder.Entity<File>(entity =>
            {
                entity.HasKey(e => e.FileID);
                entity.HasKey(e => e.TeamID);
                entity.Property(e => e.FileName);
                entity.Property(e => e.FileExtension);
                entity.HasOne(d => d.TeamF).WithMany(p => p.Files).HasForeignKey(d => d.TeamID);
                entity.HasData(
                    new File(1, 1, "hehe", "exe", 500),
                    new File(2, 2, "wyniki", "pdf", 1000)
                    );
            });
        }
    }
}