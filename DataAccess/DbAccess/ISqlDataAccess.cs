using DataAccess.Models;

namespace DataAccess.DbAccess;

public interface ISqlDataAccess
{
    Task<SpaceXEventModel?> GetSpaceXEventEntityAsync<T>(long Id, string connectionId = "Default") where T : class;
    Task<IEnumerable<T>> GetSpaceXEventEntitiesAsync<T>(string connectionId = "Default") where T : class;
    Task<T> UpdateEntityAsyncEntityAsync<T>(T data, string connectionId = "Default") where T : class;

    Task<T> SaveEntityAsync<T>(T data, string connectionId = "Default") where T : class;
    Task<T> DeleteEntityAsync<T>(T data, string connectionId = "Default") where T : class;
}