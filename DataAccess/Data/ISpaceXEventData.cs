using DataAccess.Models;

namespace DataAccess.Data;

public interface ISpaceXEventData 
{
    Task<IEnumerable<SpaceXEventModel>> GetSpaceXEvents();
    Task<SpaceXEventModel?> GetSpaceXEvent(long id);
    Task<SpaceXEventModel> InsertSpaceXEvent(SpaceXEventModel newSpaceXEventModel);
    Task<SpaceXEventModel> InsertTestData();
    Task<SpaceXEventModel> UpdateSpaceXEvent<T>(SpaceXEventModel newSpaceXEventModel, long Id);
    Task<SpaceXEventModel> DeleteSpaceXEvent(long id);
}