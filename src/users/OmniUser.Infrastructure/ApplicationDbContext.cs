using System;
using Microsoft.EntityFrameworkCore;
using OmniUser.Domain.Entities;

namespace OmniUser.Infrastructure;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
}
