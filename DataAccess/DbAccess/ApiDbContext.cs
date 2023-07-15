using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.DbAccess;

public class ApiDbContext : DbContext
{
    public virtual DbSet<SpaceXEventModel> SpaceXEventModels { get; set; }
    public virtual DbSet<LinksModel> LinksModels { get; set; }

    public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
    {
     
    }
  
    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    base.OnConfiguring(optionsBuilder);

    //    optionsBuilder.UseNpgsql(b => b.MigrationsAssembly("DataAccess"));
    //}

}