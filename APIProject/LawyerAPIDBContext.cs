﻿using APIProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIProject
{
    public class LawyerAPIDBContext : DbContext
    {
        public LawyerAPIDBContext(DbContextOptions<LawyerAPIDBContext> options) : base(options)
        {

        }
        public DbSet<Users> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging(true);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>()
               .Property(b => b.Mobile)
               .IsRequired();
            modelBuilder.Entity<ClientProfile>().Property(b => b.Mobile).IsRequired();
            modelBuilder.Entity<LawyerProfile>().Property(b => b.Mobile).IsRequired();
            modelBuilder.Entity<ClientLawyerAssignment>().Property(b => b.LawyerId).IsRequired();
            modelBuilder.Entity<ClientLawyerAssignment>().Property(b => b.ClientId).IsRequired();
            modelBuilder.Entity<ClientLawyerAssignment>().HasOne(b => b.ClientProfile);
            modelBuilder.Entity<ClientLawyerAssignment>().HasOne(b => b.LawyerProfile);
        }

        public DbSet<APIProject.Models.ClientProfile> ClientProfile { get; set; }

        public DbSet<APIProject.Models.LawyerProfile> LawyerProfile { get; set; }

        public DbSet<APIProject.Models.ClientLawyerAssignment> ClientLawyerAssignment { get; set; }
    }
}
