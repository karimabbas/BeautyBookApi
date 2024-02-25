using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeautyBook.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BeautyBook.DAL.Context
{
    public class MyDbContext : IdentityDbContext<BaseUser, IdentityRole, string>
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //BaseUser
            builder.Entity<BaseUser>().Property(b => b.UserSurname).HasColumnType("VARCHAR").HasMaxLength(100);
            builder.Entity<BaseUser>().Property(b => b.Photo).HasColumnType("VARCHAR").HasMaxLength(200).HasDefaultValue("/images/profile.webp").IsRequired(false);

            //one To one
            builder.Entity<BaseUser>().HasOne(b => b.Worker).WithOne(b => b.BaseUser).OnDelete(DeleteBehavior.Cascade).IsRequired();

            //Worker
            //one To Many
            builder.Entity<Worker>().HasOne(C => C.Company).WithMany(w => w.Workers);

            //Company
            builder.Entity<Company>().Property(c => c.Name).HasDefaultValue("Company_" + DateTime.Now.ToString("yyyy/MMM/ddd|hh:mm:ss"));
            builder.Entity<Company>().Property(c => c.Logo).HasDefaultValue("/images/logoCompany.webp");


            //One to Many (Location)
            builder.Entity<Company>().HasOne(c => c.Location).WithMany(l => l.Companies).OnDelete(DeleteBehavior.NoAction);

            //One to Many
            builder.Entity<CompanyOpenHours>().HasOne(s => s.Company).WithMany(c => c.CompanyOpenHours).OnDelete(DeleteBehavior.Cascade);

            //CompanyImage
            builder.Entity<CompanyImage>().HasOne(ci => ci.Company).WithMany(c => c.CompanyImages).OnDelete(DeleteBehavior.Cascade).IsRequired();

            //CompanyLike
            builder.Entity<CompanyLike>().HasOne(cl => cl.User).WithMany(u => u.FavoriteCompanies).OnDelete(DeleteBehavior.Cascade);
            builder.Entity<CompanyLike>().HasOne(cl => cl.Company).WithMany(c => c.LikedByUsers).OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(builder);
        }

        public DbSet<BaseUser> BaseUsers { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CompanyImage> CompanyImages { get; set; }
        public DbSet<CompanyLike> CompanyLikes { get; set; }
    }
}