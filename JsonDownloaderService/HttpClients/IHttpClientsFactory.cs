namespace JsonDownloaderService.HttpClients;
public interface IHttpClientsFactory
{
    public Task<T> GetAsync<T>(string queryId);
}

