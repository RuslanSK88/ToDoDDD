
using Microsoft.EntityFrameworkCore;

namespace DAL.Datas;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {

    }
    //public DbSet
}
