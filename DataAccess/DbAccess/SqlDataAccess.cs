using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Configuration;

namespace DataAccess.DbAccess;

public class SqlDataAccess : ISqlDataAccess
{
    private readonly IConfiguration _config;

    public SqlDataAccess(IConfiguration config)
    {
        _config = config;
    }

    public async Task<SpaceXEventModel?> GetSpaceXEventEntityAsync<T>(long Id, string connectionId = "Default") where T : class
    {
        using var dbContext = new ApiDbContext(new DbContextOptionsBuilder<ApiDbContext>()
            .UseNpgsql(_config.GetConnectionString(connectionId))
            .Options);

        var entity = await dbContext.SpaceXEventModels
            .Include(e => e.Links)
            .FirstAsync(e => e.Id == Id);

        return entity;
    }
    public async Task<IEnumerable<T>> GetSpaceXEventEntitiesAsync<T>(string connectionId = "Default") where T : class
    {
        using var dbContext = new ApiDbContext(new DbContextOptionsBuilder<ApiDbContext>()
            .UseNpgsql(_config.GetConnectionString(connectionId))
            .Options);

        var entity = await dbContext.SpaceXEventModels
            .Include(e => e.Links)
             .ToListAsync();

        return (IEnumerable<T>)entity;
    }

    public async Task<T> SaveEntityAsync<T>(T data, string connectionId = "Default") where T : class
    {
        await using var dbContext = new ApiDbContext(new DbContextOptionsBuilder<ApiDbContext>()
            .UseNpgsql(_config.GetConnectionString(connectionId))
            .Options);

        EntityEntry<T> entity = await dbContext.AddAsync(data);
        await dbContext.SaveChangesAsync();

        return entity.Entity;
    }
    public async Task<T> UpdateEntityAsyncEntityAsync<T>(T data, string connectionId = "Default") where T : class
    {
        using var dbContext = new ApiDbContext(new DbContextOptionsBuilder<ApiDbContext>()
            .UseNpgsql(_config.GetConnectionString(connectionId))
            .Options);

        EntityEntry<T> entity = dbContext.Set<T>().Update(data);
        await dbContext.SaveChangesAsync();

        return entity.Entity;
    }
    public async Task<T> DeleteEntityAsync<T>(T data, string connectionId = "Default") where T : class
    {
        await using var dbContext = new ApiDbContext(new DbContextOptionsBuilder<ApiDbContext>()
            .UseNpgsql(_config.GetConnectionString(connectionId))
            .Options);

        EntityEntry<T> entity = dbContext.Remove(data);
        await dbContext.SaveChangesAsync();
        return entity.Entity;

    }
}