
using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Datas;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {

    }
    public DbSet<Goal> Goals { get; set; }
    public DbSet<Status> Statuses { get; set; }
    public DbSet<Priority> Priorities { get; set; }
}
