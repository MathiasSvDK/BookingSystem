
namespace Web.Service
{
    public interface IApiService
    {
        Task DeleteAsync(string url);
        Task<T> GetAsync<T>(string url);
        //Task<TR> PostAsync<T, TR>(string uri, T data, string authToken = "");
        Task<T> PostAsync<T>(string url, T data);
        Task<T> PutAsync<T>(string url, T data);
    }
}