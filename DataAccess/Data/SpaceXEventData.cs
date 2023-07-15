
using AutoMapper;
using DataAccess.DbAccess;
using DataAccess.Models;

namespace DataAccess.Data;

public class SpaceXEventData : ISpaceXEventData
{
    private readonly ISqlDataAccess _db;
    private readonly IMapper _mapper;
    public SpaceXEventData(ISqlDataAccess db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    public async Task<IEnumerable<SpaceXEventModel>> GetSpaceXEvents()
    {
        var spaceXEventModels = await _db.GetSpaceXEventEntitiesAsync<SpaceXEventModel>();
        return _mapper.Map<IEnumerable<SpaceXEventModel>>(spaceXEventModels);
    }


    public async Task<SpaceXEventModel?> GetSpaceXEvent(long id)
    {
        var spaceXEvents = await _db.GetSpaceXEventEntityAsync<SpaceXEventModel>(id);


        return _mapper.Map<SpaceXEventModel>(spaceXEvents);
    }


    public async Task<SpaceXEventModel> InsertSpaceXEvent(SpaceXEventModel newSpaceXEventModel)
    {
        SpaceXEventModel spaceXEventModel = await _db.SaveEntityAsync(newSpaceXEventModel);
        return _mapper.Map<SpaceXEventModel>(spaceXEventModel);
    }


    public async Task<SpaceXEventModel> InsertTestData()
    {
        var linksModel = new LinksModel
        {
            Article = "https://example.com"
        };

        var spaceXEventModel = new SpaceXEventModel
        {
            Links = linksModel,
            Title = "TestTitle",
            EventDateUtc = DateTime.UtcNow,
            EventDateUnix = 1231231231,
            Details = "DetailTest",
        };
        SpaceXEventModel saveEntityAsync = await _db.SaveEntityAsync(spaceXEventModel);
        return _mapper.Map<SpaceXEventModel>(saveEntityAsync);
    }

    public async Task<SpaceXEventModel> UpdateSpaceXEvent<T>(SpaceXEventModel newSpaceXEventModel, long Id)
    {
        SpaceXEventModel entitySpaceXEventAsync = await _db.GetSpaceXEventEntityAsync<SpaceXEventModel>(Id);
        newSpaceXEventModel.Id = Id;
       return await _db.UpdateEntityAsyncEntityAsync(newSpaceXEventModel);
    }

        

    public async Task<SpaceXEventModel> DeleteSpaceXEvent(long Id)
    {
        SpaceXEventModel entitySpaceXEventAsync = await _db.GetSpaceXEventEntityAsync<SpaceXEventModel>(Id);
        SpaceXEventModel spaceXEventModel = await _db.DeleteEntityAsync(entitySpaceXEventAsync);
        return _mapper.Map<SpaceXEventModel>(spaceXEventModel);
    }
}