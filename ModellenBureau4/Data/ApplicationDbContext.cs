using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ModellenBureau4.Shared;

namespace ModellenBureau4.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Country> Countries { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                Id = 1,
                BirthDate = new DateTime(1979, 1, 16),
                City = "Brussels",
                Email = "bethany@bethanyspieshop.com",
                FirstName = "Bethany",
                LastName = "Smith",
                Gender = Gender.Female,
                PhoneNumber = "324777888773",
                Street = "Grote Markt 1",
                Zip = "1000",
                Height = 170,
                Weight = 60,
            });
            modelBuilder.Entity<Customer>().HasData(new Customer
            {
                Id = 2,
                BirthDate = new DateTime(1972, 1, 16),
                City = "Brussels2",
                Email = "bethany@bethanyspieshop2.com",
                FirstName = "Bethany2",
                LastName = "Smith2",
                Gender = Gender.Female,
                PhoneNumber = "324777888772",
                Street = "Grote Markt 12",
                Zip = "1002",
            });
        }
    }
}
