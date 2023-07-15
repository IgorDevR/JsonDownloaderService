using DataAccess.Models;
using System.Text.Json;

namespace JsonDownloaderService.HttpClients;

public class SpaceXApiHttpClient : IHttpClientsFactory
{
    private readonly HttpClient _client;
    private readonly string _baseUri = "https://api.spacexdata.com/v4/history/";
    public SpaceXApiHttpClient(HttpClient client)
    {
        _client = client;
        _client.BaseAddress = new Uri(_baseUri);

    }

    public async Task<T> GetAsync<T>(string queryId)
    {
        //HttpResponseMessage response = await _client.GetAsync(queryId.ToString());
        HttpResponseMessage response = await _client.GetAsync(queryId);
        if (response.IsSuccessStatusCode)
        {
            string content = await response.Content.ReadAsStringAsync();
            T model = JsonSerializer.Deserialize<T>(content);
            SpaceXEventModel model2 = JsonSerializer.Deserialize<SpaceXEventModel>(content);
            return model;
        }
        else
        {
            // Обработка ошибки
            throw new Exception($"Failed to get data. StatusCode: {response.StatusCode}");
        }
    }

    public async Task<T> DeserializeResponse<T>(HttpResponseMessage response)
    {
        string content = await response.Content.ReadAsStringAsync();
        T model = JsonSerializer.Deserialize<T>(content);
        return model;
    }

}