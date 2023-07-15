using DataAccess.Data;
using DataAccess.Models;
using JsonDownloaderService.HttpClients;
using Microsoft.AspNetCore.Mvc;

namespace JsonDownloaderService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SpaceXEventController : ControllerBase
{
    private readonly IHttpClientsFactory _httpClient;
    private readonly ISpaceXEventData _data;
    public SpaceXEventController(IHttpClientsFactory httpClient, ISpaceXEventData data)
    {
        _httpClient = httpClient;
        this._data = data;
    }

    /// <summary>
    /// Id:
    /// "5f6fb2cfdcfdf403df37971e
    ///" 5f6fb2efdcfdf403df37971f" 
    ///" 5f6fb312dcfdf403df379720"
    /// </summary>
    [HttpPost("download")]
    public async Task<IActionResult> DownloadAndSaveSpaceXEvent()
    {
        try
        {
            SpaceXEventModel spaceXEventModel = await _httpClient.GetAsync<SpaceXEventModel>("5f6fb2cfdcfdf403df37971e");
            return Ok(await _data.InsertSpaceXEvent(spaceXEventModel));


        }
        catch (Exception e)
        {
            return Problem(e.Message);
        }
    }

    [HttpGet("events")]
    public async Task<IActionResult> GetSpaceXEvents()
    {
        try
        {
            return Ok(await _data.GetSpaceXEvents());
        }
        catch (Exception e)
        {
            return Problem(e.Message);
        }
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetSpaceXEvent(long id)
    {
        try
        {
            var result = await _data.GetSpaceXEvent(id);
            return result == null ?
                NotFound() : Ok(result);
        }
        catch (Exception e)
        {
            return Problem(e.Message);
        }
    }
    [HttpPost("create_test_data")]
    public async Task<IActionResult> InsertTestData()
    {
        try
        {  
            return Ok(await _data.InsertTestData());
        }
        catch (Exception e)
        {
            return Problem(e.Message);
        }
    }
    [HttpPost]
    public async Task<IActionResult> InsertSpaceXEvent([FromBody] SpaceXEventModel SpaceXEventModel)
    {
        try
        {
            return Ok(await _data.InsertSpaceXEvent(SpaceXEventModel));
        }
        catch (Exception e)
        {
            return Problem(e.Message);
        }
    }
    [HttpPut]
    public async Task<IActionResult> UpdateSpaceXEvent([FromBody] SpaceXEventModel SpaceXEventModel , long Id)
    {
        try
        {
            return Ok(await _data.UpdateSpaceXEvent<SpaceXEventModel>(SpaceXEventModel, Id));
        }
        catch (Exception e)
        {
            return Problem(e.Message);
        }
    }
    [HttpDelete]
    public async Task<IActionResult> DeleteSpaceXEvent(long id)
    {
        try
        {
            return Ok(await _data.DeleteSpaceXEvent(id));
        }
        catch (Exception e)
        {
            return Problem(e.Message);
        }
    }





}