﻿using Hotels.Models;
using Microsoft.EntityFrameworkCore;

namespace Hotels.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Cart> cart { get; set; }
        public DbSet<Hotel> hotel { get; set; }
        public DbSet<Invoice> invoices { get; set; }
        public DbSet<RoomDetailes> roomDetailes { get; set; }
        public DbSet<Rooms> rooms { get; set; }


    }
}
