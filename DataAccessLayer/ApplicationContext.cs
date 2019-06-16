﻿namespace DAL
{
    using Microsoft.EntityFrameworkCore;
    using BusinessLogic;

    public class ApplicationContext : DbContext
        {
            public DbSet<Pad> Pads { get; set; }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=usersdb;Username=postgres;Password=password");
            }
        }
}