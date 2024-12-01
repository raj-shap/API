﻿using Microsoft.EntityFrameworkCore;

namespace API.Models
{
    public partial class MyDbContext : DbContext
    {
        public MyDbContext() { }
        public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
        {
        }
        public virtual DbSet<User> Users { get; set; }
    }
}