using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace HomeWork1.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    //db set
    public DbSet<Staff> Staff { set; get; }
}

